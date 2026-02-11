# DDD Clean Architecture Sample (.NET)

This project is a **learning-oriented implementation** of **Domain-Driven Design (DDD)** combined with **Clean Architecture** and **CQRS** using **ASP.NET Core**, **MediatR**, and **Entity Framework Core**.

The goal of this repository is to demonstrate **proper layering, separation of concerns, and domain modeling**, not to build a production-ready system.

---

## ✨ Features

- Clean Architecture (Domain, Application, Infrastructure, Presentation)
- Domain-Driven Design (Value Objects, Aggregates, Entities)
- CQRS (Command / Query separation)
- MediatR for in-process messaging
- EF Core with persistence abstractions
- Unit of Work pattern
- Carter for Minimal API endpoints
- Swagger / OpenAPI support

---

## 🧱 Project Structure

DDD
│
├── DDD.Domain
│ ├── Entities
│ ├── ValueObjects
│ └── Abstractions
│
├── DDD.Application
│ ├── Products
│ │ ├── Create
│ │ └── Get
│ ├── Interfaces
│ └── Behaviors
│
├── DDD.Persistence
│ ├── DbContext
│ ├── Repositories
│ └── UnitOfWork
│
└── DDD.API
├── Carter Modules
├── Program.cs
└── Swagger


---

## 🧠 Key Concepts Used

### Domain-Driven Design (DDD)
- **Entities** (`Product`)
- **Value Objects** (`ProductId`, `Sku`, `Money`)
- Domain rules enforced inside the domain layer

### Clean Architecture
- Domain has **no dependencies**
- Application depends only on Domain
- Infrastructure depends on Application
- API depends on everything

### CQRS
- Commands mutate state (`CreateProductCommand`)
- Queries read state (`GetProductQuery`)
- Separate handlers for each responsibility

---

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK or later
- Visual Studio / VS Code
- Postgres SQL

### Run the project

```bash
dotnet restore
dotnet build
dotnet run
```
Swagger UI will be available at:

```https://localhost:<port>/swagger```

🧪 Example Endpoints

POST /products – Create a product

GET /products/{id} – Get product by ID

###📚 References

This project was built as a learning exercise inspired by Clean Architecture and Domain-Driven Design resources in the .NET ecosystem.

###⚠️ Disclaimer


This project is intentionally simple and focuses on architecture and design principles, not on edge cases, performance, or production readiness.


test