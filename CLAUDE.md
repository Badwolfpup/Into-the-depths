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

Turn-based dungeon crawler RPG, **C# / WPF / .NET 10**, Windows-only, fully offline. A party of four heroes travels through procedurally generated levels, each reached via a portal.

**Presentation:** first-person grid crawler ("blobber" style, like Eye of the Beholder) — step-by-step movement with 90° turns, the view built from layered 2D wall images per depth/offset, animations via WPF `Storyboard`. Icon-driven UI rather than text-driven. Core computes what is visible from the party's position + facing; Wpf only maps that to images.

The project is being rebuilt from scratch as a learning exercise in setting up a .NET solution properly. The original prototype is preserved at git tag `legacy-prototype`; reusable art and fonts were moved to `assets/` and get pulled into the WPF project as the UI is built.

## Game Design (current vision — expected to evolve)

- **Levels:** each level has one exit portal leading to the next level; `Depth` increases by one per portal and drives difficulty. No going back. Each level has an environment theme (crypt, forest, ...) defined in JSON content: wall art set, monster pool, special events. Levels are generated on entry and **not persisted**; saves only hold the current level + party.
- **Party:** four heroes. Classes not decided yet.
- **Events:** every event (combat, chest, trap, ...) switches to its own event-specific screen, JRPG-style; the corridor view is hidden during events.
- **Combat:** Active Time Battle — each combatant has a gauge/timer between actions; time keeps running (no pause when a hero is ready, no pause in menus). Auto-pause only when the window loses focus, shown with a modal overlay.
  - The player controls one hero at a time and may swap freely (optional); the others act via AI. A player-controlled hero whose gauge is full waits for input. Optional full auto mode puts AI on all four heroes, with a penalty (TBD).
  - Every combatant has a controller (`PlayerController` / `AiController`) — swapping heroes swaps controllers.
  - AI is utility-based (score all possible actions, pick one). A decision-quality stat controls how reliably the best-scored action is chosen. Monsters use the same AI; monster decision quality is a difficulty lever per depth. AI is not player-configurable.
  - Core never owns a timer: it exposes `Advance(TimeSpan elapsed)` returning what happened; Wpf drives the clock and stops calling it to pause.

## Build Order

1. Dungeon in Core: level generation, exit portal, position/facing, relative movement, visibility calculation
2. Exploration screen: first-person view (placeholder art), movement, shell navigation, first DI wiring (user writes DI with guidance)
3. Event system + one simple event (chest) with its own screen
4. Party: heroes, stats, JSON content (classes, monsters, items)
5. Combat: ATB, controllers/swapping, utility AI
6. Saves: SQLite via EF Core

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
