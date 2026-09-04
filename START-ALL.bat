@echo off
title NGPB ALL IN ONE - LOCALHOST WINDOWS - 1 KLIK MAIN! v1.0.105 ENTERPRISE
color 0A
echo.
echo  ███╗   ██╗ ██████╗ ██████╗ ██████╗      █████╗ ██╗     ██╗          ██╗███╗   ██╗     ██████╗ ███╗   ██╗███████╗
echo  ████╗  ██║██╔════╝ ██╔══██╗██╔══██╗    ██╔══██╗██║     ██║          ██║████╗  ██║    ██╔═══██╗████╗  ██║██╔════╝
echo  ██╔██╗ ██║██║  ███╗██████╔╝██████╔╝    ███████║██║     ██║          ██║██╔██╗ ██║    ██║   ██║██╔██╗ ██║█████╗  
echo  ██║╚██╗██║██║   ██║██╔══██╗██╔══██╗    ██╔══██║██║     ██║          ██║██║╚██╗██║    ██║   ██║██║╚██╗██║██╔══╝  
echo  ██║ ╚████║╚██████╔╝██████╔╝██████╔╝    ██║  ██║███████╗███████╗     ██║██║ ╚████║    ╚██████╔╝██║ ╚████║███████╗
echo  ╚═╝  ╚═══╝ ╚═════╝ ╚═════╝ ╚═════╝     ╚═╝  ╚═╝╚══════╝╚══════╝     ╚═╝╚═╝  ╚═══╝     ╚═════╝ ╚═╝  ╚═══╝╚══════╝
echo                                      v1.0.105 ENTERPRISE - LOCALHOST WINDOWS - 1 KLIK MAIN!
echo.
echo [NGPB] Starting ALL IN ONE - Server + AntiCheat Enterprise + Game Client...
echo [1/3] Starting Dedicated Server 127.0.0.1:39190 - RED Yard 8v8 Enterprise...
if exist Server\NGPB-Server-Windows.exe (
  start "NGPB Server - LOCALHOST 127.0.0.1:39190 - RED Yard ENTERPRISE" Server/NGPB-Server-Windows.exe
  timeout /t 2 /nobreak >nul
) else (
  echo [INFO] Server exe not found, trying dotnet run...
  start "NGPB Server" dotnet run --project Server/NGPB.DedicatedServer.csproj
  timeout /t 3 /nobreak >nul
)
echo [2/3] Starting Anti-Cheat Enterprise AI - HWID+IP Ban, Name Filter, Chat Filter...
if exist AntiCheat\NGPB.AntiCheat.exe (
  start "NGPB AntiCheat Enterprise - ON" AntiCheat/NGPB.AntiCheat.exe
  timeout /t 1 /nobreak >nul
)
echo [3/3] Starting Game Client ngpb.exe - RED Yard AUG A3 HP 100 AP 100 Enterprise...
if exist Game\ngpb.exe (
  cd Game
  start "NGPB Game - RED Yard - 002 7R 001 02:45 - Enterprise" ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
  cd ..
) else (
  echo [ERROR] ngpb.exe not found! Run BUILD-LOCALHOST.bat first!
  pause
  exit /b
)
echo.
echo [DONE] ALL STARTED BOS! - Server 127.0.0.1:39190 - AntiCheat Enterprise - Game RED Yard!
echo [MAIN BARENG TEMAN] Edit START-GAME.bat ganti 127.0.0.1 jadi IP PC Bos (192.168.1.5) atau IP Hamachi 25.x.x.x
echo.
pause
