; PBNG Installer v1.0.105 - FINAL FIX - 1 BAHASA ONLY - PASTI IJO
#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"

[Setup]
AppId={{PBNG-105-FINAL-FIX}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher=PBNG Team
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=..\
OutputBaseFilename=PBNG-Setup-v1.0.105
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\Launcher.exe

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; GitHub Actions: file dari artifact download
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
; Local build: dari folder publish
Source: "..\PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\Launcher.exe"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Run]
Filename: "{app}\Launcher.exe"; Description: "Jalankan {#MyAppName}"; Flags: nowait postinstall skipifsilent
