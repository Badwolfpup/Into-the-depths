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
â”œâ”€â”€ Classes/              # Character classes (Character, Warrior, Mage, Paladin, Priest, Ranger, Rogue)
â”œâ”€â”€ Items/
â”‚   â””â”€â”€ Equipment/        # 10 equipment slot types
â”œâ”€â”€ MonsterClasses/       # Monster base class and types
â”œâ”€â”€ Rooms/                # Room and event system
â”œâ”€â”€ CharacterCreation.xaml  # Character creation screen
â”œâ”€â”€ StartPage.xaml        # Start menu
â”œâ”€â”€ MainWindow.xaml       # Main game UI
â”œâ”€â”€ Combat.cs             # Combat logic
â”œâ”€â”€ Labyrinth.cs          # Dungeon generation
â”œâ”€â”€ SaveParty.cs          # JSON save system
â””â”€â”€ Image/                # UI graphics and class icons
```

## How to Run

Open `Into the depths.sln` in Visual Studio and run the project.
