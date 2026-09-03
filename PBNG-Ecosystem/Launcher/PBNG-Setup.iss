; PBNG Launcher v1.0.105 - 7 BAHASA FINAL GREEN FIX
#define MyAppName "PBNG Launcher"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Ecosystem"
#define MyAppExeName "PBNG Launcher.exe"

[Setup]
AppId=PBNG-Launcher-105
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=https://ngshp.github.io/Launcher1
DefaultDirName={autopf}\PBNG Launcher
DefaultGroupName=PBNG Launcher
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=PBNG-Setup-v1.0.105
Compression=lzma
SolidCompression=yes
WizardStyle=modern
WizardImageFile=installer_bg.bmp
WizardSmallImageFile=installer_small.bmp
SetupIconFile=pbng_icon.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesInstallIn64BitMode=x64
VersionInfoVersion=1.0.105
VersionInfoProductVersion=1.0.105

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "chinese"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "farsi"; MessagesFile: "compiler:Languages\Farsi.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\..\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
