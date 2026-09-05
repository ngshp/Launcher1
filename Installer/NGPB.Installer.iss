[Setup]
; Identitas Aplikasi
AppName=NGPB Enterprise
AppVersion=1.0.105
AppPublisher=NGPB
DefaultDirName={autopf}\NGPB
DefaultGroupName=NGPB Enterprise
OutputDir=Installer
OutputBaseFilename=PBNG-Setup-v1.0.105-FINAL

; Kompresi Maksimal agar file kecil
Compression=lzma2/ultra
SolidCompression=yes

; Ikon Installer
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
; Mengambil semua file dari folder hasil build (publish/all)
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Memastikan ikon aplikasi ikut terbawa ke folder instalasi
Source: "icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Shortcut di Start Menu
Name: "{group}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\icon.ico"
; Shortcut di Desktop
Name: "{commondesktop}\NGPB Enterprise"; Filename: "{app}\Launcher.exe"; IconFilename: "{app}\icon.ico"; Tasks: desktopicon

[Run]
; Auto-jalankan aplikasi setelah install
Filename: "{app}\Launcher.exe"; Description: "{cm:LaunchProgram,NGPB Enterprise}"; Flags: nowait postinstall skipifsilent

[Code]
// Menambahkan pesan saat instalasi selesai
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    MsgBox('Instalasi NGPB Enterprise v1.0.105 berhasil!' + #13#10 + 'Semoga sukses, bos!', mbInformation, MB_OK);
  end;
end;
