@echo off
title NGPB SERVER - LOCALHOST WINDOWS - RED Yard 8v8 - v1.0.105 ENTERPRISE
color 0A
echo.
echo  _   _  ____ ____  ____    _     ___   ____    _    _     _   _  ___  ____ _____ 
echo ^| \ ^| ^|/ ___^|  _ \ ^| __ )  ^| ^|   / _ \ / ___^|  / \  ^| ^|   ^| ^| ^| ^|/ _ \/ ___^|_   _^|
echo ^|  \ ^| ^| ^|  _^| ^|_) ^|  _ \  ^| ^|  ^| ^| ^| ^| ^|     / _ \ ^| ^|   ^| ^|_^| ^| ^| ^| \___ \ ^| ^|  
echo ^| ^|\  ^| ^|_^| ^|  __/ ^| ^|_) ^| ^| ^|__^| ^|_^| ^| ^|___ / ___ \^| ^|___^|  _  ^| ^|_^| ^|___) ^|^| ^|  
echo ^|_^| \_^\____^|_^|   ^|____/  ^|_____\___/ \____/_/   \_\_____^|_^| ^|_^\___/^|____/ ^|_^|  
echo                          LOCALHOST WINDOWS ENTERPRISE v1.0.105
echo.
echo [SERVER] Starting NGPB Dedicated Server - Localhost Windows Enterprise...
echo [SERVER] Map: RED Yard - 8v8 - 002 7R 001 02:45 - HP 100 AP 100 - AntiCheat HWID+IP
echo [SERVER] Port: 127.0.0.1:39190 - Allowed Link: https://ngpb.nhg.one only!
echo.
if exist Server\NGPB-Server-Windows.exe (
  cd Server
  start "NGPB Server - RED Yard 8v8 - 127.0.0.1:39190 ENTERPRISE" NGPB-Server-Windows.exe
  cd ..
) else (
  echo [ERROR] Server not found! Build dulu: BUILD-LOCALHOST.bat
  pause
  exit /b
)
echo [SERVER] Server started! Check window "NGPB Server" - Now run START-GAME.bat!
pause
