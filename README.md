# Appointment Scheduler

> A RESTful API built with ASP.NET Core 10 as a hands-on study project for exploring the .NET ecosystem — covering clean architecture, CQRS, JWT authentication, real-time communication, AI agents with tool use, containerization, and CI/CD pipelines. Business rules are intentionally kept simple; the focus is on applying and understanding the toolset.

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
| AI | Azure OpenAI + Microsoft Agent Framework (MAF) |
| Containerization | Docker + Docker Compose + Portainer |
| CI/CD | GitHub Actions |

---

## Infrastructure

### Environment Variables

| Variable | Description |
|---|---|
| `DB_CONNECTION_STRING` | SQL Server connection string |
| `JWT_PRIVATE_KEY` | Secret key used to sign JWT tokens |
| `AzureOpenAI__Endpoint` | Azure OpenAI resource endpoint URL |
| `AzureOpenAI__Deployment` | Model deployment name (e.g. `gpt-4o`) |
| `AzureOpenAI__ApiKey` | Azure OpenAI API key |

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

## AI Agent

The API includes an AI agent powered by **Azure OpenAI** and the **Microsoft Agent Framework (MAF)** (`Microsoft.Agents.AI.OpenAI`).

The agent is stateless — each request runs a fresh `RunAsync` cycle with no conversation memory between calls. It is given a system prompt contextualizing it as a medical clinic assistant aimed at receptionists, and always responds in Brazilian Portuguese.

### Tool Use

The agent has access to one registered tool:

| Tool | Description |
|---|---|
| `GetAllAppointmentsAsync` | Lists all appointments. Invoked when the user asks about scheduled appointments. |

Tools are exposed via `AIFunctionFactory.Create()` and decorated with `[Description]` so the model can decide when to invoke them.

### Endpoint

| Method | Route | Auth | Description |
|---|---|---|---|
| `POST` | `/api/agent/ask` | JWT — `Admin` role | Sends a prompt to the agent and returns its response |

**Request body:**
```json
{ "userInput": "Quais consultas estão agendadas?" }
```

**Response:**
```json
{ "response": "Aqui estão todas as consultas agendadas: ..." }
```

---

## API Endpoints

Full interactive documentation is available via **Scalar** at `/scalar/v1`.

### Authentication

| Method | Route | Description |
|---|---|---|
| `POST` | `/api/auth/login` | Authenticate and receive a JWT token |

### AI Agent

| Method | Route | Description |
|---|---|---|
| `POST` | `/api/agent/ask` | Send a prompt to the AI agent (Admin only) |

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
