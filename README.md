# VehicleFees
The vehicle fees service calculates the total price of a vehicle. It utilizes Clean Architecture to ensure a clear separation of concerns and facilitate scalability and maintainability of the codebase.

## Project Structure
The project adheres to a Clean Architecture structure, comprising four main layers:

- **Vehicle.Domain:** Contains the entities of the application.
- **Vehicle.Application:** Implements the application use cases.
- **Vehicle.Infrastructure:** Provides implementation to access data and services.
- **Vehicle.API:** Serves as the entry point for the application. Single endpoint created.

Additionally, the solution includes the following projects:
- **VehicleFees.Api.FunctionalTests** Functional tests were created to assert the potential outputs of the API.
- **docker-compose** Created to run the app and redis in docker

## Technologies Used
The project was developed using the following technologies:

- Programming Language: C#
- Framework: .NET Core 8

### Application
- Additional Libraries: MediatR, FluentValidation

### Infrastructure
- Additional Libraries: Redis

### Testing
- Additional Libraries: XUnit, FluentAssertions

## Configuration
To set up the project locally, follow these steps:

1. Open the project in Visual Studio or your preferred code editor.
2. Build the project and restore NuGet dependencies.
3. Run the application.

## Testing
Navigate to the 'tests' folder to run them.




