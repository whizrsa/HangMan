# ?? Modern WPF Hangman Game

## Overview
This is a complete transformation of your Windows Forms Hangman game into a modern, polished WPF application using MVVM architecture.

## ? Features Implemented

### 1. **Modern UI Design**
- Clean, responsive layout with gradient backgrounds
- Card-based design with drop shadows
- Smooth animations and hover effects
- Professional color scheme and typography

### 2. **Word Categories**
- Animals (Elephant, Giraffe, Tiger, etc.)
- Movies (Inception, Avatar, Titanic, etc.)
- Technology (Computer, Software, Algorithm, etc.)
- Countries (Australia, Brazil, Japan, etc.)
- Sports (Football, Basketball, Tennis, etc.)
- Food (Pizza, Sushi, Chocolate, etc.)

### 3. **Difficulty Levels**
- **Easy**: Words with 6 letters or less
- **Medium**: Words with 7-9 letters
- **Hard**: Words with 10+ letters

### 4. **Visual Hangman Progression**
- Custom drawn hangman using Canvas and Shapes
- Progressive display (head, body, arms, legs)
- Color-coded mistake counter
- Up to 10 incorrect guesses allowed

### 5. **Score System**
- Base score: 100 points
- Difficulty bonus: Easy (+0), Medium (+50), Hard (+100)
- Mistake penalty: -10 points per wrong guess
- High score tracking with XML persistence

### 6. **Sound Effects**
- Correct guess sound
- Incorrect guess sound
- Win celebration sound
- Lose game sound
- Mute/unmute toggle button

### 7. **MVVM Architecture**
- Clean separation of concerns
- ViewModels for business logic
- Models for data structures
- Services for reusable functionality
- Data binding throughout

### 8. **Responsive Design**
- Minimum window size: 800x600
- Maximum flexibility for larger screens
- Viewbox for hangman scaling
- UniformGrid for keyboard layout

## ??? Architecture

```
HangMan/
??? Models/
?   ??? Difficulty.cs          - Difficulty enum (Easy, Medium, Hard)
?   ??? WordCategory.cs        - Category enum (Animals, Movies, etc.)
?   ??? GameState.cs           - Game state management
?   ??? HighScore.cs           - High score data model
??? Services/
?   ??? WordService.cs         - Word management and selection
?   ??? SoundService.cs        - Sound effect management
?   ??? HighScoreService.cs    - High score persistence (XML)
??? ViewModels/
?   ??? ViewModelBase.cs       - Base class with INotifyPropertyChanged
?   ??? RelayCommand.cs        - Command pattern implementation
?   ??? GameViewModel.cs       - Main game logic and state
??? Views/
?   ??? MainWindow.xaml(.cs)   - Main game window
??? Styles/
?   ??? ButtonStyles.xaml      - Modern button styles
?   ??? GameStyles.xaml        - Game-specific styles and brushes
??? Converters/
?   ??? BoolToVisibilityConverter.cs - Boolean to Visibility conversion
??? App.xaml(.cs)              - Application entry point
```

## ?? Setup Instructions

### Step 1: Update Project File
You need to manually edit `HangMan.csproj` to convert it from Windows Forms to WPF:

1. **Close Visual Studio**
2. Open `HangMan.csproj` in a text editor
3. Add this line in the first `<PropertyGroup>`:
   ```xml
   <ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
   ```

4. Update the `<ItemGroup>` with references to include WPF assemblies:
   ```xml
   <Reference Include="System.Xaml" />
   <Reference Include="WindowsBase" />
   <Reference Include="PresentationCore" />
   <Reference Include="PresentationFramework" />
   ```

5. Remove Windows Forms references:
   - Remove `System.Windows.Forms`
   - Remove `System.Drawing` (if only used for Forms)
   - Remove `System.Deployment`

6. Add the new files to the project:
   ```xml
   <ItemGroup>
     <ApplicationDefinition Include="App.xaml">
       <Generator>MSBuild:Compile</Generator>
       <SubType>Designer</SubType>
     </ApplicationDefinition>
     <Page Include="Views\MainWindow.xaml">
       <Generator>MSBuild:Compile</Generator>
       <SubType>Designer</SubType>
     </Page>
     <Page Include="Styles\ButtonStyles.xaml">
       <Generator>MSBuild:Compile</Generator>
       <SubType>Designer</SubType>
     </Page>
     <Page Include="Styles\GameStyles.xaml">
       <Generator>MSBuild:Compile</Generator>
       <SubType>Designer</SubType>
     </Page>
   </ItemGroup>
   ```

### Step 2: Remove Old Files (Optional)
You can remove these old Windows Forms files:
- `Form1.cs`
- `Form1.Designer.cs`
- `Form1.resx`
- `Program.cs` (WPF uses App.xaml.cs instead)

### Step 3: Build and Run
1. Open the solution in Visual Studio
2. Build the project (Ctrl+Shift+B)
3. Run the application (F5)

## ?? How to Play

1. **Start Screen**
   - Select a word category (Animals, Movies, Technology, etc.)
   - Choose difficulty level (Easy, Medium, Hard)
   - View top 5 high scores
   - Click "START GAME"

2. **During Game**
   - Guess letters by clicking on-screen keyboard or typing
   - Watch the hangman appear with each wrong guess
   - Try to complete the word before 10 mistakes

3. **Game Over**
   - See your final score
   - High scores are automatically saved
   - Choose to play again or return to main menu

## ?? Customization Ideas

### Add Custom Sounds
Replace system sounds with custom WAV files:
```csharp
// In SoundService.cs
_correctSound = new SoundPlayer("Assets/Sounds/correct.wav");
_incorrectSound = new SoundPlayer("Assets/Sounds/wrong.wav");
```

### Add More Word Categories
Edit `WordService.cs` and add new categories to the dictionary:
```csharp
{
    WordCategory.Space,
    new List<string> { "GALAXY", "ASTEROID", "NEBULA", ... }
}
```

### Customize Colors
Edit `Styles/GameStyles.xaml` to change gradient colors:
```xml
<LinearGradientBrush x:Key="GameBackgroundBrush">
    <GradientStop Color="#YourColor1" Offset="0"/>
    <GradientStop Color="#YourColor2" Offset="1"/>
</LinearGradientBrush>
```

### Add Animations
Add storyboards to `MainWindow.xaml` for entrance/exit animations

## ?? Scoring System

- **Base Score**: 100 points
- **Easy Mode**: +0 bonus
- **Medium Mode**: +50 bonus
- **Hard Mode**: +100 bonus
- **Penalties**: -10 points per mistake

**Example**: Hard mode word with 3 mistakes = 100 + 100 - 30 = **170 points**

## ?? Data Storage

High scores are stored in:
```
%APPDATA%\HangmanGame\highscores.xml
```

The XML file contains:
- Player name
- Score
- Date achieved
- Difficulty level
- Category used

## ?? Troubleshooting

### Build Errors
- Make sure all WPF references are added to .csproj
- Verify .NET Framework 4.7.2 is installed
- Clean and rebuild solution

### Sounds Not Playing
- Check system volume
- Verify sound service initialization
- Test with system default sounds first

### High Scores Not Saving
- Check write permissions for AppData folder
- Verify XML serialization isn't being blocked

## ?? Future Enhancements

- [ ] Multiplayer mode
- [ ] Custom word list import
- [ ] Themed hangman graphics
- [ ] Achievement system
- [ ] Timer-based challenges
- [ ] Hint system (costs points)
- [ ] Background music
- [ ] Accessibility features (screen reader support)

## ?? License

This is a learning project - feel free to modify and use as you wish!

---

**Enjoy your modern Hangman game! ??**
