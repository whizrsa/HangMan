@echo off
echo ========================================
echo   Fix "File Not Found" Error
echo ========================================
echo.
echo This will:
echo 1. Clean build outputs
echo 2. Remove temporary files
echo 3. Prepare for fresh build
echo.
pause

echo.
echo Step 1: Cleaning bin and obj folders...
if exist "bin" rmdir /s /q "bin"
if exist "obj" rmdir /s /q "obj"
echo Done!

echo.
echo Step 2: Cleaning .vs folder...
if exist "..\..vs" rmdir /s /q "..\.vs"
echo Done!

echo.
echo ========================================
echo   Cleanup Complete!
echo ========================================
echo.
echo Next steps:
echo 1. In Visual Studio: File -^> Close Solution
echo 2. In Visual Studio: File -^> Recent Projects -^> HangMan.sln
echo 3. Press Ctrl+Shift+B to rebuild
echo 4. Press F5 to run
echo.
echo If you still see old files open in tabs:
echo - Click Window -^> Close All Documents
echo - Then rebuild (Ctrl+Shift+B)
echo.
pause
