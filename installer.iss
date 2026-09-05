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
; Pakai file yang sudah disiapkan workflow
SetupIconFile=assets\logo.ico

[Files]
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\Launcher.exe"
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\Launcher.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\Launcher.exe"; Description: "{cm:LaunchProgram,NGPB Enterprise}"; Flags: nowait postinstall skipifsilent

[Code]
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    MsgBox('Instalasi NGPB Enterprise v1.0.105 berhasil!' + #13#10 + 'Semoga sukses, bos!', mbInformation, MB_OK);
  end;
end;
