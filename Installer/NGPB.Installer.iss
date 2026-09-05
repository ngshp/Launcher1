[Setup]
; Identitas Aplikasi
AppName=NGPB Enterprise
AppVersion=1.0.105
AppPublisher=NGPB
DefaultDirName={autopf}\NGPB
DefaultGroupName=NGPB Enterprise
OutputDir=Installer
OutputBaseFilename=PBNG-Setup-v1.0.105-FINAL

; Kompresi
Compression=lzma2/ultra
SolidCompression=yes

; Ikon Installer (Penting: harus pakai .ico, maka nanti di workflow akan kita siapkan)
SetupIconFile=icon.ico

; Pengaturan Tampilan
WizardStyle=modern
SetupLogging=yes
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
; Mengambil semua file dari folder hasil publish (sesuaikan dengan path output workflow)
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Pastikan file icon.ico ada di folder root saat build
Source: "icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Shortcut di Start Menu & Desktop (Ganti IconFilename ke icon.ico agar tidak crash)
Name: "{group}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\icon.ico"
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\icon.ico"; Tasks: desktopicon

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
