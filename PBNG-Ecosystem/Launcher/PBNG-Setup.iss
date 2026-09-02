; PBNG Launcher - Installer PRO MAX MULTILANGUAGE v1.0.104
; Languages: ID, EN, FR, RU, CN, AR, IR (7 bahasa)

#define MyAppName "PBNG Launcher"
#define MyAppVersion "1.0.104"
#define MyAppPublisher "PBNG Ecosystem"
#define MyAppURL "https://ngshp.github.io/Launcher1/"
#define MyAppExeName "Launcher.exe"

[Setup]
AppId={{PBNG-LAUNCHER-MULTILANG-105}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL=https://github.com/ngshp/Launcher1/releases
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=installer
OutputBaseFilename=PBNG-Setup-v1.0.104-Multilang
SetupIconFile=..\..\pbng_icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=lowest
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName={#MyAppName} v{#MyAppVersion}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "chinesesimplified"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "farsi"; MessagesFile: "compiler:Languages\Farsi.isl"

[CustomMessages]
english.WelcomeLabel=Welcome to PBNG Launcher
indonesian.WelcomeLabel=Selamat datang di PBNG Launcher
french.WelcomeLabel=Bienvenue sur PBNG Launcher
russian.WelcomeLabel=Добро пожаловать в PBNG Launcher
chinesesimplified.WelcomeLabel=欢迎使用 PBNG Launcher
arabic.WelcomeLabel=مرحبا بكم في PBNG Launcher
farsi.WelcomeLabel=به PBNG Launcher خوش آمدید

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\..\publish\Launcher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\..\pbng_icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\pbng_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\pbng_icon.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
