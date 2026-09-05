[Setup]
AppName=NGPB Enterprise
AppVersion=1.0.105
AppPublisher=NGPB
DefaultDirName={autopf}\NGPB
DefaultGroupName=NGPB Enterprise
OutputDir=.
OutputBaseFilename=PBNG-Setup-Installer-v1.0.105
Compression=lzma2/ultra
SolidCompression=yes
SetupIconFile=..\Launcher\Resources\icon.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "..\Languages\Indonesian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\Languages\*"; DestDir: "{app}\Languages"; Flags: ignoreversion
Source: "..\publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdir

[Icons]
Name: "{group}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Launcher.exe"; Description: "{cm:LaunchProgram,NGPB Enterprise}"; Flags: nowait postinstall skipifsilent
