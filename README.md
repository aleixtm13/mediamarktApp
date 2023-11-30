# MediaMarkt App
## Application Overview
This application is composed of two main parts: a client application developed using React and TypeScript with Vite, and an API developed using .NET.

The client application is responsible for the user interface and user interactions. It fetches data from the .NET API and displays it to the user. The user can interact with the data through the client application, which sends requests to the API based on the user's actions.

The .NET API is responsible for handling these requests. It interacts with the database, performs necessary computations, and sends the results back to the client application.

## How to Start
### Prerequisites
Node.js and npm installed for the client application
.NET SDK installed for the API
### Starting the Client Application
Navigate to the client application directory
Install the dependencies with npm install
Start the application with npm start
The application will be available at http://localhost:3000
### Starting the API
Navigate to the API directory
Restore the dependencies with dotnet restore
Start the API with dotnet run
The API will be available at http://localhost:5000
Please ensure that both the client application and the API are running simultaneously for the application to function correctly.

### Next Steps
Explore the codebase to understand the application structure and logic
Make necessary modifications to suit your requirements
Build and deploy the application
Remember to follow good software development practices, including writing unit tests, using version control, and regularly updating dependencies.
