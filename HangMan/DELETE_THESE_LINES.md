# ?? EXACT LINES TO DELETE FROM HangMan.csproj

## ?? Location
File: `C:\Users\Elvis\source\repos\HangMan\HangMan\HangMan.csproj`

---

## ? DELETE THESE 6 LINES (Lines 88-93)

**FIND THIS BLOCK:**
```xml
    <Page Include="Views\MainWindow_FINAL.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
    <Page Include="Views\MainWindow_FIXED.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
```

**DELETE ALL 6 LINES ABOVE!**

---

## ? AFTER DELETION

The section should look like this (around line 85-90):

**BEFORE:**
```xml
    <Compile Include="Views\MainWindow.xaml.cs">
      <DependentUpon>MainWindow.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
    <Page Include="Views\MainWindow_FINAL.xaml">      ? DELETE THIS LINE
      <Generator>MSBuild:Compile</Generator>          ? DELETE THIS LINE
    </Page>                                            ? DELETE THIS LINE
    <Page Include="Views\MainWindow_FIXED.xaml">      ? DELETE THIS LINE
      <Generator>MSBuild:Compile</Generator>          ? DELETE THIS LINE
    </Page>                                            ? DELETE THIS LINE
  </ItemGroup>
```

**AFTER:**
```xml
    <Compile Include="Views\MainWindow.xaml.cs">
      <DependentUpon>MainWindow.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
  </ItemGroup>
```

---

## ?? STEP-BY-STEP INSTRUCTIONS

### Step 1: Close Visual Studio
- **Window ? Close All Documents**
- **File ? Exit**
- Wait 5 seconds

### Step 2: Open File in Notepad
1. Open File Explorer
2. Go to: `C:\Users\Elvis\source\repos\HangMan\HangMan\`
3. Find **HangMan.csproj**
4. Right-click ? **Open with ? Notepad**

### Step 3: Find the Bad Lines
- Press **Ctrl+F**
- Type: `MainWindow_FINAL`
- Click **Find Next**
- You'll see the block starting with `<Page Include="Views\MainWindow_FINAL.xaml">`

### Step 4: Delete
Select and delete these 6 lines:
```xml
    <Page Include="Views\MainWindow_FINAL.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
    <Page Include="Views\MainWindow_FIXED.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
```

### Step 5: Save
- Press **Ctrl+S**
- Close Notepad

### Step 6: Reopen Visual Studio
1. Open Visual Studio
2. Open `HangMan.sln`
3. **Build ? Clean Solution**
4. **Build ? Rebuild Solution**
5. Press **F5** to run

---

## ? VERIFICATION

After saving, search for `MainWindow_FINAL` in the file again:
- **Ctrl+F** ? `MainWindow_FINAL`
- Should show: **"Cannot find 'MainWindow_FINAL'"**
- This means it's deleted! ?

---

## ?? EXPECTED RESULT

After rebuilding:
- ? 0 Errors
- ? Game opens
- ? Horizontal layout
- ? Working perfectly!

---

**The file is located at:**
`C:\Users\Elvis\source\repos\HangMan\HangMan\HangMan.csproj`

**Just delete those 6 lines and you're done!** ??
