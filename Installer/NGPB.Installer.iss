[Setup]
AppName=NGPB Enterprise
AppVersion=1.0.105
DefaultDirName={autopf}\NGPB
OutputDir=.
OutputBaseFilename=PBNG-Setup-Installer-v1.0.105
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "indonesian"; MessagesFile: "Languages\Indonesian.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
; Pastikan folder Languages ada di dalam folder Installer/
Source: "Languages\*"; DestDir: "{app}\Languages"; Flags: recursesubdir
Source: "publish\all\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdir
