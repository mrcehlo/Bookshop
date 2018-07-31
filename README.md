[![Build status](https://ci.appveyor.com/api/projects/status/f6pi6cwb28tt2tb3?svg=true)](https://ci.appveyor.com/project/mrcehlo/bookshop)

# Bookshop

Minimal bookshop management application.

## Getting Started

This is a minimalist web app involving some of the best technologies on the market. In order to train on these topics, it was given the context of a bookshop. Enjoy it!

### Prerequisites

- Node.js v8.10.0
- .NET Core v2.0.7
- npm
- MongoDB


### Installing

Clone this repository:

```
$ git clone https://github.com/mrcehlo/Bookshop.git
```

Provide the correct params for your MongoDB instance on the file `src/Boookshop.Service.WebAPI/appsettings.json`.

In order to start the back-end API, run the following command from the root directory:

```
$ dotnet run -p src/Boookshop.Service.WebAPI
```

Now for the front-end, follow up to the web page root directory

```
$ cd src/Bookshop.Application.WebSiteReact
```
Once there, hit
```
$ npm install
```
to restore all packages and

```
$ npm start
```
to finally start the application!

### Exploring the API 

If you wanna test any method exposed by the API, you should do it by using the Swagger interactive documentation.
Just navigate to
```
htpp://<server>/swagger/#/api/books
```
and explore it, as simple as that.

## Built With

* [.NET Core](https://github.com/dotnet/core) - .NET Core is a cross-platform version of .NET for building websites, services, and console apps.
* [MongoDB](https://www.mongodb.com/) - For GIANT ideas.
* [React](https://reactjs.org/) - A JavaScript library for building user interfaces.
* [Material-UI](https://material-ui.com/) - React components that implement Google's Material Design.
* [Visual Studio Community 2017](https://visualstudio.microsoft.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F) - The usual Visual Studio, community version.
* [Swagger](https://swagger.io/) - The Best APIs are Built with Swagger Tools.

## Authors

* **Marcelo Antunes** - [mrcehlo](https://github.com/mrcehlo)
