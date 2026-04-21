# Appointment Scheduler

> A RESTful API built with ASP.NET Core 10 as a hands-on study project for exploring the .NET ecosystem — covering clean architecture, CQRS, JWT authentication, real-time communication, containerization, and CI/CD pipelines. Business rules are intentionally kept simple; the focus is on applying and understanding the toolset.

[![Continuous Integration, Delivery and Deployment with GitHub Actions and .NET 10](https://github.com/Danihmn/AppointmentScheduler/actions/workflows/continuous-deployment.yml/badge.svg)](https://github.com/Danihmn/AppointmentScheduler/actions/workflows/continuous-deployment.yml)

---

## About

This project simulates a medical appointment scheduling system. It serves as a practical playground for applying ASP.NET Core features and ecosystem patterns in a realistic (but simplified) domain context.

The domain covers secretaries, doctors, patients, specialties, appointments, and requests. Secretaries authenticate via JWT and interact with the system according to their assigned role.

---

## Architecture

The project follows **Clean Architecture** with a custom **CQRS** implementation — no MediatR.

```
Domain       → Entities, Enums, BaseEntity
Features     → CQRS modules per feature (Create / Read / Update / Delete)
Infrastructure → EF Core, Repositories, UoW, JWT, Mapster, SignalR, DI config
API          → Minimal API endpoints, exception handling
```

**Patterns applied:**
- Custom `ICommand<TResponse>` / `ICommandHandler<TCommand, TResponse>` and `IQuery<TResponse>` / `IQueryHandler<TQuery, TResponse>`
- Generic `IRepository<T>` with per-entity specializations
- Unit of Work (`IUnitOfWork`) aggregating all repositories and transactions
- Minimal APIs — no controllers
- Global exception handler mapping custom exceptions to RFC 9457 ProblemDetails

---

## Technologies

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core 10 (Minimal APIs) |
| ORM | Entity Framework Core 10 + SQL Server |
| Object Mapping | Mapster 10 |
| Validation | FluentValidation 12 |
| Authentication | JWT Bearer (HS256, 2h expiration) |
| Real-Time | ASP.NET Core SignalR |
| Error Handling | Hellang.Middleware.ProblemDetails |
| API Docs | Scalar (`/scalar/v1`) |
| Containerization | Docker + Docker Compose + Portainer |
| CI/CD | GitHub Actions |

---

## Infrastructure

### Environment Variables

| Variable | Description |
|---|---|
| `DB_CONNECTION_STRING` | SQL Server connection string |
| `JWT_PRIVATE_KEY` | Secret key used to sign JWT tokens |

### Running locally

```bash
# .NET CLI
dotnet run

# Docker Compose
docker-compose up
```

Database migrations are applied automatically on startup. To apply manually:

```bash
dotnet ef database update
```

API documentation is available at `http://localhost:8080/scalar/v1`.

### Docker services

| Service | Port | Description |
|---|---|---|
| `appointment-scheduler` | `8080` / `8443` | Application |
| `portainer` | `9000` | Container management UI |

### Default seeded credentials

| Field | Value |
|---|---|
| Username | `admin` |
| Password | `Admin@1234` |
| Role | `Admin` |

---

## API Endpoints

Full interactive documentation is available via **Scalar** at `/scalar/v1`.

### Authentication

| Method | Route | Description |
|---|---|---|
| `POST` | `/api/auth/login` | Authenticate and receive a JWT token |

### Real-Time — SignalR

Scalar does not document SignalR hubs. The hub is available at:

```
ws://localhost:8080/hubs/notifications
```

Clients connect using the SignalR client library and listen for notification events broadcast by the server after state-changing operations (appointment creation, update, deletion, and request changes).

**JavaScript example:**

```js
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/notifications", {
        accessTokenFactory: () => "<your-jwt-token>"
    })
    .build();

connection.on("ReceiveNotification", (message) => {
    console.log("Notification:", message);
});

await connection.start();
```

> The hub requires a valid JWT token passed via `accessTokenFactory` or the `access_token` query parameter.

---

## Authorization

All routes require authentication (`RequireAuthorization()`). Write operations (POST, PUT, DELETE) additionally require the `Admin` role.

Role-based rules are enforced per endpoint using:

```csharp
.RequireAuthorization(policy => policy.RequireRole("Admin"))
```
