# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
dotnet build "Into the depths.sln"
dotnet run --project "Into the depths/Into the depths.csproj"
```

No test infrastructure exists. No CI/CD configuration.

## Project Overview

Turn-based dungeon crawler RPG built with **C# / WPF / .NET 10** (Windows-only). A party of four heroes navigates a procedurally generated 8x8 labyrinth, encountering monsters room by room. Uses **Newtonsoft.Json** for save file serialization.

## Architecture

**Navigation model**: `MainWindow` swaps its `Content` property between WPF `Page` objects (`StartPage` → `CharacterCreation` → main game `Grid`). No `Frame` or `NavigationService`.

**Data binding**: Hybrid MVVM-adjacent. `MainWindow` acts as the primary ViewModel (implements `INotifyPropertyChanged`). Model classes also implement `INotifyPropertyChanged` for two-way XAML binding.

**Key classes**:
- `MainWindow` — root window, game state host, keyboard navigation (arrow keys for movement, 1-4 for combat actions)
- `Labyrinth` — procedural 8x8 map generation with recursive connectivity check (enforces min 15 rooms)
- `Room` / `BaseEvent` — per-cell room with random descriptions and events (`Enemy`, `Chest`)
- `Character` — base player character with stats and equipment; subclassed by `Warrior`, `Paladin`, `Priest`, `Mage`, `Ranger`, `Rogue` (all in `Classes/`)
- `BaseMonster` — monster base with same stat schema as Character; monsters in `MonsterClasses/Monster/`
- `BaseEquipment` — equipment base with stat bonuses; 10 slot types in `Items/Equipment/`
- `SaveParty` — static JSON save/load to `Savefiles/` using `TypeNameHandling.All` for polymorphism
- `Combat` — static combat logic (currently a stub)

## Critical Patterns

**Reflection-based type discovery**: Both monster selection (`Enemy.SelectMonster()`) and equipment generation (`BaseEquipment.GenerateEquipment()`) scan `.cs` files at runtime from the source tree and use `Type.GetType()` + `Activator.CreateInstance()`. New monster/equipment types are auto-discovered by adding a `.cs` file in the correct folder. This only works when running from the source tree, not from published builds.

**Reflection-based stat sync**: `Character.AddStatsFromStartingEquipment()` and `ChangeEquipment()` match property names between equipment and character via `PropertyInfo`. Adding a new stat to equipment requires a matching property name on the `Character` class.

## Incomplete Areas

- `Combat.MeleeCombat()` — empty method body
- Combat action keys 1-4 — handler stubs with no logic
- `Chest` event — empty class
- `BaseMonster.AdjustForLevel()` — stub
- Options pane and Bag/inventory pane — placeholders
- Character classes all share identical base stats (no differentiation yet)
