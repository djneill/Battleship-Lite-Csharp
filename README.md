# Battleship Lite

A console-based implementation of the classic Battleship game built in C# with .NET 9.0.

## Overview

Battleship Lite is a two-player turn-based strategy game where players place ships on a 5x5 grid and take turns trying to sink each other's fleet. The game features a clean architecture with separated game logic and console interface.

## Features

- **Two-player gameplay** - Local multiplayer on the same console
- **5x5 game grid** - Simplified from the traditional larger grid
- **Ship placement** - Each player places 5 ships on their grid
- **Turn-based combat** - Players alternate taking shots
- **Hit/Miss tracking** - Visual feedback with X (hit) and O (miss) markers
- **Win condition** - First player to sink all opponent ships wins
- **Shot counter** - Tracks efficiency with total shots taken

## Project Structure

```
BattleshipLiteLibrary/
├── BattleshipLite/                 # Console application
│   ├── Program.cs                  # Main entry point and game orchestration
│   └── Services/                   # UI and game flow services
│       ├── GameDisplayService.cs   # Display and visual output
│       ├── GameFlowService.cs      # Game turn management
│       ├── PlayerSetupService.cs   # Player creation and setup
│       └── UserInputService.cs     # User input handling
├── BattleshipLiteLibrary/          # Game logic library
│   ├── Logic/
│   │   └── GameLogic.cs           # Core game mechanics
│   └── Models/
│       ├── GridSpotModel.cs       # Grid position model
│       ├── PlayerInfoModel.cs     # Player data model
│       └── Enums.cs              # Game state enums
└── BattleshipLiteLibrary.slnx     # Solution file
```

## Requirements

- **.NET 9.0** or later
- **Console/Terminal** for gameplay

## Installation & Setup

1. **Clone the repository:**

   ```bash
   git clone <repository-url>
   cd battleshiplitelibrary
   ```

2. **Build the solution:**

   ```bash
   dotnet build
   ```

3. **Run the game:**
   ```bash
   dotnet run --project BattleshipLite
   ```

## How to Play

1. **Game Start** - Welcome screen appears
2. **Player Setup** - Both players enter their names
3. **Ship Placement** - Each player places 5 ships using grid coordinates (e.g., "A1", "B3")
4. **Combat Phase** - Players alternate taking shots at opponent's grid
5. **Victory** - Game ends when all of one player's ships are sunk

### Grid Coordinates

- **Letters:** A-E (rows)
- **Numbers:** 1-5 (columns)
- **Example:** "C3" targets row C, column 3

### Visual Indicators

- **Empty spots:** Display as grid coordinates (A1, B2, etc.)
- **Hits:** Marked with "X"
- **Misses:** Marked with "O"

## Architecture

### Clean Separation of Concerns

- **BattleshipLite** - Console UI and user interaction orchestration
  - **Services** - Organized service layer for different UI concerns
- **BattleshipLiteLibrary** - Pure game logic and data models
  - **Models** - Data structures for game state
  - **Logic** - Game rules and mechanics

### Key Classes

**Core Game Logic:**
- `GameLogic` - Core game mechanics and validation
- `GridSpotModel` - Represents individual grid positions
- `PlayerInfoModel` - Stores player data and game state
- `Enums` - Grid spot status definitions

**Service Layer:**
- `GameDisplayService` - Handles all visual output and screen management
- `UserInputService` - Manages user input collection and validation
- `PlayerSetupService` - Orchestrates player creation and ship placement
- `GameFlowService` - Controls turn-based game flow and shot processing

## Planned Improvements

This project is being actively refactored and enhanced:

- [ ] Refactor console logic into organized folders/classes
- [ ] Add new gameplay features
- [ ] Improve code organization and maintainability
- [ ] Enhanced user interface

## Development Notes

- Built with modern C# features including nullable reference types
- Uses tuple deconstruction for coordinate parsing
- Implements clean game loop architecture
- Follows .NET naming conventions and best practices

## License

This project is created for educational purposes.

---

**Created by DJ Neill**

_A classic naval strategy game_
