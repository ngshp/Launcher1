; PBNG Launcher v1.0.105 - INSTALLER PRO MAX GREEN
#define MyAppName "PBNG Launcher"
#define MyAppVersion "1.0.105"
#define MyAppPublisher "PBNG Ecosystem"
#define MyAppURL "https://ngshp.github.io/Launcher1"
#define MyAppExeName "PBNG Launcher.exe"

[Setup]
AppId={{PBNG-Launcher}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL=https://github.com/ngshp/Launcher1/releases
DefaultDirName={autopf}\PBNG Launcher
DefaultGroupName=PBNG Launcher
DisableProgramGroupPage=yes
OutputBaseFilename=PBNG-Setup-v1.0.105
Compression=lzma
SolidCompression=yes
WizardStyle=modern
WizardImageFile=installer_bg.bmp
WizardSmallImageFile=installer_small.bmp
SetupIconFile=pbng_icon.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
VersionInfoVersion=1.0.105
VersionInfoCompany=PBNG Ecosystem
VersionInfoDescription=PBNG Launcher v1.0.105 MULTILANG PRO MAX
VersionInfoCopyright=© 2026 PBNG Ecosystem
VersionInfoProductName=PBNG Launcher
VersionInfoProductVersion=1.0.105

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; InfoBeforeFile: "en.txt"
Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl"; InfoBeforeFile: "id.txt"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "chinese"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "farsi"; MessagesFile: "compiler:Languages\Persian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "PBNG-Ecosystem\Launcher\bin\Release\net8.0-windows\win-x64\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "installer_bg.bmp"; Flags: dontcopy
Source: "installer_small.bmp"; Flags: dontcopy

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}"
