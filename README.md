# Stock Management API

REST API for inventory management built with ASP.NET Core, focusing on clean code practices such as layered architecture, DTO pattern, and separation of concerns.

## About

This project is a backend REST API for managing stock items, created to apply core backend concepts such as service layer abstraction, DTO mapping, and centralized exception handling.

## Technologies

- C#
- ASP.NET Core (.NET 10)
- REST API
- Swagger (OpenAPI)
- Dependency Injection
- DTO pattern
- Middleware

## Features

- Create items
- Update items
- Organize request and response data using DTOs
- Service layer for business logic
- Centralized exception handling via middleware
- Swagger UI for testing endpoints

## Project Structure

```text
Stock/
├── Controllers/
├── Dto/
├── Extensions/
├── Mappings/
├── Middleware/
├── Domain/
├── Infrastructure/
└── Program.cs