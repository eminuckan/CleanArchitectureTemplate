# Clean Architecture Template for .NET

A comprehensive backend template implementing Clean Architecture principles in .NET, focusing on separation of concerns, testability, and scalability.

## Overview

This template provides a solid foundation for building modern .NET applications following Clean Architecture patterns. It enforces a clear separation of concerns with distinct layers and uses the CQRS pattern for better command and query separation.

## Architecture

This template strictly follows Clean Architecture principles:

-   **Domain Layer**: Core business entities, value objects, and domain logic.
    
-   **Application Layer**: Business use cases, CQRS commands/queries.
    
-   **Infrastructure Layer**: External concerns (database, services, etc.).
    
-   **API Layer**: REST endpoints and controllers.  
    

## Technologies

Component

Technologies

Framework

.NET 8

Architecture

Clean Architecture, CQRS

API

ASP.NET Core, Carter for Minimal APIs

Database

Entity Framework Core, PostgreSQL

Validation

FluentValidation

Messaging

MediatR for CQRS and Mediator pattern

Error Handling

ErrorOr, Global Exception Handler

Logging

Serilog, structured logging, Seq for log monitoring

## Key Features

### CQRS with MediatR

Commands and queries are separated using the CQRS pattern implemented with MediatR.

### Pipeline Behaviors

The template includes pre-built pipeline behaviors for cross-cutting concerns:

-   **Validation Behavior**: Automatically validates incoming requests using FluentValidation.
    
-   **Logging Behavior**: Provides consistent logging throughout the request lifecycle.
    

### Result Pattern with ErrorOr

The template uses the ErrorOr library for predictable error handling.

### Global Exception Handling

Centralized exception handling with problem details for consistent API responses.

### Value Objects

Domain layer implements value objects for better encapsulation.

### Minimal API with Carter

Uses Carter for organizing minimal API endpoints with a clean, modular approach.

## Project Structure

```
src
├── API            # REST endpoints
├── Domain         # Core business logic
├── Application    # Use cases, CQRS commands & queries
├── Infrastructure # Database, external services
├── Shared         # Shared utilities and base classes
└── tests          # Unit and integration tests
```

## Getting Started

### Prerequisites

-   .NET 8 SDK
    
-   PostgreSQL (or modify for your preferred database)
    

### Setup

1.  Clone the repository:
    
    ```
    git clone https://github.com/your-repo/clean-architecture-template.git
    ```
    
2.  Update the connection string in `appsettings.json`.
    
3.  Run the application:
    
    ```
    dotnet run --project src/API
    ```
    
4.  Open [https://localhost:5001/swagger](https://localhost:5001/swagger) to see the API documentation.
    

## License

This project is licensed under the MIT License -- see the LICENSE file for details.