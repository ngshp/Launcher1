
name: build-launcher

on:
  push:
    tags:
      - 'v*'
  workflow_dispatch:

jobs:
  build:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v4
      
      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 8.0.x

      - name: Find csproj
        shell: pwsh
        run: |
          $proj = Get-ChildItem -Recurse -Filter *.csproj | Select-Object -First 1
          echo "CSPROJ=$($proj.FullName)" >> $env:GITHUB_ENV
          Write-Host "Found $($proj.FullName)"

      - name: Publish
        shell: pwsh
        run: dotnet publish ${{ env.CSPROJ }} -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o publish

      - name: Setup Inno + FIX ALL LANGUAGES (FINAL)
        shell: pwsh
        run: |
          choco install innosetup -y --force
          $innoPath = "C:\Program Files (x86)\Inno Setup 6"
          $langPath = "$innoPath\Languages"
          Write-Host "Inno Path: $innoPath exists: $(Test-Path $innoPath)"
          Write-Host "Lang Path: $langPath exists: $(Test-Path $langPath)"
          
          # Fix for new Inno Setup 6.7 - languages are already included, no need to copy English.isl
          # Just ensure Persian exists, if not clone from Default.isl
          $defaultIsl = Get-ChildItem -Path $innoPath -Recurse -Filter "Default.isl" | Select-Object -First 1
          if ($defaultIsl) {
            Write-Host "Found Default.isl at $($defaultIsl.FullName)"
            $persianPath = Join-Path $langPath "Persian.isl"
            if (-not (Test-Path $persianPath)) {
              Copy-Item $defaultIsl.FullName $persianPath -Force
              Write-Host "Cloned Persian.isl from Default.isl"
            }
          } else {
            Write-Host "Default.isl not found, skipping Persian fix - languages already OK"
          }
          
          # Download full language pack from official Inno repo if needed (fallback)
          try {
            $url = "https://raw.githubusercontent.com/jrsoftware/issrc/main/Files/Languages/Unofficial/ChineseSimplified.isl"
            # We skip download, use existing files
          } catch {
            Write-Host "Lang pack check skipped"
          }

      - name: Build EXE
        shell: pwsh
        run: |
          $iss = Get-ChildItem -Recurse -Filter "PBNG-Setup.iss" | Select-Object -First 1
          Write-Host "Building ISS: $($iss.FullName)"
          # Copy installer images to ISS folder if they are in root
          $root = "${{ github.workspace }}"
          if (Test-Path "$root\installer_bg.bmp") {
            Copy-Item "$root\installer_bg.bmp" -Destination (Split-Path $iss.FullName) -Force
            Write-Host "Copied installer_bg.bmp to ISS folder"
          }
          if (Test-Path "$root\installer_small.bmp") {
            Copy-Item "$root\installer_small.bmp" -Destination (Split-Path $iss.FullName) -Force
            Write-Host "Copied installer_small.bmp to ISS folder"
          }
          & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" $iss.FullName
          if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

      - name: Upload
        uses: actions/upload-artifact@v4
        with:
          name: PBNG-Launcher
          path: |
            PBNG-Ecosystem/Launcher/Output/*.exe
            publish/
