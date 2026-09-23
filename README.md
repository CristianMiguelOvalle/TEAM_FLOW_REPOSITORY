# TeamFlow

TeamFlow is a backend-focused project management platform built as a practical engineering project to explore modular API design, data access, persistence, and backend architecture with .NET.

The project is currently under active development. The first functional area being built is **Projects**, with additional modules for authentication, tasks, members, comments, and documents planned or scaffolded in the solution.

## Goals

TeamFlow is being developed to practice and demonstrate backend engineering concepts in a real codebase, including:

- REST API design with ASP.NET Core
- Dependency Injection and layered responsibilities
- EF Core with PostgreSQL
- Query composition, projection, filtering, and pagination
- Auditing and soft-delete rules at the persistence layer
- Database migrations through a dedicated migrator project
- Modular separation by business capability
- Dockerized local development and CI/CD as upcoming milestones

## Tech Stack

- **.NET 10 / C#**
- **ASP.NET Core Web API**
- **Entity Framework Core 10**
- **PostgreSQL**
- **Npgsql**
- **Swagger / OpenAPI**
- **Git / GitHub**

## Current Architecture

The Projects module currently follows this flow:

```text
HTTP Request
    |
    v
Projects.Api
    |
    v
Projects.Handlers
    |
    v
Projects.Repositories
    |
    v
TeamFlow.DB / EF Core
    |
    v
PostgreSQL
```

The solution also contains shared projects for cross-cutting concerns and DTOs, plus a dedicated database migrator.

```text
TeamFlow
|
+-- src/
|   +-- auth/
|   |   +-- Auth.Api
|   |   +-- TeamFlow.Auth.Handlers
|   |   +-- TeamFlow.Auth.Repositories
|   |
|   +-- project/
|   |   +-- TeamFlow.Projects.Api
|   |   +-- TeamFlow.Projects.Handlers
|   |   +-- TeamFlow.Projects.Repositories
|   |
|   +-- document/
|   |   +-- TeamFlow.Documents.Api
|   |
|   +-- common/
|   |   +-- TeamFlow.Common
|   |   +-- TeamFlow.Common.Dto
|   |
|   +-- db/
|       +-- TeamFlow.DB
|       +-- TeamFlow.Migrator
|
+-- TeamFlow.slnx
```

## Domain Model

The persistence model currently includes:

- `Project`
- `ProjectTask`
- `ProjectMember`
- `User`
- `Comment`

Examples of modeled relationships include:

- Project `1:N` ProjectTask
- Project `1:N` ProjectMember
- User `1:N` ProjectMember
- ProjectTask `1:N` Comment
- User `1:N` Comment

`ProjectMember` is intended to represent the many-to-many relationship between users and projects while also storing membership information such as role.

## Projects API

The Projects module currently contains code for the following operations:

| Method | Endpoint | Purpose |
|---|---|---|
| `GET` | `/api/v1/Projects/list` | Filtered and paginated project listing |
| `GET` | `/api/v1/Projects/{id}` | Get a project by ID |
| `POST` | `/api/v1/Projects` | Create a project |
| `PUT` | `/api/v1/Projects/{id}` | Update a project |
| `DELETE` | `/api/v1/Projects/{id}` | Soft-delete a project |
| `GET` | `/api/v1/Projects/{projectId}/tasks` | Get tasks associated with a project |

The repository layer uses LINQ/EF Core projections to map database entities to DTOs and contains reusable pagination infrastructure based on `IQueryable<T>`.

## Persistence Rules

`TeamFlowContext` centralizes persistence behavior that should not be repeated in every repository.

### Automatic IDs

Entities implementing `IEntity` receive a new `Guid` when they are added and do not already have one.

### Auditing

Entities implementing `IAuditableEntity` automatically receive:

- `CreatedDate` when added
- `LastUpdatedDate` when modified

### Soft Delete

Entities implementing `IDeleteFlagEntity` contain an `IsDelete` flag. The project is being structured so deleted records can be excluded through EF Core global query filtering instead of being physically removed from the database.

## Pagination

TeamFlow includes reusable pagination models:

```text
PaginationRequest<T>
    -> filters
    -> page
    -> page size

IQueryable<T>
    -> CountAsync
    -> Skip
    -> Take
    -> ToListAsync

PaginationResult<T>
    -> list
    -> total records
    -> page count
```

This keeps filtering and pagination in the generated SQL instead of materializing the complete dataset first.

## Database Migrator

`TeamFlow.Migrator` is a console project responsible for applying EF Core migrations and exiting.

Conceptually:

```text
TeamFlow.Migrator
      |
      v
TeamFlowContext
      |
      v
Database.MigrateAsync()
      |
      v
PostgreSQL
```

This keeps database migration execution separate from the HTTP APIs.

## Getting Started

### Prerequisites

- .NET 10 SDK
- PostgreSQL
- Git

### 1. Clone the repository

```bash
git clone https://github.com/CristianMiguelOvalle/TEAM_FLOW_REPOSITORY.git
cd TEAM_FLOW_REPOSITORY
```

### 2. Configure the database connection

Configure `TeamFlowConnection` locally using environment variables or .NET user secrets rather than committing credentials to the repository.

Example configuration shape:

```json
{
  "ConnectionStrings": {
    "TeamFlowConnection": "Host=localhost;Port=5432;Database=TeamFlow;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

### 3. Restore packages

```bash
dotnet restore
```

### 4. Apply database migrations

Once migrations are available for the current model, run the migrator project:

```bash
dotnet run --project src/db/TeamFlow.Migrator
```

### 5. Run the Projects API

```bash
dotnet run --project src/project/TeamFlow.Projects.Api
```

When running in Development, Swagger UI is enabled by the API configuration.

> The repository is under active development, so setup steps may evolve as Docker, migrations, authentication, and additional modules are completed.

## Current Development Status

### Implemented / in progress

- [x] Modular .NET solution structure
- [x] Projects API, handler, and repository layers
- [x] PostgreSQL integration through EF Core/Npgsql
- [x] Core project-management entities
- [x] Project create/read/update/delete flow in code
- [x] Project filtering and pagination infrastructure
- [x] Project task DTOs and project-task retrieval
- [x] Automatic audit timestamps
- [x] Automatic Guid assignment for new entities
- [x] Soft-delete contracts and persistence scaffolding
- [x] Dedicated database migrator project
- [x] Swagger/OpenAPI setup
- [x] Custom request-logging middleware experiment

### Next milestones

- [ ] Stabilize and complete EF Core entity configurations/global soft-delete filtering
- [ ] Add and maintain EF Core migrations
- [ ] Complete ProjectTask CRUD
- [ ] Implement project membership and comments workflows
- [ ] Implement authentication and authorization
- [ ] Complete Documents module
- [ ] Dockerize the APIs and PostgreSQL environment
- [ ] Add Docker Compose for reproducible local development
- [ ] Add automated tests
- [ ] Add CI/CD pipeline

## Engineering Approach

TeamFlow is intentionally being built incrementally rather than adding architectural patterns only for complexity. New abstractions are introduced when there is a concrete problem to solve, with the goal of understanding the trade-offs behind each technical decision.

The current architecture separates HTTP concerns, application orchestration, persistence, and database infrastructure while keeping the implementation small enough to evolve as the project grows.

## Repository Status

This repository is a work in progress and is being used as both a portfolio project and a hands-on backend engineering laboratory. Features, architecture, and documentation will continue to evolve alongside the implementation.
