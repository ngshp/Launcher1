@echo off
title NGPB SERVER - LOCALHOST WINDOWS - RED Yard 8v8 - v1.0.105 ENTERPRISE - 127.0.0.1:39190 + 0.0.0.0:39190 VPS
color 0A
echo.
echo  _   _  ____ ____  ____    _     ___   ____    _    _     _   _  ___  ____ _____ 
echo ^| \ ^| ^|/ ___^|  _ \ ^| __ )  ^| ^|   / _ \ / ___^|  / \  ^| ^|   ^| ^| ^| ^|/ _ \/ ___^|_   _^|
echo ^|  \ ^| ^| ^|  _^| ^|_) ^|  _ \  ^| ^|  ^| ^| ^| ^| ^|     / _ \ ^| ^|   ^| ^|_^| ^| ^| ^| \___ \ ^| ^|  
echo ^| ^|\  ^| ^|_^| ^|  __/ ^| ^|_) ^| ^| ^|__^| ^|_^| ^| ^|___ / ___ \^| ^|___^|  _  ^| ^|_^| ^|___) ^|^| ^|  
echo ^|_^| \_^\____^|_^|   ^|____/  ^|_____\___/ \____/_/   \_\_____^|_^| ^|_^\___/^|____/ ^|_^|  
echo                          LOCALHOST WINDOWS ENTERPRISE v1.0.105 - RED Yard 8v8
echo.
echo [SERVER] Starting NGPB Dedicated Server - Beyond Limited Edition - Persis PB ID!
echo [SERVER] Map: RED Yard - 8v8 - 002 7R 001 02:45 - HP 100 AP 100 - AUG A3 28/120 - AntiCheat HWID+IP Ban
echo [SERVER] Port: 127.0.0.1:39190 Localhost + 0.0.0.0:39190 VPS - Biar teman connect!
echo [SERVER] Allowed Link: https://ngpb.nhg.one only! - Name Filter GM/DEV/STAFF/MOD/ADMIN - Chat Toxic Filter
echo [SERVER] Web: https://ngpb.nhg.one - Keren Habis! | CBT PC | OBT PC+HP+iOS Crossplay ON!
echo.

:: CHECK BAN
if exist ban_hwid_ip.txt (
  echo [SECURITY] Checking ban_hwid_ip.txt...
)

echo [1/2] Checking Server exe...
if exist Server\NGPB-Server-Windows.exe (
  echo [OK] Found Server\NGPB-Server-Windows.exe 15 MB - RED Yard Enterprise!
  cd Server
  echo [2/2] Starting Server 0.0.0.0:39190 + 127.0.0.1:39190 - RED Yard 8v8 - AntiCheat Enterprise ON...
  start "NGPB Server - RED Yard 8v8 - 127.0.0.1:39190 + 0.0.0.0:39190 ENTERPRISE - Map 002 7R 001 02:45" NGPB-Server-Windows.exe
  cd ..
  timeout /t 2 /nobreak >nul
  echo [DONE] Server Running Bos! Check window "NGPB Server"!
) else if exist Server\NGPB-Server.exe (
  cd Server
  start "NGPB Server - RED Yard" NGPB-Server.exe
  cd ..
  timeout /t 2 /nobreak >nul
) else (
  echo [ERROR] Server not found! Build dulu Bos!
  echo [INFO] Run: BUILD-LOCALHOST.bat atau download PBNG-ENTERPRISE-ALL-IN-ONE.zip 200 MB dari Releases v1.0.105!
  echo [INFO] Atau coba dotnet run:
  if exist Server\NGPB.Server.csproj (
    echo [TRY] dotnet run --project Server/NGPB.Server.csproj
    start "NGPB Server - DOTNET" cmd /c "dotnet run --project Server/NGPB.Server.csproj"
  ) else (
    pause
    exit /b
  )
)

echo.
echo [SERVER] Server started! Now run START-GAME.bat to play!
echo [INFO] Local: 127.0.0.1:39190 | Hamachi: 25.x.x.x:39190 | VPS: 0.0.0.0:39190
echo [INFO] Main bareng teman: Edit START-GAME.bat ganti 127.0.0.1 jadi IP PC Bos (192.168.1.x) atau Hamachi 25.x.x.x
echo [LOGS] server_log.txt, ban_hwid_ip.txt, kill_log.txt, chat_log.txt, violation_log.txt
echo.
pause
