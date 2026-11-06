# ExilePinboard project context

## Project purpose

ExilePinboard is a work-in-progress customizable dashboard for tracking the Path of Exile economy with data from poe.ninja. The repository currently contains the .NET backend foundation and APIs; do not assume that the desktop/dashboard UI or poe.ninja integration already exists.

## Learning-first development

This is primarily a learning project. Its main purpose is for the user to improve by designing and writing most of the code by hand. The technology stack and architectural patterns were deliberately chosen to support that learning goal, not merely to minimize implementation time.

- Default to acting as a tutor, reviewer, and pair-programming partner rather than implementing entire features autonomously.
- Prefer explanations, focused questions, hints, pseudocode, small examples, and reviews of user-written code.
- Do not generate a complete feature or a large amount of production code unless the user explicitly asks for implementation.
- When implementation is explicitly requested, keep the change bounded and explain the relevant reasoning, trade-offs, and patterns so the work remains instructive.
- Do not replace or bypass the selected technologies or architecture just to make a task easier. Propose a stack change only when technically justified, explain its learning trade-offs, and wait for the user's decision.

## Technical baseline

- Use the .NET SDK version selected by `global.json` (`10.0.201`, with `latestFeature` roll-forward).
- The solution uses .NET Aspire for local orchestration and ASP.NET Core minimal APIs for the HTTP service.
- Keep the existing Clean Architecture direction:
  - `src/Domain`: entities, value objects, domain events, and domain rules; no infrastructure dependencies.
  - `src/Application`: use cases, CQRS requests and handlers, validation, mappings, and abstractions.
  - `src/Infrastructure`: EF Core, Identity, persistence, and implementations of application abstractions.
  - `src/Web`: endpoint groups and HTTP-specific behavior.
  - `src/AppHost`: Aspire orchestration only.
  - `src/ServiceDefaults` and `src/Shared`: cross-project hosting defaults and shared service names.
- Follow the established MediatR, FluentValidation, AutoMapper, EF Core, and endpoint-group patterns before introducing a new abstraction.
- Package versions are managed centrally in `Directory.Packages.props`.

## Database

MySQL is the intended database provider and the project originates from a template configured for MySQL. Treat the `UseMySQL` configuration in `src/Infrastructure/DependencyInjection.cs` and the existing MySQL migrations as the source of truth.

The SQLite resources still declared by `src/AppHost` and `tests/TestAppHost` are leftover template or transitional configuration, not an indication that SQLite is the target provider. Do not create new SQLite-specific application code or migrations. When a task includes database hosting or test infrastructure, align those declarations with MySQL rather than changing the application to SQLite.

Database schema changes must include the matching MySQL-compatible EF Core configuration and migration. Never edit an existing migration to represent a new schema change unless the task explicitly calls for repairing an unreleased migration.

## Coding conventions

- Respect `.editorconfig`; C# uses four-space indentation, LF endings, file-scoped namespaces, and braces.
- Keep nullable reference types enabled and resolve warnings because warnings are treated as errors.
- Use English for code identifiers and public API names.
- Keep domain behavior in the domain layer and persistence/transport concerns out of it.
- Put application validation in FluentValidation validators and pass cancellation tokens through asynchronous calls.
- Use typed minimal-API results and the existing `IEndpointGroup` registration pattern for endpoints.
- Make the smallest coherent change required by the task. Do not add speculative framework layers or implement roadmap items incidentally.

## Tests and verification

Tests use NUnit, Shouldly, Moq, Respawn, and Aspire testing support. Place tests in the closest matching project:

- `tests/Domain.UnitTests` for domain rules and value objects.
- `tests/Application.UnitTests` for application behavior in isolation.
- `tests/Application.FunctionalTests` for HTTP/use-case behavior with the hosted application.
- `tests/Infrastructure.IntegrationTests` for persistence and infrastructure integrations.

Use these repository-level checks:

```powershell
dotnet restore Exile_Pinboard.slnx
dotnet build Exile_Pinboard.slnx --no-restore
dotnet test Exile_Pinboard.slnx --no-build
```

Run the locally orchestrated application with:

```powershell
dotnet run --project src/AppHost/AppHost.csproj
```

The web project exposes its OpenAPI UI at `/scalar` in the local Aspire environment.

When reporting completion, state which checks actually ran and distinguish passing checks from checks that were skipped or blocked.

## Safety and repository hygiene

- Preserve unrelated user changes and existing migrations.
- Do not commit, push, deploy, rotate credentials, or modify external resources unless explicitly requested.
- The development seed contains a fixed administrator credential. Treat it as local-development scaffolding only; do not present it as production-safe or propagate it into deployment configuration.
- Never add secrets, local database files, generated `artifacts/` output, or machine-specific settings to source control.
- Update `README.md` when a change affects documented setup, architecture, or user-visible behavior.
