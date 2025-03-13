

# Clean Architecture Template for .NET

A comprehensive backend template implementing Clean Architecture principles in .NET, focusing on separation of concerns, testability, and scalability.

## Overview

This template provides a solid foundation for building modern .NET applications following Clean Architecture patterns. It enforces a clear separation of concerns with distinct layers and uses the CQRS pattern for better command and query separation.

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL (or modify for your preferred database)

### Setup

1. **Install the Clean Architecture template:**

```sh
dotnet new install eminuckan.CleanArchitecture.Template::1.0.3  
```
2. **Create a new project using the installed template:**
```sh
dotnet new cleanarch -o YourProjectName  
```
Alternatively, you can create a new project directly from Visual Studio by selecting the installed template:

-   Open Visual Studio.
    
-   Choose **"Create a new project."**
    
-   Search and select **"Clean Architecture"** from the installed templates.
    
-   Follow the prompts to name and configure your project.

Update the `appsettings.json` file within your new project, including the connection string, logging settings, and other configuration parameters according to your environment and requirements.

## Architecture

This template follows Clean Architecture principles:

- **Domain Layer**: Core business entities, value objects, and domain logic.
- **Application Layer**: Business use cases, CQRS commands/queries.
- **Infrastructure Layer**: External concerns (database, services, etc.).
- **API Layer**: REST endpoints and controllers.

## Technologies

| Component      | Technologies                          |
| -------------- | ------------------------------------- |
| Framework      | .NET 8                                |
| Architecture   | Clean Architecture, CQRS              |
| API            | ASP.NET Core, Carter for Minimal APIs |
| Database       | Entity Framework Core, PostgreSQL     |
| Validation     | FluentValidation                      |
| Messaging      | MediatR for CQRS and Mediator pattern |
| Error Handling | ErrorOr, Global Exception Handler     |
| Logging        | Serilog, structured logging, Seq for log monitoring |

## Key Features

### CQRS with MediatR

Commands and queries are separated using the CQRS pattern implemented with MediatR.

### Pipeline Behaviors

The template includes pre-built pipeline behaviors for cross-cutting concerns:

- **Validation Behavior**: Automatically validates incoming requests using FluentValidation.
- **Logging Behavior**: Provides consistent logging throughout the request lifecycle.

### Result Pattern with ErrorOr

The template uses the ErrorOr library for predictable error handling.

### Global Exception Handling

Centralized exception handling with problem details for consistent API responses.

### Value Objects

Domain layer implements value objects for better encapsulation.

### Minimal API with Carter

Uses Carter for organizing minimal API endpoints with a clean, modular approach.

## Project Structure

```plaintext
src
├── API            # REST endpoints
├── Domain         # Core business logic
├── Application    # Use cases, CQRS commands & queries
├── Infrastructure # Database, external services
└── tests          # Unit and integration tests
```

## TODO

- [ ] Tests
- [x] Installation with dotnet template
- [ ] Database Choice

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
