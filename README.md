# aerospike

The code generates a token for each long url and saves it to the DB. <br />
The short url is the doamin/{token}.  <br />
A redirect is made after retrieving the long url from the DB via the token.  <br />
An elaboration on the token generation Algorythm can be found here:  <br />
https://www.arctek.dev/blog/make-a-quick-url-shortener  <br />

We'll have 2 containers communicating  via a network. <br />


**To excute, first clone the repo and run the project:** <br />
git clone https://github.com/shai-beinhoren/aerospike.git <br /> 

**Build the image for the service:** <br />
cd aerospike <br />
docker build -t shorturlimage -f Dockerfile . <br />

**create a network:**  <br />
docker network create aero-net <br />

**connect the service and aerospike to the network and run it:** <br />

docker run -d --net aero-net --name aerospike -p 3000-3002:3000-3002 aerospike/aerospike-server <br />
 docker run -ti --rm --name shorturlservice --net aero-net -p 8080:80 shorturlimage <br />


**Open postman and send a POST request to the server with the long url.** <br />
http://localhost:8080/api/shorten <br />
Payload:
{

    "Url": "https://www.amazon.com/-/he/Bernardo-Kastrup-ebook/dp/B07PGQPV3R/ref=sr_1_3?keywords=bernardo+kastrup&qid=1659251624&s=digital-   text&sprefix=bernardo+k%2Cdigital-text%2C370&sr=1-3"
}

![image](https://user-images.githubusercontent.com/5191999/182029338-4b6175a8-5677-4d25-9409-93bbf52bbc05.png)
 <br /> <br />
click the url from the response and it should redirect you the page.  <br />

<br />
Improvements can be made. <br />
1.validation for client and BE. e.g. check the url is valid on client side and check long url doesn't exist already in DB on BE.<br />
2. Async calls to DB. <br />
3. extracting data to config, e.g. domain etc  <br />
