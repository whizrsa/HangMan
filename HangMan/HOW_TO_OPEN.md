# ?? OPEN THE GAME - Visual Step-by-Step Guide

## Current Status
? The project file needs WPF references  
? All new game files are created and ready  
? You're almost there!

---

## ?? Quick Method (Recommended)

### Option 1: Use the Batch Script

1. **Close Visual Studio completely**
2. Navigate to: `C:\Users\Elvis\source\repos\HangMan\HangMan\`
3. **Double-click `OpenGame.bat`**
4. Follow the on-screen instructions

The script will:
- Check if VS is closed
- Backup your current .csproj
- Check if WPF references exist
- Open the necessary files for you
- Or launch the game if already configured

---

## ?? Manual Method (If you prefer)

### Step 1: Close Visual Studio
- **File ? Exit** or just close all Visual Studio windows
- Make sure it's completely closed

### Step 2: Update the Project File

1. Open Windows Explorer
2. Navigate to: `C:\Users\Elvis\source\repos\HangMan\HangMan\`
3. You'll see these files:
   ```
   ?? HangMan/
   ??? ?? HangMan.csproj          ? This needs updating
   ??? ?? PROJECT_UPDATE_GUIDE.txt ? Instructions here
   ??? ?? OpenGame.bat            ? Or use this script
   ??? ?? Models/
   ??? ?? Services/
   ??? ?? ViewModels/
   ??? ?? Views/
   ??? ... more files
   ```

4. **Right-click `PROJECT_UPDATE_GUIDE.txt`** ? Open
5. **Scroll down to the XML section** (starts with `<?xml version="1.0"`)
6. **Select ALL the XML** (from `<?xml` to `</Project>`)
7. **Copy it** (Ctrl+C)

8. **Right-click `HangMan.csproj`** ? Open With ? Notepad
9. **Select ALL** (Ctrl+A)
10. **Paste** (Ctrl+V) - This replaces everything
11. **Save** (Ctrl+S)
12. **Close Notepad**

### Step 3: Reopen Visual Studio

1. Navigate to: `C:\Users\Elvis\source\repos\HangMan\`
2. **Double-click `HangMan.sln`**
3. Wait for Visual Studio to load

### Step 4: Clean Up Old Files (Optional)

In Solution Explorer, you might see:
- `Form1.cs` ? Old Windows Forms file
- `Form1.Designer.cs` ? Old file
- `Form1.resx` ? Old file
- `Program.cs` ? Old file (WPF uses App.xaml.cs)

**Right-click each** ? **Remove** (not Delete - keep them just in case)

### Step 5: Build the Project

- Press **Ctrl+Shift+B** or
- Click **Build ? Rebuild Solution**
- Check the Output window - should say "Build succeeded"

### Step 6: Run the Game! ??

- Press **F5** or
- Click **Debug ? Start Debugging** or
- Click the green ?? Start button

---

## ?? What You Should See

### When It Works:
1. **Beautiful gradient start screen** (blue colors)
2. **"HANGMAN" title** at the top
3. **Category dropdown** (Animals, Movies, etc.)
4. **Difficulty dropdown** (Easy, Medium, Hard)
5. **High Scores panel** (might be empty first time)
6. **START GAME button** (green)
7. **Sound and Exit buttons** at bottom

### Then:
- Click **START GAME**
- **Game screen appears** with purple gradient
- **Hangman gallows** on the left
- **Word with underscores** in the center
- **A-Z keyboard** at the bottom
- Click letters or type to play!

---

## ? Troubleshooting

### "Build Failed - WindowsBase not found"
? You haven't updated the .csproj file yet. Go back to Step 2.

### "App.xaml not found"
? Make sure App.xaml exists in the HangMan folder. It should have been created.

### "Type GameViewModel not found"
? Build the project first (Ctrl+Shift+B), then run it.

### Old Form1 window appears
? You still have the old Program.cs as startup. Remove it and rebuild.

### Nothing happens when I press F5
? Check the Error List window (View ? Error List) for build errors.

---

## ? Success Indicators

You know it's working when:
- ? Beautiful gradient background
- ? Modern card-style UI
- ? Dropdown menus for category/difficulty
- ? On-screen keyboard (A-Z buttons)
- ? Hangman drawing appears
- ? No errors or crashes

---

## ?? Quick Reference

**Project Location:**
```
C:\Users\Elvis\source\repos\HangMan\HangMan\
```

**Solution File:**
```
C:\Users\Elvis\source\repos\HangMan\HangMan.sln
```

**Files to Update:**
```
HangMan.csproj (replace entire content)
```

**Files to Run:**
```
OpenGame.bat (automated helper)
or
HangMan.sln (manual method)
```

---

## ?? Once It's Running

Play a few games to test:
1. Try different **categories**
2. Try different **difficulties**
3. **Win** a game
4. **Lose** a game
5. Check **high scores** persist
6. Test the **mute button**
7. Try **keyboard typing**
8. Try **on-screen buttons**
9. **Resize the window**

---

## ?? More Help

- **Full features**: See `README.md`
- **Design details**: See `DESIGN_GUIDE.md`
- **Checklist**: See `CHECKLIST.md`
- **Summary**: See `UPGRADE_SUMMARY.md`

---

**?? Have Fun!**

Your modern Hangman game is ready to play. Just update that one file and you're good to go!
