# ?? CRITICAL FIX REQUIRED - Project File Cleanup

## ?? Problem
Your project file (`HangMan.csproj`) contains references to files that don't exist:
- `Views\MainWindow_FINAL.xaml` ?
- `Views\MainWindow_FIXED.xaml` ?

These need to be removed from the project file.

## ? SOLUTION - Follow These Steps EXACTLY

### Step 1: Close Visual Studio
**Important**: You MUST close Visual Studio completely before editing the .csproj file.

1. Save any open files (Ctrl+S on each)
2. File ? Exit (or close Visual Studio)
3. Make sure Visual Studio is completely closed

---

### Step 2: Open the Project File in Notepad

1. Open **File Explorer**
2. Navigate to: `C:\Users\Elvis\source\repos\HangMan\HangMan\`
3. Right-click on **`HangMan.csproj`**
4. Select **"Open with"** ? **"Notepad"**

---

### Step 3: Remove Bad References

**Find these lines** (around line 85-90):
```xml
    <Page Include="Views\MainWindow_FINAL.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
    <Page Include="Views\MainWindow_FIXED.xaml">
      <Generator>MSBuild:Compile</Generator>
    </Page>
```

**DELETE those 6 lines completely!**

---

### Step 4: Optional - Remove Documentation Files

**Find these lines** (around line 95-105):
```xml
    <None Include="CLEAN_DESIGN.md" />
    <None Include="COMPACT_LAYOUT.md" />
    <None Include="COMPLETE_UI_FIX.md" />
    <None Include="CSHARP_FIX.md" />
    <None Include="ERROR_FIXED.md" />
    <None Include="FINAL_HORIZONTAL_LAYOUT.md" />
```

**You can delete these too** (they're just documentation, not needed for the build).

---

### Step 5: Verify the File

After editing, the `<ItemGroup>` section should look like this:

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
    <Compile Include="App.xaml.cs">
      <DependentUpon>App.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="Converters\BoolToVisibilityConverter.cs" />
    <Compile Include="Converters\GameConverters.cs" />
    <Compile Include="Models\Difficulty.cs" />
    <Compile Include="Models\GameState.cs" />
    <Compile Include="Models\HighScore.cs" />
    <Compile Include="Models\WordCategory.cs" />
    <Compile Include="Services\HighScoreService.cs" />
    <Compile Include="Services\SoundService.cs" />
    <Compile Include="Services\WordService.cs" />
    <Compile Include="ViewModels\GameViewModel.cs" />
    <Compile Include="ViewModels\RelayCommand.cs" />
    <Compile Include="ViewModels\ViewModelBase.cs" />
    <Compile Include="Views\MainWindow.xaml.cs">
      <DependentUpon>MainWindow.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
  </ItemGroup>
```

**Key points:**
- ? Only ONE `MainWindow.xaml` reference
- ? NO `MainWindow_FINAL.xaml` reference
- ? NO `MainWindow_FIXED.xaml` reference

---

### Step 6: Save the File

1. In Notepad: **File ? Save** (or Ctrl+S)
2. Close Notepad

---

### Step 7: Reopen Visual Studio

1. Open Visual Studio
2. Open your solution: `HangMan.sln`
3. Wait for it to load completely

---

### Step 8: Clean and Rebuild

1. **Build ? Clean Solution**
2. **Build ? Rebuild Solution** (Ctrl+Shift+B)
3. Check the **Output** window - should say "Build succeeded"

---

### Step 9: Run the Game

1. Press **F5**
2. Your horizontal Hangman game should open!

---

## ?? Quick Checklist

Before reopening Visual Studio:
- [ ] Visual Studio is completely closed
- [ ] Edited `HangMan.csproj` in Notepad
- [ ] Removed `MainWindow_FINAL.xaml` reference
- [ ] Removed `MainWindow_FIXED.xaml` reference
- [ ] Saved the file
- [ ] Closed Notepad

After reopening:
- [ ] Cleaned solution
- [ ] Rebuilt solution (0 errors)
- [ ] Ran game (F5)
- [ ] Game opens successfully

---

## ?? Alternative: Use This Clean Project File

If you want to **replace the entire file**, copy this to your `HangMan.csproj`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{2F252B65-1BE3-4408-952B-9B7751DA78C3}</ProjectGuid>
    <OutputType>WinExe</OutputType>
    <RootNamespace>HangMan</RootNamespace>
    <AssemblyName>HangMan</AssemblyName>
    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <Deterministic>true</Deterministic>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xaml" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Xml" />
    <Reference Include="WindowsBase" />
    <Reference Include="PresentationCore" />
    <Reference Include="PresentationFramework" />
  </ItemGroup>
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
    <Compile Include="App.xaml.cs">
      <DependentUpon>App.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="Converters\BoolToVisibilityConverter.cs" />
    <Compile Include="Converters\GameConverters.cs" />
    <Compile Include="Models\Difficulty.cs" />
    <Compile Include="Models\GameState.cs" />
    <Compile Include="Models\HighScore.cs" />
    <Compile Include="Models\WordCategory.cs" />
    <Compile Include="Services\HighScoreService.cs" />
    <Compile Include="Services\SoundService.cs" />
    <Compile Include="Services\WordService.cs" />
    <Compile Include="ViewModels\GameViewModel.cs" />
    <Compile Include="ViewModels\RelayCommand.cs" />
    <Compile Include="ViewModels\ViewModelBase.cs" />
    <Compile Include="Views\MainWindow.xaml.cs">
      <DependentUpon>MainWindow.xaml</DependentUpon>
      <SubType>Code</SubType>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs">
      <SubType>Code</SubType>
    </Compile>
    <None Include="Properties\Settings.settings">
      <Generator>SettingsSingleFileGenerator</Generator>
      <LastGenOutput>Settings.Designer.cs</LastGenOutput>
    </None>
    <Compile Include="Properties\Settings.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Settings.settings</DependentUpon>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
  </ItemGroup>
  <ItemGroup>
    <Folder Include="Assets\Images\" />
    <Folder Include="Assets\Sounds\" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>
```

**To use this:**
1. Close Visual Studio
2. Open `HangMan.csproj` in Notepad
3. Select All (Ctrl+A)
4. Paste the above content
5. Save and close
6. Reopen Visual Studio
7. Rebuild

---

## ?? IMPORTANT

**You MUST close Visual Studio before editing the .csproj file!**

If you edit it while Visual Studio is open, your changes will be overwritten.

---

## ? Expected Result

After following these steps:
- ? Project builds with 0 errors
- ? Game runs and opens correctly
- ? Horizontal layout displays properly
- ? No file-not-found errors

---

**Follow the steps above carefully and your game will work!** ??
