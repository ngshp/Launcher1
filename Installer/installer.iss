#define MyAppName "PBNG Launcher"

[Setup]

AppName={#MyAppName}

AppVersion=1.

DefaultDirName={autopf}\PBNG Launcher

OutputDir=Output

OutputBaseFilename=PBNG-Setup

Compression=lzma

SolidCompression=yes

[Files]

Source: "..\Build\*";
DestDir: "{app}";
Flags: recursesubdirs

[Icons]

Name:
"{autodesktop}\PBNG Launcher";

Filename:
"{app}\Launcher.exe"
