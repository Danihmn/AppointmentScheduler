# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
dotnet build
dotnet run
docker-compose up
```

Database migrations run automatically on startup via `SeedDatabaseAsync()`. Manual migration: `dotnet ef database update`.

There is no test project in this repository.

## Architecture

**Custom CQRS + Clean Architecture** with three layers:

- **Domain** — entities, enums, `BaseEntity`
- **Features** — CQRS modules organized by feature (Appointment, Doctor, Patient, Request, Secretary, Specialty), each with `Create/Read/Update/Delete` subfolders containing commands/queries and their handlers
- **Infrastructure** — EF Core persistence (repositories, UoW, DbContext), JWT auth, Mapster mappings, SignalR hub, DI configuration

**Key patterns:**
- Custom CQRS via `ICommand<TResponse>` / `ICommandHandler<TCommand, TResponse>` and `IQuery<TResponse>` / `IQueryHandler<TQuery, TResponse>` (no MediatR)
- Generic `IRepository<T>` with specialized per-entity repositories
- Unit of Work (`IUnitOfWork`) aggregates all repositories and transactions
- Minimal APIs (no controllers) with endpoint definitions in `API/Endpoints/`
- Global exception handling in `API/Exceptions/GlobalExceptionHandler` maps custom exceptions to ProblemDetails

## Adding a New Feature

Follow the existing pattern exactly:

1. **Domain**: Add entity in `Domain/Entities/`, inheriting `BaseEntity`
2. **Repository**: Add interface in `Infrastructure/Persistence/Repositories/Contract/` and implementation in `Repositories/`; register on `IUnitOfWork`
3. **DbContext**: Add `DbSet<T>` and `IEntityTypeConfiguration<T>` in `Infrastructure/Persistence/AppDbContext/`
4. **CQRS handlers**: Create `Features/{Feature}/{Operation}/{Feature}Command.cs` + `{Feature}CommandHandler.cs` (or Query equivalents)
5. **DTO + Mapping**: Add response DTO and register mapping in `Infrastructure/Mappings/AppointmentSchedulerMapping`
6. **Endpoint**: Register in `API/Endpoints/` using `MapGroup()` and `.RequireAuthorization()`
7. **DI**: Register handlers in `Infrastructure/Persistence/Configurations/` via the `MapCommandHandlers`/`MapQueryHandlers` extension methods

## Authentication

- JWT Bearer, HS256, 2-hour expiration
- Private key from `JWT_PRIVATE_KEY` environment variable
- Connection string from `DB_CONNECTION_STRING` environment variable (or `ConnectionStrings:DefaultConnection` in appsettings)
- Default seeded admin: username `admin`, password `Admin@1234`, role `Admin`
- Role-based authorization applied per endpoint: `.RequireAuthorization(policy => policy.RequireRole("Admin"))`

## Real-Time Notifications

SignalR hub at `/hubs/notifications`. Use `INotificationService` to broadcast events from command handlers after state changes.

## API Documentation

Scalar UI available at `/scalar/v1` when running locally.

## Key Dependencies

- **EF Core + SQL Server** — persistence
- **Mapster** — object mapping (DTOs defined separately from entities)
- **FluentValidation** — input validation
- **Hellang.Middleware.ProblemDetails** — error formatting
- **Microsoft.AspNetCore.Authentication.JwtBearer** — auth
- **Scalar.AspNetCore** — API docs
