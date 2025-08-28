# ?? Books API

A simple **ASP.NET Core Web API** project for managing books using **Entity Framework Core** and **SQL Server**.  
It provides CRUD operations with Swagger UI support for easy testing.

---

## ?? Features
- Create, Read, Update, Delete (CRUD) operations for books
- Entity Framework Core with SQL Server
- Swagger UI for API documentation and testing
- Windows Authentication (Integrated Security)
- Clean architecture with Controllers, DTOs, and Services

---

## ?? Requirements
- [.NET SDK 7/8/9](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (LocalDB, SQL Express, or Docker)
- [EF Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)  
  Install globally if not installed:
  ```bash
  dotnet tool install --global dotnet-ef
