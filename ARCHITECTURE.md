
# Architecture Overview

This document explains the architectural decisions and structure of the project.

---

## 🧱 Architectural Style

The project follows:

- **Clean Architecture**
- **Domain-Driven Design (DDD)**
- **CQRS (Command Query Responsibility Segregation)**

The core idea is to **protect the domain** and keep business rules independent of frameworks.

---

## 📐 Layer Responsibilities

### 1️⃣ Domain Layer (`DDD.Domain`)

**Purpose:**  
Contains the **core business logic** and rules.

**Contains:**
- Entities (`Product`)
- Value Objects (`ProductId`, `Sku`, `Money`)
- Domain abstractions (interfaces)

**Rules:**
- No dependency on EF Core, MediatR, ASP.NET
- No infrastructure concerns

```csharp
public class Product
{
    public Product(ProductId id, string name, Money price, Sku sku)
    {
        Id = id;
        Name = name;
        Price = price;
        Sku = sku;
    }
}
```
### 2️⃣ Application Layer (`DDD.Application`)
**Purpose:**
Coordinates use cases and application workflows.

**Contains:**

- Commands & Queries

- Handlers (MediatR)

- Interfaces for repositories & unit of work

- Responsibilities:

- Orchestrates domain objects

- No EF Core or HTTP knowledge
```csharp
public sealed class GetProductQueryHandler
    : IRequestHandler<GetProductQuery, ProductResponse>
{
}
```
Handlers are sealed to:

- Prevent inheritance

- Encourage composition

- Improve predictability

###3️⃣ Persistence / Infrastructure Layer (`DDD.Persistence`)

Purpose:
Implements technical concerns.

Contains:

- ApplicationDbContext

- EF Core configurations

- Repository implementations

- Unit of Work

```csharp
public class UnitOfWork : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
}
```

Why Unit of Work here?

- It coordinates persistence

- It depends on EF Core

- It should not leak into Domain

###4️⃣ Presentation Layer (`DDD.API`)

Purpose:
Handles HTTP requests and responses.

Contains:

- Carter modules

- API endpoints

- Swagger configuration
```csharp
app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
{
    await sender.Send(command);
    return Results.Ok();
});
```

###🔄 Dependency Flow
API
 ↓
Application
 ↓
Domain


Infrastructure implements interfaces defined in Application.

###🔁 CQRS Flow Example
1. Create Product

1. HTTP Request → API

1. API sends CreateProductCommand

1. Handler validates and creates domain entity

1. Repository saves via Unit of Work

1. Get Product

1. HTTP Request → API

1. API sends GetProductQuery

1. Handler fetches entity

1. Maps to response DTO

###🎯 Design Goals

- Explicit boundaries

- Testability

- Maintainability

- Domain purity

- Framework independence

###🚫 Intentional Limitations

- No authentication

- No caching

- Minimal validation

- Simple error handling

These are excluded to keep the focus on architecture.

###✅ Summary

- This project demonstrates:

- How DDD fits into Clean Architecture

- Where CQRS handlers belong

- Why Unit of Work is infrastructure

- How to structure a maintainable .NET solution