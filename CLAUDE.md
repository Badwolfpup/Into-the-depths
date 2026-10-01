# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
dotnet build IntoTheDepths.slnx
dotnet test --solution IntoTheDepths.slnx
dotnet run --project src/IntoTheDepths.Wpf
```

Tests run on Microsoft.Testing.Platform (opted in via `global.json`), so `dotnet test` needs `--solution` or `--project`.

## Project Overview

Turn-based dungeon crawler RPG, **C# / WPF / .NET 10**, Windows-only, fully offline. A party of four heroes explores a procedurally generated labyrinth room by room.

The project is being rebuilt from scratch as a learning exercise in setting up a .NET solution properly. The original prototype is preserved at git tag `legacy-prototype`; reusable art and fonts were moved to `assets/` and get pulled into the WPF project as the UI is built.

## Solution Layout

```
src/IntoTheDepths.Core    game rules, models, interfaces — no WPF, no EF Core
src/IntoTheDepths.Data    EF Core (SQLite) saves, JSON content loading — implements Core interfaces
src/IntoTheDepths.Wpf     views, view models, composition root (App.xaml.cs)
tests/IntoTheDepths.Tests xUnit v3 + FluentAssertions
```

**Dependency rule:** everything points inward to Core. Core references nothing. `tests/.../Architecture/CoreDependencyTests.cs` enforces this.

## Architecture Decisions

- **Composition root:** Generic Host (`Microsoft.Extensions.Hosting`) built in `App.xaml.cs`; services, view models and windows are registered there and resolved through DI. No `StartupUri`.
- **MVVM:** one view model per screen using CommunityToolkit.Mvvm; navigation via a shell view model swapping `CurrentViewModel` + `DataTemplate`s, not `Page`/`Frame`.
- **Game content** (classes, monsters, items) lives in JSON files shipped with the game, loaded at startup behind a Core interface (e.g. `IGameContent`). Content is referenced by stable string IDs (`"rat"`, `"iron_sword"`), never database-generated IDs. No plan to move content into the database.
- **Saves** go to SQLite via EF Core, database file under `%LocalAppData%\IntoTheDepths\`. Never write to the source tree or build output.

## Build Configuration

- `Directory.Build.props` — shared properties (nullable, implicit usings) for all projects.
- `Directory.Packages.props` — Central Package Management: all NuGet versions live here; `.csproj` files reference packages without versions. Meziantou.Analyzer and SonarAnalyzer.CSharp are applied to every project as `GlobalPackageReference`.
- `global.json` — pins the .NET SDK and opts into Microsoft.Testing.Platform.
