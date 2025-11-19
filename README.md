# Clean Architecture in C#

This repository is a learning project for implementing **Clean Architecture** in C#.
The goal is to understand how backend structure, separation of concerns, and maintainability can be improved by following this architecture pattern.
The project uses **Entity Framework Core** with a **MySQL** database.

## Domain Layer

The core of the application and contains no external dependencies.

* **Entities** – Core business objects.
* **Value Objects** – Immutable domain rules.
* **Interfaces / Abstractions** – Contracts for the application.
* **Domain Services** – Complex business logic.

## Application layer (UseCases)

The Application layer orchestrates how the system behaves. It defines the business workflows but does not know anything about infrastructure or databases.

* **DTO's (Data Transfer Objects)**
*  **interfaces (with DTO)**
*  **Validators**

No external frameworks or database logic should exist here.

## Infrastructure Layer
* **Entity Framework DbContext**
* **Repositories**
* **Migrations**

## Presentation Layer (WebAPI)

The **Presentation** layer handles incoming HTTP requests and returns responses.

* **ASP.NET Core WebAPI**
* **Controllers / Minimal APIs**
* **Dependency Injection setup**
* **External service integrations**

This is the entry point for the user or client applications.

---

#### Used commands

```bash
dotnet ef migrations add 

#try always updating 
dotnet ef database update 

git rm --cached <file>
```


#### links
https://code-maze.com/dotnet-clean-architecture/

https://medium.com/@jenilsojitra/clean-architecture-in-net-core-e18b4ad229c8
