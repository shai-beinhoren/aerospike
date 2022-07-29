
using System;
using System.Linq;
using Aerospike.Client;

public class Shortener{
		public string Token { get; set; } 
		private static string NS= "test";
        private static string SET= "Urls";
        private static string REALURL= "realUrl";
        private static string SHORTURL= "shortUrl";
        private static string TOKEN= "token";
		// The method with which we generate the token
		private void GenerateToken() {
			string urlsafe = string.Empty;
			Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
			Token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
			
		}

    internal string GetUrl(string token)
    {
        AerospikeClient client = new AerospikeClient("127.0.0.1", 3000);

        // Create key
        Key key = new Key(NS, SET, token);
    
        // Read record
        Record record = client.Get(null, key);
        if (record is null)
            throw new  Exception("not found");
        // Close connection
        client.Close();
        return record.bins["realUrl"].ToString();
;
    }

    public (string token, string shortUrl) GetShortUrl(string url) 
        {
			 // Establish connection the server
            AerospikeClient client = new AerospikeClient("127.0.0.1", 3000);
          
             //RecordSet rs = client.Query(null, stmt);
			GenerateToken();
            Key key = new Key(NS, SET, Token);
            Record record  = client.Get(null, key);
			// While the token exists in  DB we generate a new one
            while (record!=null){
                 GenerateToken();
                 record  = client.Get(null, key);
            } ;
            Key newKey = new Key(NS, SET, Token);
            // Store the values in the NixURL model
			var domain ="http://localhost:8080";
            Bin bin1 = new Bin(TOKEN, Token);
            Bin bin2 = new Bin(REALURL, url);
            var shortUrl = $"{domain}/{this.Token}";
            Bin bin3 = new Bin(SHORTURL, shortUrl);
            client.Put(null, newKey, bin1, bin2,bin3);
             // Close connection
            client.Close();
            return (Token,shortUrl);
		}
	}
