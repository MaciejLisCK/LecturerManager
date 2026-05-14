# LecturerManager – Agent Instructions

This is a portal that helps me manage my classes and students. Features include registering for attendance, submitting assignments, checking assignments, and more.
See [readme.md](readme.md) for full feature description and [TODO.md](TODO.md) for the active task list.

These rules apply to every task in this project unless explicitly overridden.
Bias: caution over speed on non-trivial work.

## Main rules

### Rule 1 — Think Before Coding
State assumptions explicitly. Ask rather than guess.
Push back when a simpler approach exists. Stop when confused.

### Rule 2 — Simplicity First
Minimum code that solves the problem. Nothing speculative.
No abstractions for single-use code.

### Rule 3 — Surgical Changes
Touch only what you must. Don't improve adjacent code.
Match existing style. Don't refactor what isn't broken.

### Rule 4 — Goal-Driven Execution
Define success criteria. Loop until verified.
Strong success criteria let Claude loop independently.

### Rule 5 — Use the model only for judgment calls
Use for: classification, drafting, summarization, extraction.
Do NOT use for: routing, retries, deterministic transforms.
If code can answer, code answers.

### Rule 6 — Token budgets are not advisory
Per-task: 4,000 tokens. Per-session: 30,000 tokens.
If approaching budget, summarize and start fresh.
Surface the breach. Do not silently overrun.

### Rule 7 — Surface conflicts, don't average them
If two patterns contradict, pick one (more recent / more tested).
Explain why. Flag the other for cleanup.

### Rule 8 — Read before you write
Before adding code, read exports, immediate callers, shared utilities.
If unsure why existing code is structured a certain way, ask.

### Rule 9 — Tests verify intent, not just behavior
Tests must encode WHY behavior matters, not just WHAT it does.
A test that can't fail when business logic changes is wrong.

### Rule 10 — Checkpoint after every significant step
Summarize what was done, what's verified, what's left.
Don't continue from a state you can't describe back.

### Rule 11 — Match the codebase's conventions, even if you disagree
Conformance > taste inside the codebase.
If you think a convention is harmful, surface it. Don't fork silently.

### Rule 12 — Fail loud
"Completed" is wrong if anything was skipped silently.
"Tests pass" is wrong if any were skipped.
Default to surfacing uncertainty, not hiding it.

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
