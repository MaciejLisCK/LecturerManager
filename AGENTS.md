# LecturerManager – Agent Instructions

This is a portal that helps me manage my classes and students. Features include registering for attendance, submitting assignments, checking assignments, and more.
See [readme.md](readme.md) for full feature description and [TODO.md](TODO.md) for the active task list.

## Architecture

**Clean Architecture + CQRS + DDD** on .NET 10 + Angular 20 + SQL Server.

```
Domain ← Application ← Infrastructure
                  ↑
                 Api  ←→  Angular frontend
```

| Project | Purpose |
|---|---|
| `LecturerManager.Domain` | Entities, Value Objects, Domain Events, Domain Exceptions, Repository interfaces |
| `LecturerManager.Application` | MediatR Commands/Queries/Handlers, FluentValidation validators, DTOs |
| `LecturerManager.Infrastructure` | EF Core DbContext, Repository implementations, UnitOfWork, interceptors |
| `LecturerManager.Api` | Minimal API endpoints, global exception handler, DI wiring |
| `lecturer-manager-frontend/` | Angular 20 standalone components + signals SPA |

See [structure.txt](structure.txt) for the canonical folder layout.

## Build & Run

```bash
# Build backend
dotnet build LecturerManager.Api/LecturerManager.Api.csproj

# Run API (listens on http://localhost:5268)
dotnet run --project LecturerManager.Api/LecturerManager.Api.csproj

# Serve frontend (http://localhost:4200)
cd lecturer-manager-frontend && ng serve
```

EF Core migrations — use VS Code tasks: `ef-add-migration`, `ef-update-database`, `ef-remove-last-migration`.

## Backend Conventions

### CQRS (MediatR)

Every feature lives in `Application/Features/<BoundedContext>/Commands/<Name>/` or `.../Queries/<Name>/`:

```
CreateCourseCommand.cs  → record CreateCourseCommand(string Name) : IRequest<Guid>;
CreateCourseHandler.cs  → class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Guid>
```

- Commands/Queries are `record`s.
- Handlers use **primary constructor injection** (`(IRepo repo, IUnitOfWork uow)`).
- `ValidationBehavior<TRequest,TResponse>` pipeline behavior runs FluentValidation before every handler.
- MediatR registered via assembly scan in `AddApplication()`.

### Domain Layer

- **Bounded contexts**
- **Aggregate roots** implement `IAggregateRoot`; mutations only through aggregate methods.
- **Value Objects** are `record`s with validated constructors throwing `DomainXxxException`.
- **Domain Events** implement `IDomainEvent`; published by `DomainEventPublishingInterceptor` after `SaveChangesAsync`.
- Map Value Objects to DTOs inside Application handlers — **never expose Value Object types in API responses**.

### EF Core

- `DbSet`s only for top-level aggregates.
- Configurations in `Persistence/Configurations/` via `IEntityTypeConfiguration<T>`.
- Guid PKs use `ValueGeneratedNever()` (app-generated).
- Value Objects stored flat: `OwnsOne(x => x.Name, b => b.Property(x => x.Value).HasColumnName("Name"))`.
- Private collection fields: `UsePropertyAccessMode(PropertyAccessMode.Field)`.

### Minimal API Endpoints

```csharp
public static class CourseEndpoints
{
    public static IEndpointRouteBuilder MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/courses", async (ISender sender, CancellationToken ct) => ...);
        return app;
    }
}
```

- No controllers. `ISender` injected directly into lambdas.
- REST-style nested routes: `/courses/{courseId}/assignments/{assignmentId}/items`.
- Decorate with `.WithName()`, `.WithTags()`, `.Produces<T>()`.
