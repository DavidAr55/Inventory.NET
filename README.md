# Inventory System

Inventory management system built with ASP.NET Core (.NET 10) and, later, Angular.
A practice project to apply backend/API concepts: layered architecture, EF Core, DI, validation, auth, error handling.

## Architecture

```
Inventory.slnx
└── src/
    ├── Inventory.Api             ASP.NET Core Web API (controllers)
    ├── Inventory.Domain          Entities, enums, business rules
    └── Inventory.Infrastructure  EF Core, DbContext, migrations
```

Dependencies point towards the domain: `Api -> Infrastructure -> Domain`.

## Stack
- C#, .NET 10, ASP.NET Core
- EF Core (Code First) + SQL Server (LocalDB in development)
- Angular + TypeScript (planned)

## Status
Phase 1 in progress: base API (domain entities done, EF Core setup in progress).
