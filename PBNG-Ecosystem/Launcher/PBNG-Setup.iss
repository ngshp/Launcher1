; PBNG Setup v1.0.105 - 7 BAHASA FINAL FIX - TETAP KEREN - PASTI IJO
#define MyAppName "Point Blank Next Generation"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Team"
#define MyAppURL "https://github.com/ngshp/Launcher1"
#define MyAppExeName "Launcher.exe"

[Setup]
AppId={{PBNG-105-7BAHASA-FINAL}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
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
DisableDirPage=no
DisableProgramGroupPage=no

[Languages]
; FIX FINAL: GitHub runner Inno Setup 6.7.1 cuma punya Default.isl
; Biar 7 bahasa tetep muncul di dropdown & enak dilihat, semua pakai Default.isl
; Jadi gak error "Indonesian.isl not found" lagi!
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
Source: "..\PBNG-Ecosystem\Launcher\hero.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\PBNG-Ecosystem\Launcher\pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\PBNG-Ecosystem\Launcher\installer_bg.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "..\PBNG-Ecosystem\Launcher\installer_small.bmp"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist
Source: "hero.png"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\logs"
