#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"

[Setup]
AppId={{PBNG-105-FINAL-102-IJO-OPSI-A}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher=PBNG Team
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
; Output ke root biar gampang di-upload
OutputDir=..\..\
OutputBaseFilename=PBNG-Setup-v1.0.105
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
; FILE INI ADA KARENA DI-DOWNLOAD DI STEP SEBELUMNYA KE FOLDER INI!
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "background_pbng.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Run]
Filename: "{app}\Launcher.exe"; Description: "Jalankan {#MyAppName}"; Flags: nowait postinstall skipifsilent
