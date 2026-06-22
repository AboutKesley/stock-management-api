# Stock Management API

A professional backend REST API built with ASP.NET Core, Entity Framework Core and SQL Server for managing stock items.

This project was created as a portfolio API focused on backend development practices commonly used in enterprise applications, inventory workflows and manufacturing-related systems.

## Purpose

The goal of this project is to demonstrate clean backend development using .NET, including layered architecture, dependency injection, persistence with Entity Framework Core, DTOs, repository pattern, Swagger documentation and automated tests.

This is not a full ERP or MES system. It is a focused stock management API designed to show solid backend fundamentals.

## Technologies

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Repository Pattern
- Dependency Injection
- Swagger / OpenAPI
- xUnit
- GitHub Actions

## Architecture

The solution follows a layered architecture:

```txt
src/
  Stock.Api             -> HTTP layer: controllers, middleware and API configuration
  Stock.Application     -> DTOs, interfaces, mappings and application services
  Stock.Domain          -> domain entities, enums and business rules
  Stock.Infrastructure  -> EF Core DbContext, repositories and database configuration

tests/
  Stock.UnitTests       -> unit tests
```

### Project responsibilities

| Project | Responsibility |
|--------|----------------|
| Stock.Api | Exposes REST endpoints and handles HTTP requests/responses |
| Stock.Application | Contains use cases, DTOs, mappings and service contracts |
| Stock.Domain | Contains core business entities and domain rules |
| Stock.Infrastructure | Handles database access using EF Core and SQL Server |
| Stock.UnitTests | Contains automated tests for business rules |

## Features

- Create stock items
- List stock items
- Get item by ID
- Update stock items
- Delete stock items
- SQL Server persistence with Entity Framework Core
- Global exception handling middleware
- Swagger documentation
- Basic unit tests
- CI pipeline with GitHub Actions

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/items` | Create a new item |
| GET | `/api/items` | Get all items |
| GET | `/api/items/{id}` | Get item by ID |
| PUT | `/api/items/{id}` | Update an item |
| DELETE | `/api/items/{id}` | Delete an item |

## Example Request

```http
POST /api/items
Content-Type: application/json

{
  "name": "Industrial Sensor",
  "quantity": 15,
  "type": "Electronic"
}
```

## Example Response

```json
{
  "id": 1,
  "name": "Industrial Sensor",
  "quantity": 15,
  "type": "Electronic"
}
```

## Running Locally

### Requirements

- .NET 10 SDK
- SQL Server or SQL Server LocalDB
- Visual Studio 2022, Rider or VS Code

### 1. Clone the repository

```bash
git clone https://github.com/AboutKesley/stock-management-api.git
cd stock-management-api
```

### 2. Configure the database connection

Update the connection string in:

```txt
src/Stock.Api/appsettings.json
```

Example using SQL Server LocalDB:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StockManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Restore dependencies

```bash
dotnet restore Stock.sln
```

### 4. Apply database migrations

```bash
dotnet ef database update --project src/Stock.Infrastructure --startup-project src/Stock.Api
```

### 5. Run the API

```bash
dotnet run --project src/Stock.Api
```

Swagger will be available at:

```txt
https://localhost:<port>/swagger
```

## Running Tests

```bash
dotnet test Stock.sln
```

## Development Notes

This project intentionally keeps the architecture simple and readable.

The focus is not to over-engineer the solution, but to demonstrate clean backend fundamentals:

- Clear project separation
- Consistent naming
- DTO usage
- Repository abstraction
- EF Core persistence
- Dependency injection
- Global exception handling
- Testable domain logic

## Roadmap

Planned improvements:

- Add request validation with FluentValidation
- Add pagination and filtering
- Add Docker Compose with SQL Server
- Add integration tests
- Add authentication with JWT
- Add stock movement history
- Add audit fields such as CreatedAt and UpdatedAt

## Author

Developed by Kesley Ferreira as part of a backend .NET portfolio focused on international opportunities, enterprise systems and manufacturing-related backend development.