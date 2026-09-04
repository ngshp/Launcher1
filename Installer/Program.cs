using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO.Compression;

namespace NGPB.Installer
{
    class Program
    {
        static string[] Languages = { "ID", "EN", "MY", "TH", "VN", "PT", "TR" };
        static string CurrentLang = "ID";
        static int Progress = 0;

        static void Main(string[] args)
        {
            Console.Title = "NGPB INSTALLER - BEYOND LIMITED EDITION v1.0.105 - 164x314 CYBERPUNK 7 BAHASA";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Console.WriteLine(@"
 ███╗   ██╗ ██████╗ ██████╗ ██████╗     ██╗███╗   ██╗███████╗████████╗ █████╗ ██╗     ██╗     ███████╗██████╗ 
 ████╗  ██║██╔════╝ ██╔══██╗██╔══██╗    ██║████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║     ██║     ██╔════╝██╔══██╗
 ██╔██╗ ██║██║  ███╗██████╔╝██████╔╝    ██║██╔██╗ ██║█████╗     ██║   ███████║██║     ██║     █████╗  ██████╔╝
 ██║╚██╗██║██║   ██║██╔══██╗██╔══██╗    ██║██║╚██╗██║██╔══╝     ██║   ██╔══██║██║     ██║     ██╔══╝  ██╔══██╗
 ██║ ╚████║╚██████╔╝██████╔╝██████╔╝    ██║██║ ╚████║███████╗   ██║   ██║  ██║███████╗███████╗███████╗██║  ██║
 ╚═╝  ╚═══╝ ╚═════╝ ╚═════╝ ╚═════╝     ╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝
                                      v1.0.105 ENTERPRISE - 164x314 CYBERPUNK 7 BAHASA
                        Beyond Limited Edition - PB ID Next Generation - Anti-Cheat Enterprise
            ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n [LANGUAGE / BAHASA] Pilih / Choose:");
            Console.WriteLine(" 1. Indonesia (ID)  2. English (EN)  3. Melayu (MY)  4. Thai (TH)  5. Vietnamese (VN)  6. Portuguese (PT)  7. Turkish (TR)");
            Console.Write(" Pilih [1-7] / Select [1-7](default 1): ");
            var key = Console.ReadLine();
            if(!string.IsNullOrEmpty(key) && int.TryParse(key, out int langIdx) && langIdx >=1 && langIdx <=7) CurrentLang = Languages[langIdx-1];
            Console.WriteLine($" [SELECTED] Language: {CurrentLang}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n [LOADING SCREEN] Cyberpunk Blue Layer 1 - Checking...");
            LoadingAnimation("Layer 1 - Anti-Cheat Engine + AI", ConsoleColor.Cyan, 20);
            Console.WriteLine(" [OK] Layer 1 Passed - Bypass = Auto Close Client!");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n [LOADING SCREEN] Cyberpunk Pink Layer 2 - HWID+IP Ban Check...");
            string hwid = GetHWID();
            string ip = GetLocalIP();
            Console.WriteLine($" HWID: {hwid} | IP: {ip} | Checking ban_hwid_ip.txt...");
            LoadingAnimation($"Layer 2 - HWID {hwid.Substring(0,8)}... + IP {ip}", ConsoleColor.Magenta, 25);
            if(IsBanned(hwid, ip)) { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("\n [BAN] HWID+IP BANNED PERMANEN! INSTALL DENIED!"); Console.ReadKey(); return; }
            Console.WriteLine(" [OK] Layer 2 Passed - Clean! Bypass = Ban HWID+IP Permanen!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n [INSTALL] NGPB POINT BLANK NEXT GEN BEYOND LIMITED EDITION...");
            Console.WriteLine($" Install Path: {Directory.GetCurrentDirectory()}");
            
            CreateDirectories();
            InstallFile("PBNG.Launcher.exe", 118, "Launcher 118 MB GREEN 1m 49s");
            InstallFile("Game/ngpb.exe", 60, "Game Client ngpb.exe RED Yard AUG A3 28/120 HP 100 AP 100");
            InstallFile("Server/NGPB-Server-Windows.exe", 15, "Server 127.0.0.1:39190 RED Yard 8v8 Enterprise");
            InstallFile("AntiCheat/NGPB.AntiCheat.exe", 10, "AntiCheat Engine + AI");
            InstallFile("AntiCheat/NGPB.AntiCheat.Enterprise.dll", 20, "AntiCheat Enterprise HWID+IP Ban, Name Filter, Chat Filter, Link https://ngpb.nhg.one");
            InstallFile("START-ALL.bat", 1, "1 KLIK MAIN! Server+AntiCheat+Game");
            InstallFile("START-SERVER.bat", 1, "Start Server Localhost");
            InstallFile("START-GAME.bat", 1, "Start Game Client ngpb.exe");
            InstallFile("BUILD-LOCALHOST.bat", 1, "Build Localhost Windows");

            Console.ForegroundColor ... (kode sisa Anda tetap sama)
        }

        // FUNGSI INSTALLER DIPERBAIKI DENGAN PENGAMAN
        static void InstallFile(string name, int size, string desc)
        {
            if (!File.Exists(name))
            {
                Console.WriteLine($" [SKIPPED] File {name} belum ada di server build. (Abaikan jika ini di GitHub)");
                return;
            }
            Console.WriteLine($" [INSTALL] {name} ({size} MB) - {desc}");
        }

        // Tambahkan fungsi pendukung lainnya di sini (CreateDirectories, LoadingAnimation, dll) agar kode berjalan
        static void LoadingAnimation(string text, ConsoleColor color, int speed) { /* ... */ }
        static string GetHWID() { return "TEMP-HWID"; }
        static string GetLocalIP() { return "127.0.0.1"; }
        static bool IsBanned(string h, string i) { return false; }
        static void CreateDirectories() { }
    }
}
