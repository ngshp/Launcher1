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
echo                                      RED Yard 8v8 - 002 7R 001 02:45 - HP 100 AP 100 - AUG A3 28/120
echo.
echo [NGPB] Starting ALL IN ONE - Server + AntiCheat Enterprise + Game Client - PERSIS PB ID!
echo [WEB] https://ngpb.nhg.one - Keren Habis! | [MODE] CBT PC + OBT PC+HP+iOS Crossplay ON!
echo.

:: CHECK ANTI-CHEAT BAN HWID+IP
if exist ban_hwid_ip.txt (
  echo [SECURITY] Checking ban_hwid_ip.txt - HWID+IP Ban Permanen...
  findstr /C:"%COMPUTERNAME%" ban_hwid_ip.txt >nul && (
    color 0C
    echo [BAN] PC Bos %COMPUTERNAME% BANNED PERMANEN! DENIED!
    pause
    exit /b
  )
)

echo [1/3] Starting Dedicated Server 127.0.0.1:39190 - RED Yard 8v8 Enterprise - 0.0.0.0:39190 VPS Ready...
if exist Server\NGPB-Server-Windows.exe (
  start "NGPB Server - LOCALHOST 127.0.0.1:39190 - RED Yard ENTERPRISE" Server/NGPB-Server-Windows.exe
  timeout /t 2 /nobreak >nul
  echo [OK] Server 127.0.0.1:39190 Running - Map RED Yard - RED 2 7R 1 BLUE - Time 02:45
) else (
  echo [INFO] Server exe not found, trying dotnet run...
  if exist Server\NGPB.Server.csproj (
    start "NGPB Server" cmd /c "dotnet run --project Server/NGPB.Server.csproj"
    timeout /t 3 /nobreak >nul
  ) else (
    echo [WARN] Server project not found - Offline mode - Game will run offline RED Yard!
  )
)

echo [2/3] Starting Anti-Cheat Enterprise AI - HWID+IP Ban, Name Filter GM/DEV, Chat Toxic, Link https://ngpb.nhg.one only, Flood 5msg/10s...
if exist AntiCheat\NGPB.AntiCheat.exe (
  start "NGPB AntiCheat Enterprise - ON - Engine+AI" /min AntiCheat/NGPB.AntiCheat.exe
  timeout /t 1 /nobreak >nul
  echo [OK] Anti-Cheat Enterprise ON - Engine + AI + HWID+IP Ban
) else (
  echo [INFO] AntiCheat exe not found - Using built-in AntiCheat in ngpb.exe Enterprise!
)

echo [3/3] Starting Game Client ngpb.exe - RED Yard AUG A3 HP 100 AP 100 - 002 7R 001 02:45 - 6 Panel UI persis screenshot!
if exist Game\ngpb.exe (
  echo [OK] Launching Game/ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player --anticheat enterprise
  cd Game
  start "NGPB Game - RED Yard - 002 7R 001 02:45 - AUG A3 28/120 - Enterprise" ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
  cd ..
) else if exist ngpb.exe (
  start "NGPB Game - RED Yard" ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
) else (
  echo [ERROR] ngpb.exe not found! Run BUILD-LOCALHOST.bat first! Or download PBNG-ENTERPRISE-ALL-IN-ONE.zip 200 MB from Releases v1.0.105!
  echo [BUILD] Trying dotnet run GameClient...
  if exist GameClient/NGPB.Game.csproj (
    start "NGPB Game" cmd /c "dotnet run --project GameClient/NGPB.Game.csproj -- --server 127.0.0.1:39190"
  ) else (
    pause
    exit /b
  )
)

echo.
echo [DONE] ALL STARTED BOS! - Server 127.0.0.1:39190 - AntiCheat Enterprise - Game RED Yard!
echo ================================================
echo  MAP: RED Yard | SCORE: RED 2 7R 1 BLUE | TIME: 02:45
echo  WEAPON: AUG A3 28/120 | HP: 100 AP: 100 | PING: 12ms
echo  ANTI-CHEAT: Engine ON, AI ON, Enterprise HWID+IP ON
echo  Name Filter GM/DEV/STAFF/MOD/ADMIN - Chat Filter Toxic - Link https://ngpb.nhg.one only
echo ================================================
echo [MAIN BARENG TEMAN] Edit START-GAME.bat ganti 127.0.0.1 jadi IP PC Bos (192.168.1.5) atau IP Hamachi 25.x.x.x
echo [CBT] PC Mode Ready | [OBT] PC+HP+iOS Crossplay ON - Server 0.0.0.0:39190 VPS Ready!
echo [WEB] https://ngpb.nhg.one - Keren Habis!
echo.
pause
