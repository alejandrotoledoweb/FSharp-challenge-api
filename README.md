# Brick Adobe F# coding challenge to build an API
  
  This project was part of a coding challenge at Brick Adobe.
  The objective was to build a sample application that work in the back end of the proposed project according to the mockups images showed by the developer at Brick Adobe. Using the SAFE template of the language F#(F sharp) and for this specific project I am using the minimal template.
  I am using postgresql for the database.


## End points

### get "/api/blotters"

to get all the blotter from the users.

Example:

`{ Id: Guid; DateTime: DateTime; Price: float; Quantity: int; Pair: string }`

### get "/api/markets"

to get all the values from the market.

Example:
`{ Id: Guid; Provider: string; Pair: string; Price: float; Time: DateTime}`

### post "/api/new/blotters"

to get all the blotter from the users.

Example:

`{ Id: Guid; DateTime: DateTime; Price: float; Quantity: int; Pair: string }`

### post "/api/new/markets"

to get all the values from the market.

Example:
`{ Id: Guid; Provider: string; Pair: string; Price: float; Time: DateTime}`



# F#(SAFE Template)

This template can be used to generate a full-stack web application using the [SAFE Stack](https://safe-stack.github.io/). It was created using the dotnet [SAFE Template](https://safe-stack.github.io/docs/template-overview/). If you want to learn more about the template why not start with the [quick start](https://safe-stack.github.io/docs/quickstart/) guide?

## Install pre-requisites

You'll need to install the following pre-requisites in order to build SAFE applications

* The [.NET Core SDK](https://www.microsoft.com/net/download) 3.1 or higher.
* [npm](https://nodejs.org/en/download/) package manager.
* [Node LTS](https://nodejs.org/en/download/).

## Starting the application

Start the server:

```bash
cd src\Server\
dotnet watch run
```

Start the client:

```bash
npm install
dotnet tool restore
dotnet fable watch src/Client --run webpack-dev-server
```

Open a browser to `http://localhost:8080` to view the site.

## SAFE Stack Documentation

If you want to know more about the full Azure Stack and all of its components (including Azure) visit the official [SAFE documentation](https://safe-stack.github.io/docs/).

You will find more documentation about the used F# components at the following places:

* [Saturn](https://saturnframework.org/)
* [Fable](https://fable.io/docs/)
* [Elmish](https://elmish.github.io/elmish/)
