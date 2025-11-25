# Hangman Game - Product Requirements Document

## Overview
A modern, desktop word-guessing game built with WPF and .NET Framework 4.7.2, featuring a clean horizontal layout, multiple categories, difficulty levels, and high score tracking.

---

## Product Vision
Create an engaging, visually appealing Hangman game that provides entertainment while maintaining a professional, modern user interface suitable for all age groups.

---

## Technical Specifications

### Platform
- **Framework**: .NET Framework 4.7.2
- **UI Technology**: WPF (Windows Presentation Foundation)
- **Language**: C# 7.3
- **Architecture**: MVVM (Model-View-ViewModel)

### System Requirements
- **OS**: Windows 7 SP1 or higher
- **Resolution**: Minimum 1000x600 pixels
- **.NET Framework**: 4.7.2 or higher

---

## Features

### Core Gameplay
- **Word Guessing**: Classic hangman mechanics with visual feedback
- **Keyboard Input**: Both on-screen virtual keyboard and physical keyboard support
- **Visual Progression**: 10-stage hangman drawing with progressive reveal
- **Letter Tracking**: Display of guessed letters (correct and incorrect)

### Categories (6 Total)
1. Animals
2. Movies
3. Technology
4. Countries
5. Sports
6. Food

### Difficulty Levels (3 Total)
1. **Easy**: 4-6 letter words
2. **Medium**: 7-9 letter words
3. **Hard**: 10+ letter words

### Scoring System
- **Base Score**: 100 points
- **Difficulty Bonus**: 
  - Easy: +50 points
  - Medium: +100 points
  - Hard: +150 points
- **Mistake Penalty**: -10 points per incorrect guess
- **Minimum Score**: 0 points

### High Score System
- **Persistent Storage**: XML-based storage in user's AppData folder
- **Display**: Top 5 high scores shown on start screen
- **Data Tracked**: Player name, score, category, difficulty, date

### Audio Features
- **Sound Effects**:
  - Correct guess sound
  - Incorrect guess sound
  - Win game sound
  - Lose game sound
- **Mute Toggle**: User can enable/disable all sounds

---

## User Interface

### Layout
- **Orientation**: Horizontal (optimized for widescreen displays)
- **Window Size**: 1000x600 pixels (default)
- **Minimum Size**: 900x600 pixels
- **Resizable**: Yes

### Screens

#### 1. Start Screen
**Layout**: Two-column design
- **Left Panel** (60%):
  - Game title
  - Category selector (dropdown)
  - Difficulty selector (dropdown)
  - START GAME button
  - Sound toggle button
  - EXIT button
- **Right Panel** (40%):
  - High scores list (Top 5)

#### 2. Game Screen
**Layout**: Two-column design with header and footer
- **Header**: Category, game title, difficulty display
- **Left Panel** (40%):
  - Hangman visual (gallows and figure)
  - Mistakes counter (X / 10)
- **Right Panel** (60%):
  - Word display with underscores
  - Incorrect guesses display
  - Virtual keyboard (A-Z, 9 columns)
- **Footer**: MAIN MENU and sound toggle buttons

#### 3. Game Over Screen
**Layout**: Centered overlay
- Win/Lose message
- Word reveal
- Score display
- PLAY AGAIN button
- MAIN MENU button

### Design System

#### Colors
- **Primary Blue**: #4A90E2 (buttons, accents)
- **Success Green**: #5CB85C (win states)
- **Danger Red**: #D9534F (lose states, mistakes)
- **Dark Gray**: #2C3E50 (headers, text)
- **Light Gray**: #ECEFF1 (keyboard buttons)
- **Background**: White and light gradients

#### Typography
- **Title**: 42px, Bold
- **Headers**: 24-28px, Bold
- **Body Text**: 14-16px, Regular/SemiBold
- **Word Display**: 32px, Bold
- **Keyboard Letters**: 20px, Bold

#### Button Styles
- **Rounded corners**: 8px radius
- **Hover states**: Darker shade of base color
- **Pressed states**: Even darker shade
- **Disabled states**: Gray with reduced opacity

---

## Data Storage

### High Scores
- **Location**: `%APPDATA%\HangmanGame\highscores.xml`
- **Format**: XML serialization
- **Structure**:
  ```xml
  <HighScore>
    <PlayerName>Player</PlayerName>
    <Score>150</Score>
    <Category>Animals</Category>
    <Difficulty>Hard</Difficulty>
    <DateAchieved>2024-01-15</DateAchieved>
  </HighScore>
  ```

### Word Database
- **Storage**: In-memory dictionaries
- **Organization**: By category and difficulty
- **Extensibility**: Easy to add new words/categories

---

## User Experience

### Success Criteria
- **Intuitive**: Users should understand how to play within 10 seconds
- **Responsive**: All interactions should feel immediate (<100ms)
- **Accessible**: Clear visual feedback for all actions
- **Forgiving**: Easy to recover from accidental clicks

### Error Handling
- **Duplicate Guesses**: Silently ignored (no penalty)
- **Invalid Input**: Physical keyboard filters non-letter keys
- **File I/O Errors**: Graceful degradation (empty high scores)

---

## Performance Requirements
- **Startup Time**: < 2 seconds
- **Response Time**: < 100ms for all user interactions
- **Memory Usage**: < 100MB RAM
- **CPU Usage**: < 5% during idle, < 15% during gameplay

---

## Accessibility
- **Keyboard Navigation**: Full support for keyboard-only play
- **Font Sizes**: Large, readable text throughout
- **Color Contrast**: WCAG 2.1 AA compliant
- **Sound**: Optional (can be muted)

---

## Future Enhancements (Not in Current Scope)
- Custom word lists
- Multiplayer mode
- Hints system
- Achievements/badges
- Theme customization
- Additional languages
- Timed challenges
- Statistics tracking

---

## Version History
- **v1.0.0**: Initial release with core features
  - 6 categories
  - 3 difficulty levels
  - High score tracking
  - Sound effects
  - Modern horizontal UI

---

## Support & Maintenance
- **Bug Reports**: Via GitHub Issues
- **Updates**: Check repository for new releases
- **Documentation**: README.md and inline code comments
