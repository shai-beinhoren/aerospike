# aerospike
to excute first clone the repo and run the project:
git clone https://github.com/shai-beinhoren/aerospike.git
go into aerospike folder
dotnet build
dotnet run
get the https localhost address with the port
![image](https://user-images.githubusercontent.com/5191999/182014723-5ff24873-eafa-412c-b6ca-3faf7b16e8c2.png)

Then, upload aerospike server:
docker run -d --name aerospike -p 3000-3002:3000-3002 aerospike/aerospike-server
open postman and send a request to the server:
https://localhost:7296/COg6q
click the url from the response and it should redirect you the page:
