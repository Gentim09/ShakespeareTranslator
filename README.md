## ShakespeareTranslator API 

This repository contains an example API written in C# and ASP.NET Core 3.1.
The purpose of this API is to get the Shakespearean pokemon description by passing a Pokemon Name. The translation is done by using [Fun Translation Api](https://funtranslations.com/shakespeare).

```markdown
GET /pokemon/{pokemonName}
```

```markdown
{
  "name": "pokemonName",
  "description": "{translated description}",
}
```
## Getting Started
Get you a copy of the project and run it on your local machine for development and testing purposes.
This API uses [Swagger](https://swagger.io/), for easily test via the browser.
## Testing it out

1. Dowload this repository into a working directory.
2. Open the project in Visual Studio. 
3. You can download and install [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) 
3. Build the solution using Visual Studio. 
3. Run the project. The API will start up on http://localhost:5001, or http://localhost:5000 .

## Running the API using Docker

If you have [Docker Desktop](https://www.docker.com/products/docker-desktop) installed and running on you machine, you can deploy the application locally using docker.
You can run the API  by running these commands from the root folder (where the .sln file is located):

```markdown
 docker build -t [IMAGE_NAME] .
 docker build -t shakespearetranslation .
```
once build is complete, you can start the container -

```markdown
docker run -p [PORT_NUMBER]:80 [IMAGE_NAME]
docker run -p 9000:80 -t  shakespearetranslation
```

You should be able to make requests to http://localhost:9000/swagger/index.html once these commands complete.
