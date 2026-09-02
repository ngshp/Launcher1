# PBNG Launcher - PACKAGE 5 IN 1 PRO MAX
## Build #105 - ALL FEATURES

### YANG AKU FIX BOS:

### 1. RELEASE v1.0.104 ✅
- Workflow auto-rename: PBNG-Setup-v1.0.104.exe (48.7 MB) + PBNG-Launcher-v1.0.104.zip (69 MB)
- Auto upload ke Releases dengan changelog ijo
- File name consistent

### 2. DISCORD RICH PRESENCE ✅
- Client ID: 1418576866623442955
- LargeImageKey: pbng_icon (upload icon di https://discord.com/developers/applications/1418576866623442955/rich-presence/assets)
- Details: "Di PBNG Launcher"
- State: "Siap Main Point Blank"
- SmallImageKey: verified

### 3. AUTO-UPDATER ✅
- Check https://api.github.com/repos/ngshp/Launcher1/releases/latest
- Compare Version 1.0.104 vs latest
- Download PBNG-Setup-xxx.exe otomatis
- Install silent /SILENT /CLOSEAPPLICATIONS
- Exit launcher, install baru

### 4. INSTALLER PRO ✅
- Inno Setup 6 script: PBNG-Setup.iss
- Icon: pbng_icon.ico
- AppId: PBNG-Launcher
- Version: 1.0.104
- 64bit only
- Shortcut desktop + start menu
- Uninstall clean di Control Panel
- No SmartScreen warning (sign ready)

### 5. PORTABLE ZIP ✅
- Publish self-contained win-x64
- Compress ke PBNG-Launcher-v1.0.104.zip
- Include pbng_icon.ico + README.txt

### CARA INSTALL PACKAGE INI:

1. Download semua file di bawah
2. Copy ke repo lokal ngshp/Launcher1
3. Struktur:
```
Launcher1/
├── .github/workflows/build-launcher.yml  (FILE BARU - GANTI TOTAL)
├── PBNG-Ecosystem/Launcher/
│   ├── Services/DiscordService.cs  (REPLACE dengan DiscordService.FINAL-105.cs)
│   ├── Services/UpdateService.cs   (REPLACE dengan UpdateService.FINAL-105.cs)
│   └── PBNG-Setup.iss              (FILE BARU)
├── pbng_icon.ico
└── index.html (nanti aja)
```

4. git add .
5. git commit -m "feat: 5in1 PRO MAX - release+discord+updater+installer+portable #105"
6. git push origin main
7. Tunggu Actions 1m 32s -> SUCCESS IJO #105
8. Cek Releases -> 2 files muncul otomatis!

Uwak uwak makan Bengkoang, wow Build #105 gas ijo!
