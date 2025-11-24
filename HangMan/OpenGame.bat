@echo off
echo ========================================
echo   Modern Hangman Game - Quick Launcher
echo ========================================
echo.

REM Check if Visual Studio is running
tasklist /FI "IMAGENAME eq devenv.exe" 2>NUL | find /I /N "devenv.exe">NUL
if "%ERRORLEVEL%"=="0" (
    echo WARNING: Visual Studio is currently running!
    echo Please close Visual Studio first, then run this script again.
    echo.
    pause
    exit /b
)

echo Step 1: Checking project file...
if not exist "HangMan.csproj" (
    echo ERROR: HangMan.csproj not found!
    echo Make sure you run this from the HangMan project folder.
    pause
    exit /b
)

echo Step 2: Creating backup of current project file...
if exist "HangMan.csproj.backup" (
    echo Backup already exists, skipping...
) else (
    copy "HangMan.csproj" "HangMan.csproj.backup" >NUL
    echo Backup created: HangMan.csproj.backup
)

echo Step 3: Checking if WPF references exist...
findstr /C:"PresentationFramework" HangMan.csproj >NUL
if "%ERRORLEVEL%"=="0" (
    echo WPF references found! Project file is already updated.
    echo.
    echo Opening solution in Visual Studio...
    start "" "..\HangMan.sln"
    echo.
    echo Solution opened! Wait for Visual Studio to load, then press F5 to run.
    pause
    exit /b
) else (
    echo.
    echo ============================================================
    echo   WPF references NOT found in project file!
    echo ============================================================
    echo.
    echo You need to update HangMan.csproj manually:
    echo.
    echo 1. Open PROJECT_UPDATE_GUIDE.txt
    echo 2. Copy the XML content from that file
    echo 3. Open HangMan.csproj in Notepad
    echo 4. Replace ALL content with the copied XML
    echo 5. Save and run this script again
    echo.
    echo Opening PROJECT_UPDATE_GUIDE.txt for you now...
    start "" "notepad.exe" "PROJECT_UPDATE_GUIDE.txt"
    timeout /t 2 >NUL
    echo.
    echo Opening HangMan.csproj in Notepad...
    start "" "notepad.exe" "HangMan.csproj"
    echo.
    echo After updating the file, save it and run this script again!
    pause
)
