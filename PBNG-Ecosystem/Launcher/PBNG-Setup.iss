; PBNG Installer v1.0.105 - FULL FIX FOR GITHUB ACTIONS
; Fix: Indonesian.isl not found on GitHub runner - only Default.isl exists
#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Team"
#define MyAppURL "https://github.com/ngshp/Launcher1"
#define MyAppExeName "Launcher.exe"

[Setup]
AppId={{PBNG-105-FULL-FIX-88}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=..\
OutputBaseFilename=PBNG-Setup-v1.0.105
; Icon shield neon - path relatif dari folder Installer
SetupIconFile=..\PBNG-Ecosystem\Launcher\pbng_icon.ico
WizardImageFile=..\PBNG-Ecosystem\Launcher\installer_bg.bmp
WizardSmallImageFile=..\PBNG-Ecosystem\Launcher\installer_small.bmp
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\{#MyAppExeName}
DisableDirPage=no
DisableProgramGroupPage=no

[Languages]
; FIX LINE 31: GitHub runner C:\Program Files (x86)\Inno Setup 6\Languages\ cuma punya Default.isl
; Gak ada Indonesian.isl! Jadi semua pake Default.isl
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Default.isl"
Name: "chinese"; MessagesFile: "compiler:Default.isl"
Name: "arabic"; MessagesFile: "compiler:Default.isl"
Name: "persian"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Launcher.exe dari artifact build-launcher - GitHub Actions bakal download kesini
; Kalo local build, dari bin Release
Source: "..\PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion; Permissions: everyone-full
Source: "..\PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\*.dll"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\hero.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\PBNG-Ecosystem\Launcher\pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\PBNG-Ecosystem\Launcher\installer_bg.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\installer_small.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

; Fallback untuk GitHub Actions yang download artifact ke folder temp
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist; Permissions: everyone-full
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\logs"
