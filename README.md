# Into the Depths

A WPF dungeon crawler RPG with character creation, multiple classes, an equipment system, and procedurally generated dungeons.

## Technologies

- C#, WPF (XAML), .NET, JSON serialization

## Features

- **6 character classes** - Warrior, Mage, Paladin, Priest, Ranger, Rogue with unique stats
- **Character creation** screen with class selection and icons
- **Equipment system** with 10 slots (Head, Shoulder, Chest, Arm, Hand, Legs, Feet, MainHand, OffHand, Neck)
- **Combat system** with turn-based battles
- **Labyrinth generation** with room events (chests, enemies)
- **Save/Load** system with JSON serialization
- **Custom UI** with themed buttons and backgrounds

## Project Structure

```
Into the depths/
+-- Classes/              # Character classes (Character, Warrior, Mage, Paladin, Priest, Ranger, Rogue)
+-- Items/
|   +-- Equipment/        # 10 equipment slot types
+-- MonsterClasses/       # Monster base class and types
+-- Rooms/                # Room and event system
+-- CharacterCreation.xaml  # Character creation screen
+-- StartPage.xaml        # Start menu
+-- MainWindow.xaml       # Main game UI
+-- Combat.cs             # Combat logic
+-- Labyrinth.cs          # Dungeon generation
+-- SaveParty.cs          # JSON save system
+-- Image/                # UI graphics and class icons
```

## How to Run

Open `Into the depths.sln` in Visual Studio and run the project.
