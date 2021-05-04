# How to start app

## Requirements

Make sure you have:

-   [dotnet cli](https://dotnet.microsoft.com/download) - I've used the latest .NET 5.
-   [node](https://nodejs.org)
-   [npm](https://www.npmjs.com/get-npm)
-   [angular](https://angular.io/guide/setup-local) - I've used v11

## Installation

Use npm to install packages

```bash
npm install -g @angular/cli
cd hospital-findio-client
npm install
```

## Usage

Use two terminals

```bash
# first terminal - server

cd ./Hospital.Findio.Api/
# you may need to do a dotnet restore if dependency errros occur
dotnet run
# runs at https://localhost:5001

# second teminal - client
cd ./hospital-findio-client
ng serve

# runs at https://localhost:4200/
```
