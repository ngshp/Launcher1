#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"

[Setup]
AppId={{PBNG-105-FINAL-100-IJO}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher=PBNG Team
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=..\
OutputBaseFilename=PBNG-Setup-v1.0.105
SetupIconFile=..\PBNG-Ecosystem\Launcher\pbng_icon.ico
WizardImageFile=..\PBNG-Ecosystem\Launcher\installer_bg.bmp
WizardSmallImageFile=..\PBNG-Ecosystem\Launcher\installer_small.bmp
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
Source: "..\PBNG-Ecosystem\Launcher\hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\background_pbng.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Run]
Filename: "{app}\Launcher.exe"; Description: "Jalankan {#MyAppName}"; Flags: nowait postinstall skipifsilent
