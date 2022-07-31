# aerospike

You'll need to install dot net 6. <br />


to excute first clone the repo and run the project: <br />
git clone https://github.com/shai-beinhoren/aerospike.git <br /> <br />

cd aerospike <br />

dotnet build <br />
dotnet run <br />
 


Then, upload aerospike server: <br />
docker run -d --name aerospike -p 3000-3002:3000-3002 aerospike/aerospike-server <br /> <br />
open postman and send a POST request to the server with the long url. Make sure to use the right port and protocol: <br />
https://localhost:7296/COg6q <br />
Payload:
{

    "Url": "https://www.amazon.com/-/he/Bernardo-Kastrup-ebook/dp/B07PGQPV3R/ref=sr_1_3?keywords=bernardo+kastrup&qid=1659251624&s=digital-   text&sprefix=bernardo+k%2Cdigital-text%2C370&sr=1-3"
}

![image](https://user-images.githubusercontent.com/5191999/182014723-5ff24873-eafa-412c-b6ca-3faf7b16e8c2.png) <br /> <br />
click the url from the response and it should redirect you the page: <br />
