; PBNG-Setup v1.0.105 - FINAL 7 BAHASA FIX
; Fix: GitHub runner Inno Setup 6.7.1 cuma punya Default.isl
; Jadi 7 bahasa tetep muncul di installer enak dilihat, tapi file nya semua pakai Default.isl biar gak error Indonesian.isl
#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Team"
#define MyAppURL "https://github.com/ngshp/Launcher1"
#define MyAppExeName "Launcher.exe"

[Setup]
AppId={{PBNG-7BAHASA-IJO-FINAL}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=..\
OutputBaseFilename=PBNG-Setup-v1.0.105
SetupIconFile=..\PBNG-Ecosystem\Launcher\pbng_icon.ico
WizardImageFile=..\PBNG-Ecosystem\Launcher\installer_bg.bmp
WizardSmallImageFile=..\PBNG-Ecosystem\Launcher\installer_small.bmp
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\{#MyAppExeName}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
DisableDirPage=no
DisableProgramGroupPage=no

[Languages]
Name: "indonesian"; MessagesFile: "compiler:Default.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Default.isl"
Name: "chinese"; MessagesFile: "compiler:Default.isl"
Name: "arabic"; MessagesFile: "compiler:Default.isl"
Name: "persian"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\*.dll"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\logs"
