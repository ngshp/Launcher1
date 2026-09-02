# 🚀 PBNG Launcher

Launcher resmi untuk PBNG Ecosystem - Auto Update & Installer

[![Build Installer](https://github.com/ngshp/Launcher1/actions/workflows/build.yml/badge.svg)](https://github.com/ngshp/Launcher1/actions/workflows/build.yml)
[![Latest Release](https://img.shields.io/github/v/release/ngshp/Launcher1?label=latest)](https://github.com/ngshp/Launcher1/releases/latest)

### ⬇️ Download

#### [**>> DOWNLOAD PBNG LAUNCHER TERBARU <<**](https://github.com/ngshp/Launcher1/releases/latest)

> Klik `Assets` -> pilih `PBNG-Setup-1.0.0.exe` untuk installer, atau `Launcher.exe` untuk versi portable.

### ✨ Fitur
- Self-contained (.NET 8, tidak perlu install .NET)
- Auto-updater
- Installer modern (Inno Setup)

   ![PBNG](https://...link gambar...)     ![PBNG Launcher Banner](docs/banner.png)
    # 🚀 PBNG Launcher
  
### 🛠️ Cara Build Lokal
```bash
dotnet publish PBNG-Ecosystem/Launcher/Launcher.csproj -c Release -r win-x64 --self-contained true -o Build
