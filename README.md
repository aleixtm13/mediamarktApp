# MediaMarkt App
## Application Overview
This application is composed of two main parts: a client application developed using React and TypeScript using Vite as a build tool, and an API developed using .NET 6. Also there is a SQL Server Database to store and manage the products.

## Prerequisites
* Node.js and npm installed for the client application
* .NET 6.0 SDK installed for the API
* SQL Server for the Database

## How to Start
### Create the database
* The API is developed using EF Core in a Code-First way.
* The DB will be created the first time you run the API.
* Ensure the Database connection string in ```mediamarkt\mediamarktAPI\src\Web.API\appsettings.Development.json``` is that you want for your environment
```json
{
  "ConnectionStrings": {
    "Database": "Server=localhost; Database=Mediamarkt;Integrated Security=True;TrustServerCertificate=True;"
  },
  ...
}
```

### Start the API
* Navigate to the API directory
* Restore the dependencies with ```dotnet restore```
* Start the API with ```dotnet run```
 
Please ensure that both the client application and the API are running simultaneously for the application to function correctly.

### Consuming the API
There is a swagger view to consume and test the API.
It is available at: https://localhost:7232/swagger/index.html

### Start the Client Application
* Navigate to the client application directory
* Install the dependencies with ```npm install```
* Start the application with npm ```run dev```
* The application will be available at http://localhost:5173

### Tests
This application has Unit Tests for both Client Application and for the API
#### API Unit Tests:
To run the API Unit tests:
* Open a terminal
* go to  ```mediamarkt\mediamarktAPI\``` folder
* execute ```dotnet test``` command

#### Client Unit Tests:
To run the Client Unit tests:
* Open a terminal
* go to  ```mediamarkt\mediamarktClient\``` folder
* execute ```npm run test``` command

