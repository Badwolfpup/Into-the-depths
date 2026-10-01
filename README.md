# Into the Depths

A turn-based dungeon crawler RPG for Windows, built with C#, WPF and .NET 10. Lead a party of four heroes through a procedurally generated labyrinth.

Currently being rebuilt from scratch. The original prototype is available at the `legacy-prototype` tag.

## Tech

- C# / WPF / .NET 10
- MVVM with CommunityToolkit.Mvvm, dependency injection via the .NET Generic Host
- SQLite via EF Core for save games; JSON for game content
- xUnit v3 + FluentAssertions

## Structure

```
src/IntoTheDepths.Core    game rules and models
src/IntoTheDepths.Data    saves and content loading
src/IntoTheDepths.Wpf     user interface
tests/IntoTheDepths.Tests tests
assets/                   art and fonts
```

## Build and Run

Requires the .NET 10 SDK (or Visual Studio 2026).

```bash
dotnet build IntoTheDepths.slnx
dotnet run --project src/IntoTheDepths.Wpf
```
