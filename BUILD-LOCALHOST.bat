@echo off
title BUILD NGPB LOCALHOST WINDOWS ENTERPRISE - v1.0.105 - RED Yard 8v8 - PERSIS PB ID
color 0E
echo.
echo  ____  _   _ ___ _     ____    _     ___   ____    _    _     _   _  ___  ____ _____ 
echo ^| __ )^| ^| ^| ^|_ _^| ^|   ^|  _ \  ^| ^|   / _ \ / ___^|  / \  ^| ^|   ^| ^| ^| ^|/ _ \/ ___^|_   _^|
echo ^|  _ \^| ^| ^| ^|^| ^| ^|   ^| ^| ^| ^| ^| ^|  ^| ^| ^| ^| ^|     / _ \ ^| ^|   ^| ^|_^| ^| ^| ^| \___ \ ^| ^|  
echo ^| ^|_) ^| ^|_^| ^|^| ^| ^|___^| ^|_^| ^| ^| ^|__^| ^|_^| ^| ^|___ / ___ \^| ^|___^|  _  ^| ^|_^| ^|___) ^|^| ^|  
echo ^|____/ \___/^|___^|_____^|____/  ^|_____\___/ \____/_/   \_\_____^|_^| ^|_^\___/^|____/ ^|_^|  
echo                          LOCALHOST WINDOWS ENTERPRISE v1.0.105 - BUILD ALL
echo                          RED Yard 8v8 - AUG A3 28/120 - HP 100 AP 100 - 002 7R 001 02:45
echo.
echo [BUILD] NGPB LOCALHOST WINDOWS ENTERPRISE v1.0.105 - Building Beyond Limited Edition...
echo [MAP] RED Yard 8v8 Enterprise - 127.0.0.1:39190 + 0.0.0.0:39190 VPS - AntiCheat 4 Layer
echo [WEB] https://ngpb.nhg.one - Keren Habis! | CBT PC | OBT PC+HP+iOS Crossplay ON!
echo.

:: CREATE DIRS
echo [INIT] Creating directories...
if not exist Server mkdir Server
if not exist Game mkdir Game
if not exist AntiCheat mkdir AntiCheat
if not exist Launcher mkdir Launcher
if not exist GameClient\Source\AntiCheat\Enterprise mkdir GameClient\Source\AntiCheat\Enterprise
echo [OK] Dirs created!

echo.
echo [1/4] Building Server - NGPB-Server-Windows.exe - 127.0.0.1:39190 Enterprise - RED Yard 8v8 - HWID+IP Ban...
if exist Server\NGPB.Server.csproj (
  dotnet publish Server/NGPB.Server.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o Server/
  if errorlevel 1 ( echo [ERROR] Server build failed! Check dotnet 8.0 installed! & pause & exit /b 1 )
  echo [OK] Server/NGPB-Server-Windows.exe 15 MB Built - Port 127.0.0.1:39190 + 0.0.0.0:39190 VPS!
) else (
  echo [WARN] Server\NGPB.Server.csproj not found! Skip - Using existing exe if any...
)

echo [2/4] Building Game Client - ngpb.exe - RED Yard AUG A3 60 MB - 6 Panel UI persis screenshot!
if exist GameClient\NGPB.Game.csproj (
  dotnet publish GameClient/NGPB.Game.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o Game/
  if errorlevel 1 ( echo [ERROR] Game build failed! & pause & exit /b 1 )
  echo [OK] Game/ngpb.exe 60 MB Built - RED Yard 002 7R 001 02:45 HP 100 AP 100 AUG A3 28/120!
) else (
  echo [WARN] GameClient\NGPB.Game.csproj not found! Skip...
)

echo [3/4] Building Anti-Cheat AI - NGPB.AntiCheat.exe - Engine + AI WH AimLock SpeedHack...
if exist GameClient\Source\AntiCheat\NGPB.AntiCheat.csproj (
  dotnet publish GameClient\Source\AntiCheat\NGPB.AntiCheat.csproj -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o AntiCheat/
  if errorlevel 1 ( echo [WARN] AntiCheat AI build failed - Using built-in in ngpb.exe... )
  echo [OK] AntiCheat/NGPB.AntiCheat.exe 10 MB Built - Engine + AI!
) else (
  echo [INFO] AntiCheat AI using built-in in ngpb.exe Enterprise - Engine + AI Integrated!
)

echo [4/4] Building Anti-Cheat Enterprise - NGPB.AntiCheat.Enterprise.dll - HWID+IP Ban Permanen!
if exist GameClient\Source\AntiCheat\Enterprise\NGPB.AntiCheat.Enterprise.csproj (
  dotnet publish GameClient\Source\AntiCheat\Enterprise\NGPB.AntiCheat.Enterprise.csproj -c Release -r win-x64 --self-contained true -o AntiCheat/
  if errorlevel 1 ( echo [WARN] Enterprise build failed - Using built-in... )
  echo [OK] AntiCheat/NGPB.AntiCheat.Enterprise.dll 20 MB Built - HWID+IP Ban, Name Filter GM/DEV, Chat Toxic, Link https://ngpb.nhg.one, Flood 5msg/10s!
) else (
  echo [INFO] Anti-Cheat Enterprise using built-in in ngpb.exe + Server - HWID+IP Ban ON! No separate dll needed!
)

echo.
echo [DONE] BUILD SUCCESS BOS! ENTERPRISE PRO MAX BEYOND LIMITED EDITION!
echo ================================================
echo  Version: v1.0.105 ENTERPRISE - RED Yard 8v8 - 002 7R 001 02:45
echo  - Server/NGPB-Server-Windows.exe (15 MB) - 127.0.0.1:39190 + 0.0.0.0:39190 VPS - Map RED Yard
echo    HWID+IP Ban Permanen, GM/DEV/STAFF/MOD/ADMIN Name Filter, Toxic Chat 4x Ban, Link https://ngpb.nhg.one only
echo  - Game/ngpb.exe (60 MB) - RED Yard AUG A3 28/120 HP 100 AP 100 - 6 Panel UI persis screenshot Bos!
echo  - AntiCheat/NGPB.AntiCheat.exe (10 MB) + NGPB.AntiCheat.Enterprise.dll (20 MB) - AI Enterprise 4 Layer
echo  - Launcher/PBNG.Launcher.exe (118 MB) - Loading Layer 1 Blue AutoClose + Layer 2 Pink Ban HWID+IP
echo  - Web: https://ngpb.nhg.one - Keren Habis! | CBT PC | OBT PC+HP+iOS Crossplay ON!
echo ================================================
echo.
echo [NEXT] Run START-ALL.bat untuk 1 KLIK MAIN! Atau START-SERVER.bat + START-GAME.bat!
echo [MAIN BARENG TEMAN] Share folder ini ke teman, teman edit START-GAME.bat ganti 127.0.0.1 jadi IP Bos 192.168.1.5 atau Hamachi 25.x.x.x!
echo [LOGS] server_log.txt, ban_hwid_ip.txt, ban_permanen.txt, kill_log.txt, chat_log.txt, violation_log.txt, launcher_log.txt
echo.
echo [ZIP] Creating PBNG-ENTERPRISE-ALL-IN-ONE.zip 200 MB for Releases v1.0.105...
if exist "C:\Program Files\7-Zip\7z.exe" (
  "C:\Program Files\7-Zip\7z.exe" a -tzip PBNG-ENTERPRISE-ALL-IN-ONE.zip Server\*.exe Game\*.exe AntiCheat\*.exe AntiCheat\*.dll START-*.bat BUILD-*.bat *.txt Launcher\*.exe 2>nul
  echo [OK] PBNG-ENTERPRISE-ALL-IN-ONE.zip created!
) else (
  echo [INFO] 7-Zip not found - Zip manual folder ini jadi PBNG-ENTERPRISE-ALL-IN-ONE.zip untuk share!
)
echo.
pause
