[Setup]
AppName=NGPB Enterprise
AppVersion=1.0.105
AppPublisher=NGPB
DefaultDirName={autopf}\NGPB
DefaultGroupName=NGPB Enterprise
OutputDir=Output
OutputBaseFilename=PBNG-Setup-v1.0.105-FINAL
Compression=lzma2/ultra
SolidCompression=yes
SetupIconFile=assets\logo.ico

[Files]
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
; Menggunakan {app}\* agar otomatis mengambil file exe utama yang ada
Name: "{group}\NGPB Enterprise"; Filename: "{app}\*.exe"
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\*.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\*.exe"; Description: "{cm:LaunchProgram,NGPB Enterprise}"; Flags: nowait postinstall skipifsilent
