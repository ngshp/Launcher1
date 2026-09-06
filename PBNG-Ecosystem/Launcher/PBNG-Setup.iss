#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"
[Setup]
AppId={{PBNG-105-NGPB-EXE-FINAL}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher=PBNG Team
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=..\..\
OutputBaseFilename=PBNG-Setup-v1.0.105-FULL-ngpb
SetupIconFile=pbng_icon.ico
WizardImageFile=installer_bg.bmp
WizardSmallImageFile=installer_small.bmp
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\Launcher.exe
[Languages]
Name: "indonesian"; MessagesFile: "compiler:Default.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Default.isl"
Name: "chinese"; MessagesFile: "compiler:Default.isl"
Name: "arabic"; MessagesFile: "compiler:Default.isl"
Name: "persian"; MessagesFile: "compiler:Default.isl"
[Files]
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "background_pbng.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\..\GameClient\bin\Release\net8.0-windows\win-x64\publish\ngpb.exe"; DestDir: "{app}\GameClient"; Flags: ignoreversion
Source: "..\..\GameClient\pbng_icon.ico"; DestDir: "{app}\GameClient"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\..\GameClient\*"; DestDir: "{app}\GameClient"; Flags: ignoreversion recursesubdirs createallsubdirs skipifsourcedoesntexist
[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{#MyAppName} Client ngpb.exe"; Filename: "{app}\GameClient\ngpb.exe"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"
Name: "{autodesktop}\{#MyAppName} Client"; Filename: "{app}\GameClient\ngpb.exe"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"
[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Run]
Filename: "{app}\Launcher.exe"; Flags: nowait postinstall skipifsilent
Filename: "{app}\GameClient\ngpb.exe"; Description: "Jalankan ngpb.exe"; Flags: nowait postinstall skipifsilent unchecked
