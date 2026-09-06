; PBNG Setup v1.0.105 - FIX FOR GITHUB RUNNER - HYBRID HERO
#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Team"
#define MyAppURL "https://github.com/ngshp/Launcher1"

[Setup]
AppId={{PBNG-105-HYBRID-PRO}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=..\..\
OutputBaseFilename=PBNG-Setup-v1.0.105
SetupIconFile=pbng_icon.ico
WizardImageFile=installer_bg.bmp
WizardSmallImageFile=installer_small.bmp
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\Launcher.exe

[Languages]
; FIX: GitHub runner cuma punya Default.isl, gak ada Indonesian.isl
; Kita pake Default aja untuk semua bahasa
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Default.isl"
Name: "chinese"; MessagesFile: "compiler:Default.isl"
Name: "arabic"; MessagesFile: "compiler:Default.isl"
Name: "persian"; MessagesFile: "compiler:Default.isl"

[Files]
; Launcher yang udah include hero.png hybrid + icon square
Source: "bin\Release\net8.0-windows\win-x64\publish\Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "installer_bg.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "installer_small.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Run]
Filename: "{app}\Launcher.exe"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
