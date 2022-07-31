# aerospike

The code generates a token for each long url and saves it to the DB. <br />
The short url is the doamin/{token}.  <br />
A redirect is made after retrieving the long url from the DB via the token.  <br />
An elaboration on the token generation Algorythm can be found here:  <br />
https://www.arctek.dev/blog/make-a-quick-url-shortener  <br />

You'll need to install dot net 6 to run the project. <br />


to excute, first clone the repo and run the project: <br />
git clone https://github.com/shai-beinhoren/aerospike.git <br /> <
cd aerospike <br />
dotnet build <br />
dotnet run <br />
 


Then, upload aerospike server: <br />
docker run -d --name aerospike -p 3000-3002:3000-3002 aerospike/aerospike-server <br /> <br />
open postman and send a POST request to the server with the long url. Make sure to use the right port and protocol, change if needed: <br />
https://localhost:7296/COg6q <br />
Payload:
{

    "Url": "https://www.amazon.com/-/he/Bernardo-Kastrup-ebook/dp/B07PGQPV3R/ref=sr_1_3?keywords=bernardo+kastrup&qid=1659251624&s=digital-   text&sprefix=bernardo+k%2Cdigital-text%2C370&sr=1-3"
}

![image](https://user-images.githubusercontent.com/5191999/182014723-5ff24873-eafa-412c-b6ca-3faf7b16e8c2.png) <br /> <br />
click the url from the response and it should redirect you the page. Make sure to use the right port and protocol, change if needed <br />


Improvements can be made. <br />
1.validation for client and BE. e.g. check the url is valid on client side and check long url doesn't exist already in DB on BE.<br />
2. Async calls to DB. <br />
3. extracting data to config, e.g. domain etc  <br />
