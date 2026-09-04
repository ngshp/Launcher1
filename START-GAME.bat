@echo off
title NGPB GAME CLIENT - LOCALHOST WINDOWS - ngpb.exe v1.0.105 ENTERPRISE - RED Yard 8v8 AUG A3 28/120 HP 100 AP 100
color 0B
echo.
echo  _   _  ____ ____  ____  
echo ^| \ ^| ^|/ ___^|  _ \ ^| __ ) 
echo ^|  \ ^| ^| ^|  _^| ^|_) ^|  _ \ 
echo ^| ^|\  ^| ^|_^| ^|  __/ ^| ^|_) ^|
echo ^|_^| \_^\____^|_^|   ^|____/  Point Blank 3D - ENTERPRISE v1.0.105 - Beyond Limited Edition
echo                         RED Yard 8v8 - 002 7R 001 02:45 - AUG A3 28/120 - HP 100 AP 100
echo.
echo [GAME] Launching ngpb.exe - RED Yard - AUG A3 28/120 - HP 100 AP 100 Enterprise - Persis PB ID!
echo [GAME] Server: 127.0.0.1:39190 Localhost + 0.0.0.0:39190 VPS - Edit IP di file ini buat main bareng teman!
echo [GAME] AntiCheat Enterprise HWID+IP Ban ON - Link Allowed: https://ngpb.nhg.one only! - GM Name Filter ON!
echo [WEB] https://ngpb.nhg.one - Keren Habis! | CBT PC | OBT PC+HP+iOS Crossplay ON!
echo.

:: ========== SETTING IP BOS - GANTI DI SINI BUAT MAIN BARENG TEMAN ==========
:: Localhost: 127.0.0.1 - Main sendiri di PC Bos
:: LAN: 192.168.1.5 (ganti jadi IP PC Bos) - Main bareng teman 1 WiFi
:: Hamachi: 25.x.x.x (ganti jadi IP Hamachi Bos) - Main bareng teman beda kota
:: VPS: IP VPS Bos (contoh 20.20.20.20) - Main bareng teman internet
set SERVER_IP=127.0.0.1
set SERVER_PORT=39190
set PLAYER_NAME=NGPB_Boss
:: ========== END SETTING ==========

echo [SETTING] Server IP: %SERVER_IP%:%SERVER_PORT% - Player: %PLAYER_NAME%
echo [INFO] Main bareng teman? Edit file ini: set SERVER_IP=192.168.1.5 atau 25.x.x.x Hamachi!

:: CHECK SERVER RUNNING 127.0.0.1:39190
echo [CHECK] Checking server %SERVER_IP%:%SERVER_PORT% RED Yard...
netstat -an | find "%SERVER_IP%:%SERVER_PORT%" >nul
if errorlevel 1 (
  netstat -an | find "0.0.0.0:%SERVER_PORT%" >nul
  if errorlevel 1 (
    echo [WARNING] Server %SERVER_IP%:%SERVER_PORT% not running! Starting server first...
    echo [INFO] Calling START-SERVER.bat...
    call START-SERVER.bat
    timeout /t 3 /nobreak >nul
  ) else (
    echo [OK] Server 0.0.0.0:%SERVER_PORT% Running (VPS mode) - Ready!
  )
) else (
  echo [OK] Server %SERVER_IP%:%SERVER_PORT% Running - Map RED Yard 8v8!
)

:: CHECK BAN HWID+IP
if exist ban_hwid_ip.txt (
  echo [SECURITY] Checking ban_hwid_ip.txt - HWID+IP Ban...
  findstr /C:"%COMPUTERNAME%" ban_hwid_ip.txt >nul && (
    color 0C
    echo [BAN] PC Bos %COMPUTERNAME% BANNED PERMANEN! GAME DENIED!
    pause
    exit /b
  )
)

echo [GAME] Starting Anti-Cheat Enterprise AI - Engine + AI + HWID+IP Ban...
if exist AntiCheat\NGPB.AntiCheat.exe (
  start "NGPB AntiCheat Enterprise - Protecting ngpb.exe - HWID+IP - %SERVER_IP%:%SERVER_PORT%" /min AntiCheat\NGPB.AntiCheat.exe
  echo [OK] Anti-Cheat Enterprise AI Started - HWID Ban, IP Ban, GM Name, Chat Toxic, Link https://ngpb.nhg.one, Flood!
  timeout /t 1 /nobreak >nul
) else (
  echo [INFO] AntiCheat exe not found - Using built-in AntiCheat in ngpb.exe Enterprise! HWID+IP Ban ON!
)

echo [GAME] Starting ngpb.exe --server %SERVER_IP%:%SERVER_PORT% --user %PLAYER_NAME% --anticheat enterprise --map RED_Yard
echo [HUD] 002 7R 001 02:45 - HP 100 AP 100 - AUG A3 %AMMO%/%AMMO_RESERVE% - Minimap RED Yard - Kill Feed - 6 Panel UI!

if exist Game\ngpb.exe (
  cd Game
  echo [OK] Launching Game\ngpb.exe --server %SERVER_IP%:%SERVER_PORT% --user %PLAYER_NAME%
  start "NGPB Game Client - RED Yard - 002 7R 001 02:45 - AUG A3 28/120 - Enterprise - %SERVER_IP%:%SERVER_PORT%" ngpb.exe --server %SERVER_IP%:%SERVER_PORT% --user %PLAYER_NAME%
  cd ..
) else if exist ngpb.exe (
  start "NGPB Game - RED Yard" ngpb.exe --server %SERVER_IP%:%SERVER_PORT% --user %PLAYER_NAME%
) else (
  echo [ERROR] ngpb.exe not found! Build dulu Bos!
  echo [INFO] Run: BUILD-LOCALHOST.bat atau download PBNG-ENTERPRISE-ALL-IN-ONE.zip 200 MB dari Releases v1.0.105!
  echo [INFO] Atau coba dotnet run:
  if exist GameClient/NGPB.Game.csproj (
    echo [TRY] dotnet run --project GameClient/NGPB.Game.csproj -- --server %SERVER_IP%:%SERVER_PORT%
    start "NGPB Game - DOTNET" cmd /c "dotnet run --project GameClient/NGPB.Game.csproj -- --server %SERVER_IP%:%SERVER_PORT% --user %PLAYER_NAME%"
  ) else (
    pause
    exit /b
  )
)

echo.
echo [GAME] DONE! Game launched Bos! RED Yard 002 7R 001 02:45 HP 100 AP 100 AUG A3 28/120!
echo ================================================
echo  SERVER: %SERVER_IP%:%SERVER_PORT% - MAP: RED Yard - MODE: 8v8 Enterprise
echo  PLAYER: %PLAYER_NAME% - WEAPON: AUG A3 28/120 - HP 100 AP 100
echo  ANTI-CHEAT: Engine ON, AI ON, Enterprise HWID
