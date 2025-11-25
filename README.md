# Hangman Game

A modern, desktop word-guessing game built with WPF and .NET Framework 4.7.2.

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple)
![License](https://img.shields.io/badge/license-MIT-green)

---

## Features

- **6 Word Categories**: Animals, Movies, Technology, Countries, Sports, Food
- **3 Difficulty Levels**: Easy (4-6 letters), Medium (7-9 letters), Hard (10+ letters)
- **Dynamic Scoring System**: Base points + difficulty bonus - mistake penalty
- **High Score Tracking**: Persistent top 5 scores with XML storage
- **Audio Feedback**: Sound effects for correct/incorrect guesses, wins, and losses
- **Modern Horizontal UI**: Optimized 1000x600 layout for widescreen displays
- **Full Keyboard Support**: Play with mouse clicks or physical keyboard
- **MVVM Architecture**: Clean separation of concerns with proper design patterns

---

## Screenshots

### Start Screen
- Category and difficulty selection
- Top 5 high scores display
- Sound toggle and exit options

### Game Screen
- Hangman visual with 10 progressive stages
- Word display with spaced letters/underscores
- Virtual A-Z keyboard
- Incorrect guesses tracker
- Real-time mistakes counter (0-10)

### Game Over Screen
- Win/lose message with word reveal
- Score display with breakdown
- Play again or return to main menu

---

## Installation

### Requirements
- **OS**: Windows 7 SP1 or higher
- **.NET Framework**: 4.7.2 or higher
- **Screen Resolution**: Minimum 900x600 pixels

### Download & Run
1. Download the latest release from [Releases](https://github.com/whizrsa/HangMan/releases)
2. Extract the ZIP file to your desired location
3. Run `HangMan.exe`

### Build from Source
```bash
# Clone the repository
git clone https://github.com/whizrsa/HangMan.git
cd HangMan

# Open in Visual Studio
# Open HangMan.sln in Visual Studio 2017 or later

# Build the solution
# Press Ctrl+Shift+B or Build ? Rebuild Solution

# Run the game
# Press F5 or Debug ? Start Debugging
```

---

## How to Play

1. **Select Category**: Choose from Animals, Movies, Technology, Countries, Sports, or Food
2. **Select Difficulty**: 
   - Easy: 4-6 letter words
   - Medium: 7-9 letter words
   - Hard: 10+ letter words
3. **Click START GAME**: Begin your word-guessing adventure
4. **Guess Letters**: 
   - Click virtual keyboard buttons
   - Or press keys on your physical keyboard
5. **Win or Lose**:
   - **Win**: Guess all letters before 10 mistakes
   - **Lose**: Make 10 incorrect guesses

### Scoring System
```
Final Score = Base Score (100) + Difficulty Bonus - Mistake Penalty

Difficulty Bonuses:
- Easy: +50 points
- Medium: +100 points
- Hard: +150 points

Mistake Penalty: -10 points per incorrect guess
Minimum Score: 0 points
```

**Example**: Hard word with 3 mistakes = 100 + 150 - 30 = **220 points**

---

## Technical Architecture

### Design Pattern
- **MVVM (Model-View-ViewModel)**: Complete separation of UI and business logic
- **Command Pattern**: ICommand implementation for all user actions
- **Service Layer**: Dedicated services for words, sounds, and high scores
- **Data Binding**: Two-way binding for real-time UI updates

### Project Structure
```
HangMan/
??? Models/              # Data models
?   ??? GameState.cs     # Game state management
?   ??? HighScore.cs     # High score data model
?   ??? WordCategory.cs  # Category enumeration
?   ??? Difficulty.cs    # Difficulty enumeration
??? ViewModels/          # Business logic layer
?   ??? GameViewModel.cs # Main game logic
?   ??? ViewModelBase.cs # Base ViewModel with INotifyPropertyChanged
?   ??? RelayCommand.cs  # ICommand implementation
??? Views/               # UI layer
?   ??? MainWindow.xaml  # Main game window
??? Services/            # Business services
?   ??? WordService.cs   # Word management and selection
?   ??? SoundService.cs  # Audio playback management
?   ??? HighScoreService.cs # Persistent score tracking
??? Converters/          # Data binding converters
?   ??? BoolToVisibilityConverter.cs
?   ??? GameConverters.cs
??? Styles/              # UI resource dictionaries
?   ??? ButtonStyles.xaml
?   ??? GameStyles.xaml
??? Assets/              # Images and sounds
    ??? Images/
    ??? Sounds/
```

### Key Technologies
- **WPF**: Modern Windows desktop UI framework
- **C# 7.3**: Latest language features for .NET Framework 4.7.2
- **XAML**: Declarative UI markup
- **XML Serialization**: High score persistence
- **Resource Dictionaries**: Centralized UI styling
- **Value Converters**: UI logic in data binding

---

## Development

### Prerequisites
- Visual Studio 2017 or higher
- .NET Framework 4.7.2 SDK
- Windows 7 SP1 or higher

### Setup Development Environment
```bash
# Clone the repository
git clone https://github.com/whizrsa/HangMan.git

# Navigate to project directory
cd HangMan

# Open solution
start HangMan.sln

# Restore NuGet packages (if any)
# Build ? Restore NuGet Packages

# Build solution
# Press Ctrl+Shift+B

# Run in debug mode
# Press F5
```

### Testing
```bash
# Run the application
# Press F5 in Visual Studio

# Test all features:
# - Category selection
# - Difficulty selection
# - Letter guessing (mouse and keyboard)
# - Sound effects
# - High score saving
# - Win/lose conditions
```

---

## Configuration

### High Score Storage
- **Location**: `%APPDATA%\HangmanGame\highscores.xml`
- **Format**: XML with serialized HighScore objects
- **Capacity**: Top 10 scores (displays top 5)

### Extending Word Lists
Edit `Services\WordService.cs` to add new words:
```csharp
_wordsByCategory[WordCategory.Animals] = new List<string>
{
    "ELEPHANT", "GIRAFFE", "PENGUIN", // Add more words here
};
```

---

## Contributing

Contributions are welcome! Please follow these guidelines:

1. **Fork the repository**
2. **Create a feature branch**: `git checkout -b feature/amazing-feature`
3. **Commit your changes**: `git commit -m 'Add amazing feature'`
4. **Push to the branch**: `git push origin feature/amazing-feature`
5. **Open a Pull Request**

### Contribution Ideas
See [TODO.md](TODO.md) for planned features:
- Player name input for high scores
- Word hint system
- Additional categories
- Statistics tracking
- Custom word lists
- Theme customization

---

## Documentation

- **[PRD.md](PRD.md)** - Complete Product Requirements Document
  - Feature specifications
  - UI/UX design system
  - Technical architecture
  - Data storage details
  
- **[TODO.md](TODO.md)** - Task Tracking and Roadmap
  - Completed features checklist
  - Future enhancements (prioritized)
  - Testing checklist
  - Code quality tasks

---

## License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

### What This Means
- ? **You CAN**: Use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
- ? **You MUST**: Include the copyright notice and license in all copies
- ? **No Warranty**: Software is provided "as is" without warranty of any kind

**Copyright © 2024 Elvis Whiz. All rights reserved.**

---

## Author

**Elvis Whiz**
- GitHub: [@whizrsa](https://github.com/whizrsa)
- Repository: [HangMan](https://github.com/whizrsa/HangMan)

---

## Acknowledgments

- Built with **WPF** (Windows Presentation Foundation)
- **.NET Framework 4.7.2**
- **MVVM** design pattern
- Inspired by the classic Hangman word game

---

## Version History

### v1.0.0 (2024) - Initial Release
- ? Core hangman gameplay mechanics
- ? 6 word categories with curated word lists
- ? 3 difficulty levels (Easy, Medium, Hard)
- ? Dynamic scoring system
- ? High score persistence (Top 10)
- ? Sound effects with mute toggle
- ? Modern horizontal UI (1000x600)
- ? Full keyboard and mouse support
- ? MVVM architecture
- ? Professional documentation (PRD + TODO)

---

## Support

### Bug Reports
If you find a bug, please:
1. Check existing [Issues](https://github.com/whizrsa/HangMan/issues)
2. Create a new issue with:
   - Clear description
   - Steps to reproduce
   - Expected vs actual behavior
   - Screenshots (if applicable)

### Feature Requests
Have an idea? Check the [TODO.md](TODO.md) first, then open an issue!

---

## Project Status

**Status**: ? **Active Development**
- Version: 1.0.0
- Last Updated: January 2024
- Maintained: Yes

---

**Star ? this repository if you found it helpful!**

**Enjoy playing Hangman!** ??
