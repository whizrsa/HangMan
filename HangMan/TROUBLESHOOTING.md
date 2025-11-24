# ?? Troubleshooting Guide - Why the Program Won't Run

## Quick Diagnostic Steps

### Step 1: Check Current Status
Open **View ? Error List** in Visual Studio and look for errors.

### Step 2: Common Issues and Fixes

#### Issue 1: "Cannot find App.xaml" or "Multiple Main() methods"
**Cause**: Old `Program.cs` from Windows Forms is still in the project

**Fix**:
1. In Solution Explorer, look for `Program.cs`
2. Right-click ? **Remove** (or Delete)
3. Rebuild (Ctrl+Shift+B)

#### Issue 2: "The name 'InitializeComponent' does not exist"
**Cause**: XAML files not properly generated

**Fix**:
1. **Build ? Clean Solution**
2. **Build ? Rebuild Solution**
3. Wait for completion
4. Try running again (F5)

#### Issue 3: "Could not load file or assembly"
**Cause**: Missing WPF references

**Fix**: Your .csproj already has these - should be fine. But if you see this:
1. Right-click project ? **Unload Project**
2. Right-click again ? **Reload Project**

#### Issue 4: Old Form1 window appears instead of new game
**Cause**: Old Form1 files still in project

**Fix**:
1. In Solution Explorer, find and remove:
   - `Form1.cs`
   - `Form1.Designer.cs`
   - `Form1.resx`
2. Rebuild solution

#### Issue 5: "StartupUri 'Views/MainWindow.xaml' not found"
**Cause**: MainWindow.xaml in wrong location or not created

**Fix**: MainWindow.xaml should be at `C:\Users\Elvis\source\repos\HangMan\HangMan\Views\MainWindow.xaml`

#### Issue 6: Build succeeds but nothing happens when you press F5
**Cause**: Wrong startup project or file

**Fix**:
1. Right-click `HangMan` project in Solution Explorer
2. Select **Set as StartUp Project**
3. Try F5 again

---

## Manual Verification Checklist

### ? Files That MUST Exist:
- [ ] `App.xaml` (in HangMan folder)
- [ ] `App.xaml.cs` (in HangMan folder)
- [ ] `Views\MainWindow.xaml`
- [ ] `Views\MainWindow.xaml.cs`
- [ ] `Styles\ButtonStyles.xaml`
- [ ] `Styles\GameStyles.xaml`
- [ ] All files in `Models\`, `Services\`, `ViewModels\`, `Converters\`

### ? Files That SHOULD NOT Exist (Remove These):
- [ ] `Program.cs` (Windows Forms entry point - conflicts with WPF)
- [ ] `Form1.cs` (old Windows Forms file)
- [ ] `Form1.Designer.cs` (old file)
- [ ] `Form1.resx` (old file)

---

## Step-by-Step Fix Process

### Method 1: Clean Build (Try This First)

1. **Clean Solution**
   - Menu: Build ? Clean Solution
   - Wait for completion

2. **Close All Files**
   - Menu: Window ? Close All Documents

3. **Rebuild**
   - Menu: Build ? Rebuild Solution
   - Check Output window for progress
   - Look for "Build succeeded" message

4. **Check for Errors**
   - Menu: View ? Error List
   - Should show 0 Errors

5. **Run**
   - Press F5 or click Start button
   - Wait for game window to appear

### Method 2: Remove Old Files

1. **In Solution Explorer**, look for these files:
   - `Program.cs`
   - `Form1.cs`
   - `Form1.Designer.cs`
   - `Form1.resx`

2. **For each file found**:
   - Right-click ? **Remove** (or Delete if you're sure)

3. **Rebuild**:
   - Ctrl+Shift+B

4. **Run**:
   - F5

### Method 3: Reload Project

1. **In Solution Explorer**:
   - Right-click `HangMan` project
   - Click **Unload Project**

2. **Wait a moment, then**:
   - Right-click `HangMan (unavailable)`
   - Click **Reload Project**

3. **Wait for it to load**

4. **Build and Run**:
   - Ctrl+Shift+B
   - Then F5

### Method 4: Reset Visual Studio (Nuclear Option)

1. **Close Visual Studio completely**

2. **Delete these folders** (they'll be regenerated):
   - `C:\Users\Elvis\source\repos\HangMan\HangMan\bin\`
   - `C:\Users\Elvis\source\repos\HangMan\HangMan\obj\`
   - `.vs` folder (hidden, in solution root)

3. **Reopen** `HangMan.sln`

4. **Rebuild All**:
   - Ctrl+Shift+B

5. **Run**:
   - F5

---

## How to Check Build Output

1. **Menu**: View ? Output
2. **Show output from**: Build
3. Look for messages like:
   ```
   1>------ Build started: Project: HangMan ------
   1> MainWindow.xaml -> MainWindow.g.cs
   1> App.xaml -> App.g.cs
   1> HangMan -> C:\...\HangMan\bin\Debug\HangMan.exe
   ========== Build: 1 succeeded, 0 failed ==========
   ```

4. If you see **"Build: 0 succeeded, 1 failed"**, scroll up to find the error

---

## Common Error Messages and Solutions

### "The type or namespace name 'GameViewModel' could not be found"
**Fix**: 
- Build ? Rebuild Solution
- Make sure `ViewModels\GameViewModel.cs` exists

### "The name 'InitializeComponent' does not exist in the current context"
**Fix**:
- Clean solution
- Delete `bin` and `obj` folders
- Rebuild

### "Cannot create instance of 'GameViewModel'"
**Fix**:
- Check that `GameViewModel.cs` has a public parameterless constructor
- The file already has this - should be fine

### "Resource 'Styles/ButtonStyles.xaml' not found"
**Fix**:
- Make sure files exist in `Styles` folder
- Check capitalization (case-sensitive in some contexts)

---

## What Should Happen When It Works

1. **Press F5**
2. **Window appears** (~1-2 seconds)
3. **You see**:
   - Beautiful blue gradient background
   - "?? HANGMAN" title (or similar - emojis might show as boxes)
   - Category dropdown
   - Difficulty dropdown
   - High Scores panel
   - START GAME button
   - Sound and Exit buttons

4. **Click START GAME**
5. **Game screen appears**:
   - Purple gradient background
   - Hangman gallows (brown frame)
   - Word with underscores
   - A-Z keyboard buttons

---

## Still Not Working?

### Check These:

1. **Is Visual Studio fully updated?**
   - WPF requires VS 2019 or later

2. **Is .NET Framework 4.7.2 installed?**
   - Check: Control Panel ? Programs ? .NET Framework

3. **Are you selecting the right startup file?**
   - In Solution Explorer, HangMan project should be **bold** (startup project)

4. **Is AntiVirus blocking it?**
   - Some AV software blocks newly compiled .exe files

---

## Emergency: Start From Scratch

If nothing works:

1. **Close Visual Studio**

2. **Backup your project**:
   - Copy entire `HangMan` folder somewhere safe

3. **Delete these folders**:
   - `bin`
   - `obj`
   - `.vs`

4. **Reopen `HangMan.sln`**

5. **In Solution Explorer**, verify all files are there:
   - App.xaml ?
   - Views/MainWindow.xaml ?
   - All Models, Services, ViewModels ?

6. **Remove old files** if they exist:
   - Program.cs ?
   - Form1.* files ?

7. **Build ? Rebuild Solution**

8. **Press F5**

---

## Need Immediate Help?

**Take a screenshot of**:
1. Error List window (View ? Error List)
2. Output window (View ? Output, set to "Build")
3. Solution Explorer showing all files

This will help diagnose the exact issue!

---

## Quick Command Reference

| Action | Keyboard | Menu |
|--------|----------|------|
| Build | Ctrl+Shift+B | Build ? Build Solution |
| Rebuild | - | Build ? Rebuild Solution |
| Clean | - | Build ? Clean Solution |
| Run | F5 | Debug ? Start Debugging |
| Run without debug | Ctrl+F5 | Debug ? Start Without Debugging |
| Stop | Shift+F5 | Debug ? Stop Debugging |
| Error List | Ctrl+\, E | View ? Error List |
| Output | Ctrl+Alt+O | View ? Output |

---

**Most Common Fix: Remove `Program.cs` and rebuild!** ??
