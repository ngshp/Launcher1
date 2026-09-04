@echo off
title NGPB GAME CLIENT - LOCALHOST WINDOWS - ngpb.exe v1.0.105 ENTERPRISE
color 0B
echo.
echo  _   _  ____ ____  ____  
echo ^| \ ^| ^|/ ___^|  _ \ ^| __ ) 
echo ^|  \ ^| ^| ^|  _^| ^|_) ^|  _ \ 
echo ^| ^|\  ^| ^|_^| ^|  __/ ^| ^|_) ^|
echo ^|_^| \_^\____^|_^|   ^|____/  Point Blank 3D - ENTERPRISE v1.0.105
echo.
echo [GAME] Launching ngpb.exe - RED Yard - AUG A3 28/120 - HP 100 AP 100 Enterprise
echo [GAME] Server: 127.0.0.1:39190 - AntiCheat Enterprise HWID+IP Ban ON
echo [GAME] Link Allowed: https://ngpb.nhg.one only! - GM Name Filter ON!
echo.
netstat -an | find "127.0.0.1:39190" >nul
if errorlevel 1 (
  echo [WARNING] Server not running! Starting server first...
  call START-SERVER.bat
  timeout /t 2
)
echo [GAME] Starting Anti-Cheat Enterprise AI...
if exist AntiCheat\NGPB.AntiCheat.exe (
  start "NGPB AntiCheat Enterprise - Protecting ngpb.exe - HWID+IP" AntiCheat\NGPB.AntiCheat.exe
  echo [ANTI-CHEAT] Enterprise AI Started - HWID Ban, IP Ban, GM Name, Chat Filter, Link Filter!
)
echo [GAME] Starting ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
if exist Game\ngpb.exe (
  cd Game
  start "NGPB Game Client - RED Yard - 002 7R 001 02:45 Enterprise" ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
  cd ..
) else (
  echo [ERROR] ngpb.exe not found! Build dulu: BUILD-LOCALHOST.bat
  pause
  exit /b
)
echo.
echo [GAME] DONE! Game launched!
echo [MAIN BARENG TEMAN] Ganti 127.0.0.1 jadi IP PC Bos (192.168.1.5) atau Hamachi 25.x.x.x di file ini!
echo.
pause
