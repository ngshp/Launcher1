@echo off
echo [NGPB] Starting ALL IN ONE - Server + AntiCheat + Game Client...
start "NGPB Server - 127.0.0.1:39190" Server/NGPB-Server-Windows.exe
timeout /t 2
start "NGPB AntiCheat AI - ON" AntiCheat/NGPB.AntiCheat.exe
cd Game
start "NGPB Game - RED Yard" ngpb.exe --server 127.0.0.1:39190 --user NGPB_Player
cd..
echo DONE! Main bareng teman: Ganti 127.0.0.1 jadi IP PC Bos di START-GAME.bat!
pause
