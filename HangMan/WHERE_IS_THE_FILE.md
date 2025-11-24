# ?? WHERE TO FIND HangMan.csproj

## ?? EXACT LOCATION

```
C:\Users\Elvis\source\repos\HangMan\HangMan\HangMan.csproj
```

## ?? HOW TO GET THERE

### Option 1: File Explorer
1. Press **Windows Key + E** (opens File Explorer)
2. Click in the address bar at the top
3. Paste: `C:\Users\Elvis\source\repos\HangMan\HangMan`
4. Press **Enter**
5. You'll see **HangMan.csproj** in the folder

### Option 2: From Visual Studio
1. In **Solution Explorer**, right-click on **HangMan** (the project)
2. Click **Open Folder in File Explorer**
3. You'll see **HangMan.csproj** in that folder

---

## ?? VISUAL GUIDE

Your folder structure:
```
C:\Users\Elvis\source\repos\HangMan\
??? HangMan.sln                    ? Solution file
??? HangMan\                       ? Project folder
    ??? HangMan.csproj            ? THIS FILE! Edit this!
    ??? HangMan.csproj.user       ? NOT this one (ignore)
    ??? App.xaml
    ??? App.config
    ??? Views\
    ??? Models\
    ??? Services\
    ??? ...
```

---

## ?? IMPORTANT - Don't Confuse These Files

| File Name | What It Is | Do You Edit It? |
|-----------|-----------|-----------------|
| `HangMan.csproj` | **Main project file** | ? **YES - Edit this!** |
| `HangMan.csproj.user` | User settings | ? NO - Leave alone |
| `HangMan.sln` | Solution file | ? NO - Leave alone |

---

## ?? QUICK ACTION

**Copy this path:**
```
C:\Users\Elvis\source\repos\HangMan\HangMan
```

**Then:**
1. Open File Explorer (Windows Key + E)
2. Paste path in address bar
3. Press Enter
4. Find **HangMan.csproj**
5. Right-click ? **Open with ? Notepad**

---

## ?? WHAT TO DELETE

Once you open `HangMan.csproj` in Notepad:

**Search for:** `MainWindow_FINAL` (Ctrl+F)

**Delete this block:**
```xml
    <Page Include="Views\MainWindow_FINAL.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
    <Page Include="Views\MainWindow_FIXED.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
```

**Save:** Ctrl+S

**Done!**

---

## ? CHECKLIST

- [ ] Close Visual Studio completely
- [ ] Navigate to: `C:\Users\Elvis\source\repos\HangMan\HangMan`
- [ ] Open **HangMan.csproj** (NOT .csproj.user)
- [ ] Delete the 6 lines with MainWindow_FINAL and MainWindow_FIXED
- [ ] Save the file
- [ ] Reopen Visual Studio
- [ ] Rebuild solution
- [ ] Run game (F5)

---

**The file exists at:**
`C:\Users\Elvis\source\repos\HangMan\HangMan\HangMan.csproj`

**Just open it in Notepad and delete those 6 lines!** ??
