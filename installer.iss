[Setup]
AppName=NGPB Enterprise
AppVersion={#GetEnv('BUILD_VERSION')}
AppPublisher=NGPB
DefaultDirName={autopf}\NGPB
DefaultGroupName=NGPB Enterprise
OutputDir=Output
OutputBaseFilename=PBNG-Setup-v1.0.{#GetEnv('BUILD_NUMBER_RUN')}
Compression=lzma2/ultra
SolidCompression=yes
SetupIconFile=assets\logo.ico

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\NGPB Enterprise"; Filename: "{app}\*.exe"
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\*.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\*.exe"; Description: "{cm:LaunchProgram,NGPB Enterprise}"; Flags: nowait postinstall skipifsilent
