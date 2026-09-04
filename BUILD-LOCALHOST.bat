@echo off
title BUILD NGPB LOCALHOST WINDOWS ENTERPRISE - v1.0.105
color 0E
echo [BUILD] NGPB LOCALHOST WINDOWS ENTERPRISE v1.0.105 - Building...
echo.
echo [1/4] Building Server - NGPB-Server-Windows.exe - 127.0.0.1:39190 Enterprise...
dotnet publish Server/NGPB.DedicatedServer.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o Server/
if errorlevel 1 ( echo [ERROR] Server build failed! & pause & exit /b )
echo [2/4] Building Game Client - ngpb.exe - RED Yard AUG A3 Enterprise...
dotnet publish GameClient/NGPB.Game.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o Game/
if errorlevel 1 ( echo [ERROR] Game build failed! & pause & exit /b )
echo [3/4] Building Anti-Cheat AI - NGPB.AntiCheat.exe...
dotnet publish GameClient/Source/AntiCheat/NGPB.AntiCheat.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o AntiCheat/
if errorlevel 1 ( echo [ERROR] AntiCheat build failed! & pause & exit /b )
echo [4/4] Building Anti-Cheat Enterprise - NGPB.AntiCheat.Enterprise.dll - HWID+IP Ban...
dotnet publish GameClient/Source/AntiCheat/Enterprise/NGPB.AntiCheat.Enterprise.csproj -c Release -r win-x64 --self-contained true -o AntiCheat/
if errorlevel 1 ( echo [ERROR] Enterprise build failed! & pause & exit /b )
echo.
echo [DONE] BUILD SUCCESS BOS! ENTERPRISE PRO MAX!
echo - Server/NGPB-Server-Windows.exe (15 MB) - HWID+IP Ban, GM Filter, Chat Filter, Link https://ngpb.nhg.one
echo - Game/ngpb.exe (60 MB) - RED Yard AUG A3 6 Panel UI
echo - AntiCheat/NGPB.AntiCheat.exe + NGPB.AntiCheat.Enterprise.dll (20 MB) - AI Enterprise
echo.
echo [NEXT] Run START-ALL.bat untuk 1 KLIK MAIN! Atau START-SERVER.bat + START-GAME.bat!
echo [MAIN BARENG TEMAN] Share folder ini, teman edit START-GAME.bat ganti 127.0.0.1 jadi IP Bos!
pause
