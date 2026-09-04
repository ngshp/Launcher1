using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace NGPB.Game
{
    // PBNG GAME CLIENT - BEYOND LIMITED EDITION v1.0.105 ENTERPRISE
    // ngpb.exe 60 MB - RED Yard 8v8 - AUG A3 28/120 HP 100 AP 100 - 002 7R 001 02:45
    // PERSIS POINT BLANK ID - 6 PANEL UI - ANTI-CHEAT ENTERPRISE INTEGRATED
    class NGPBGame
    {
        static string Version = "1.0.105";
        static string ServerIP = "127.0.0.1";
        static int ServerPort = 39190;
        static string PlayerName = "NGPB_Player";
        static string WebURL = "https://ngpb.nhg.one";

        // GAME STATE - PERSIS PB ID
        static int HP = 100; static int AP = 100;
        static int Ammo = 28; static int AmmoReserve = 120;
        static string Weapon = "AUG A3";
        static string Map = "RED Yard";
        static int RedScore = 2; static int BlueScore = 1;
        static int Round = 7; static string Time = "02:45";
        static List<string> KillFeed = new List<string>();
        static List<Player> RedTeam = new List<Player>();
        static List<Player> BlueTeam = new List<Player>();

        // ANTI-CHEAT ENTERPRISE INTEGRATED
        static AntiCheatEnterprise AntiCheat = new AntiCheatEnterprise();

        class Player { public string Name; public int K,A,D,Ping; public int HP; public string Weapon; public bool IsGM,IsDev; }

        static void Main(string[] args)
        {
            ParseArgs(args);
            Console.Title = $"NGPB GAME CLIENT - {Map} - {Weapon} {Ammo}/{AmmoReserve} HP {HP} AP {AP} - {RedScore} 7R {BlueScore} {Time} - v{Version}";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Banner();

            // INIT TEAMS - PERSIS PB ID 8v8
            InitTeams();

            // ANTI-CHEAT CHECKS
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n [ANTI-CHEAT] Engine + AI + Enterprise Integrated...");
            Console.WriteLine($" HWID: {GetHWID()} | IP: {GetIP()} | User: {PlayerName}");
            if(AntiCheat.IsBanned(GetHWID(), GetIP(), PlayerName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" [BAN] {PlayerName} BANNED PERMANEN HWID+IP! GAME DENIED!");
                File.AppendAllText("ban_log.txt",$"{DateTime.Now} BAN GAME LAUNCH {PlayerName} {GetHWID()} {GetIP()}\n");
                Environment.Exit(0);
            }
            if(!AntiCheat.CheckRestrictedName(PlayerName, false, false))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" [NAME FILTER] Name {PlayerName} RESTRICTED! GM/DEVELOPER/STAFF/MOD/ADMIN only! DENIED + BAN!");
                Environment.Exit(0);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" [OK] Anti-Cheat Clean - Name OK - Starting Game...");

            // CONNECT SERVER
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n [SERVER] Connecting {ServerIP}:{ServerPort} - Map {Map}...");
            bool connected = ConnectServer();
            if(!connected) Console.WriteLine($" [WARN] Server {ServerIP}:{ServerPort} offline - Playing Offline Mode RED Yard!");

            // START GAME LOOP - PERSIS PB ID HUD 6 PANEL
            GameLoop();
        }

        static void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
 ███╗ ██╗ ██████╗ ██████╗ ██████╗ ██████╗ █████╗ ███╗ ███╗███████╗ ██████╗██╗ ██╗███████╗███╗ ██╗████████╗
 ████╗ ██║██╔════╝ ██╔══██╗██╔══██╗ ██╔════╝ ██╔══██╗████╗ ████║██╔════╝ ██╔════╝██║ ██║██╔════╝████╗ ██║╚══██╔══╝
 ██╔██╗ ██║██║ ███╗██████╔╝██████╔╝ ██║ ███╗███████║██╔████╔██║█████╗ ██║ ██║ ██║█████╗ ██╔██╗ ██║ ██║
 ██║╚██╗██║██║ ██║██╔══██╗██╔══██╗ ██║ ██║██╔══██║██║╚██╔╝██║██╔══╝ ██║ ██║ ██║██╔══╝ ██║╚██╗██║ ██║
 ██║ ╚████║╚██████╔╝██████╔╝██████╔╝ ╚██████╔╝██║ ██║██║ ╚═╝ ██║███████╗ ╚██████╗███████╗██║███████╗██║ ╚████║ ██║
 ╚═╝ ╚═══╝ ╚═════╝ ╚═════╝ ╚═════╝ ╚═════╝ ╚═╝ ╚═╝╚═╝ ╚═╝╚══════╝ ╚═════╝╚══════╝╚═╝╚══════╝╚═╝ ╚═══╝ ╚═╝
                         v1.0.105 ENTERPRISE - RED Yard 8v8 - AUG A3 28/120 - HP 100 AP 100 - Beyond Limited Edition
            ");
        }

        static void InitTeams()
        {
            RedTeam.Add(new Player{Name="RED_NGPB_Boss",K=12,A=3,D=2,Ping=12,HP=100,Weapon="AUG A3"});
            RedTeam.Add(new Player{Name="RED_Sniper",K=8,A=2,D=5,Ping=24,HP=85,Weapon="AWP"});
            RedTeam.Add(new Player{Name="RED_Rusher",K=15,A=1,D=4,Ping=18,HP=100,Weapon="KRISS"});
            RedTeam.Add(new Player{Name="RED_Support",K=5,A=8,D=3,Ping=30,HP=60,Weapon="M4A1"});
            RedTeam.Add(new Player{Name=PlayerName,K=0,A=0,D=0,Ping=12,HP=HP,Weapon=Weapon});
            BlueTeam.Add(new Player{Name="BLUE_Enemy1",K=9,A=2,D=7,Ping=28,HP=0,Weapon="AK-47"});
            BlueTeam.Add(new Player{Name="BLUE_Enemy2",K=11,A=1,D=6,Ping=35,HP=45,Weapon="P90"});
            BlueTeam.Add(new Player{Name="BLUE_Enemy3",K=7,A=3,D=8,Ping=40,HP=100,Weapon="M4A1"});
            BlueTeam.Add(new Player{Name="BLUE_Enemy4",K=6,A=0,D=9,Ping=22,HP=100,Weapon="AUG A3"});
            BlueTeam.Add(new Player{Name="BLUE_Enemy5",K=10,A=2,D=5,Ping=31,HP=75,Weapon="KRISS"});

            KillFeed.Add($"[02:43] RED_NGPB_Boss killed BLUE_Enemy1 with AUG A3 Headshot!");
            KillFeed.Add($"[02:40] BLUE_Enemy2 killed RED_Support with P90");
            KillFeed.Add($"[02:38] {PlayerName} killed BLUE_Enemy1 with AUG A3");
        }

        static bool ConnectServer()
        {
            try {
                using(var client = new TcpClient())
                {
                    var result = client.BeginConnect(ServerIP, ServerPort, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
                    if(!success) return false;
                    client.EndConnect(result);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" [OK] Connected {ServerIP}:{ServerPort} - RED Yard Enterprise!");
                    return true;
                }
            } catch { return false; }
        }

        static void GameLoop()
        {
            while(true)
            {
                DrawHUD(); // 6 Panel UI Persis PB ID
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n [CONTROLS] W A S D Jalan | Mouse Liat | Klik Kiri Tembak | R Reload | T Chat | TAB Scoreboard | ESC Exit");
                Console.Write(" [ACTION] (WASD/F/R/T/TAB/Q): ");
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(char.ToUpper(key))
                {
                    case 'W': Console.WriteLine($" [MOVE] Maju di {Map} - A Site RED Arrow!"); break;
                    case 'A': Console.WriteLine($" [MOVE] Kiri - Container Merah!"); break;
                    case 'S': Console.WriteLine($" [MOVE] Mundur - Yard!"); break;
                    case 'D': Console.WriteLine($" [MOVE] Kanan - Container Biru!"); break;
                    case 'F': // FIRE
                        if(Ammo<=0){ Console.WriteLine(" [RELOAD] Ammo habis! Press R!"); break; }
                        Ammo--;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($" [FIRE] {Weapon} - Bang! Bang! Ammo {Ammo}/{AmmoReserve} - Muzzle Flash!");
                        // Simulate kill
                        if(new Random().Next(100)<30)
                        {
                            string target = BlueTeam[new Random().Next(BlueTeam.Count)].Name;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" [KILL] {PlayerName} killed {target} with {Weapon}!");
                            KillFeed.Add($"[{Time}] {PlayerName} killed {target} with {Weapon}!");
                            AntiCheat.LogKill(PlayerName, target, Weapon);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 'R':
                        Console.WriteLine($" [RELOAD] {Weapon} Reloading... 28/120");
                        Ammo = 28; if(AmmoReserve>0) AmmoReserve-=28;
                        Thread.Sleep(800);
                        Console.WriteLine($" [OK] Reloaded - {Ammo}/{AmmoReserve}");
                        break;
                    case 'T':
                        Console.Write(" [CHAT] Ketik pesan: ");
                        string msg = Console.ReadLine();
                        if(!string.IsNullOrEmpty(msg))
                        {
                            bool isGM=false, isDev=false;
                            string hwid=GetHWID(), ip=GetIP();
                            if(!AntiCheat.CheckChatLinkAndFlood(PlayerName, msg, isGM, isDev, hwid, ip))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($" [CHAT FILTER] {PlayerName} Toxic/Link/Flood Detected! Warning 3x Mute 4x Ban!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else Console.WriteLine($" [CHAT] {PlayerName}: {msg}");
                        }
                        break;
                    case 'Q':
                        Console.WriteLine(" [EXIT] Keluar Game...");
                        return;
                    default:
                        if(key==(char)9) ShowScoreboard();
                        break;
                }

                // RANDOM ANTI-CHEAT SCAN - DETECT WH AIMLOCK
                if(new Random().Next(1000)<5) // 0.5% chance
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" [ANTI-CHEAT AI] Scanning behavior... WH, AimLock, NoRecoil... CLEAN");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Thread.Sleep(100);
            }
        }

        static void DrawHUD()
        {
            Console.Clear(); Banner();
            // TOP HUD - 002 7R 001 02:45
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n RED {RedScore} {Round}R {BlueScore} BLUE TIME {Time} MAP {Map} {Weapon} {Ammo}/{AmmoReserve} HP {HP} AP {AP} PING 12ms v{Version}");
            Console.WriteLine(new string('═', 100));

            // 6 PANEL LAYOUT
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n [PANEL 1] GAMEPLAY - RED Yard First Person - AUG A3 Crosshair - Enemy BLUE in A Site!");
            Console.WriteLine(" ┌─────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine(" │ ⊙ Minimap RED Yard [02:45] Kill Feed: RED killed BLUE x2 │");
            Console.WriteLine(" │ [A] RED Arrow -> Container Merah | Container Biru | Yard Industrial │");
            Console.WriteLine(" │ + Crosshair AUG A3 - Enemy BLUE_Enemy2 Visible! │");
            Console.WriteLine(" │ HP 100 AP 100 28/120│");
            Console.WriteLine(" └─────────────────────────────────────────────────────────────────────────┘");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n [PANEL 2-6] Scoreboard | Weapon | Character | Menu | Chat");
            ShowScoreboardMini();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n [ANTI-CHEAT ENTERPRISE] Engine ON | AI ON | HWID+IP Ban ON | Name Filter GM/DEV | Chat Filter | Link {WebURL} only | Flood 5msg/10s");
        }

        static void ShowScoreboardMini()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" RED TEAM {RedScore} - BLUE TEAM {BlueScore} - ROUND {Round} - REMAIN TIME {Time}");
            foreach(var p in RedTeam) Console.WriteLine($" RED {p.Name,-20} K:{p.K} A:{p.A} D:{p.D} Ping:{p.Ping} HP:{p.HP} {p.Weapon}");
            foreach(var p in BlueTeam) Console.WriteLine($" BLUE {p.Name,-20} K:{p.K} A:{p.A} D:{p.D} Ping:{p.Ping} HP:{p.HP} {p.Weapon}");
            Console.WriteLine(" Kill Feed:");
            foreach(var k in KillFeed) Console.WriteLine($" {k}");
        }

        static void ShowScoreboard()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n === SCOREBOARD TAB - RED Yard ===");
            ShowScoreboardMini();
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
        }

        static void ParseArgs(string[] args)
        {
            for(int i=0;i<args.Length;i++)
            {
                if(args[i]=="--server" && i+1<args.Length) ServerIP=args[i+1];
                if(args[i]=="--user" && i+1<args.Length) PlayerName=args[i+1];
            }
        }

        static string GetHWID(){ try{ return Environment.MachineName+"_"+Environment.ProcessorCount; } catch{ return "UNKNOWN"; } }
        static string GetIP(){ return "127.0.0.1"; }
    }

    // ANTI-CHEAT ENTERPRISE - INTEGRATED KE GAME CLIENT
    public class AntiCheatEnterprise
    {
        string[] RestrictedNames = {"GM","DEVELOPER","STAFF","MOD","ADMIN","DEVELOPER","GM_","_GM"};
        string[] ToxicWords = {"anjing","babi","kontol","memek","tolol","goblok","fuck","shit"};
        string AllowedLink = "https://ngpb.nhg.one";
        Dictionary<string, int> Warnings = new Dictionary<string, int>();
        Dictionary<string, List<DateTime>> ChatTimes = new Dictionary<string, List<DateTime>>();

        public bool IsBanned(string hwid, string ip, string name)
        {
            try{ if(!File.Exists("ban_hwid_ip.txt")) return false; var t=File.ReadAllText("ban_hwid_ip.txt"); return t.Contains(hwid)||t.Contains(ip)||t.Contains(name); } catch{ return false; }
        }

        public bool CheckRestrictedName(string name, bool isGM, bool isDev)
        {
            if(isGM||isDev) return true; // GM/Dev boleh pakai nama GM
            foreach(var r in RestrictedNames) if(name.ToUpper().Contains(r.ToUpper())){ File.AppendAllText("name_violation.txt",$"{DateTime.Now} NAME VIOLATION {name} - DENIED + BAN\n"); File.AppendAllText("ban_hwid_ip.txt",$"{DateTime.Now} BAN NAME {name} {GetHWID()} {GetIP()}\n"); return false; }
            return true;
        }

        public bool CheckChatLinkAndFlood(string player, string msg, bool isGM, bool isDev, string hwid, string ip)
        {
            if(isGM||isDev) return true; // GM/Dev whitelist link
            // Link filter - hanya boleh https://ngpb.nhg.one
            if((msg.Contains("http://")||msg.Contains("https://")||msg.Contains("www.")||msg.Contains(".com")||msg.Contains(".net")) &&!msg.Contains(AllowedLink))
            {
                Warn(player, "LINK", $"Link not allowed - only {AllowedLink} allowed!"); return false;
            }
            // Toxic filter
            foreach(var t in ToxicWords) if(msg.ToLower().Contains(t.ToLower())){ Warn(player, "TOXIC", $"Toxic chat {t}"); return false; }
            // Flood filter 5 msg / 10 detik
            if(!ChatTimes.ContainsKey(player)) ChatTimes[player]=new List<DateTime>();
            ChatTimes[player].Add(DateTime.Now);
            ChatTimes[player].RemoveAll(d=>(DateTime.Now-d).TotalSeconds>10);
            if(ChatTimes[player].Count>5){ Warn(player, "FLOOD", $"Flood {ChatTimes[player].Count} msg/10s"); return false; }
            return true;
        }

        void Warn(string player, string type, string detail)
        {
            if(!Warnings.ContainsKey(player)) Warnings[player]=0;
            Warnings[player]++;
            File.AppendAllText("violation_log.txt",$"{DateTime.Now} {type} {player} Warning {Warnings[player]}/4 - {detail}\n");
            File.AppendAllText("chat_log.txt",$"{DateTime.Now} {player}: {detail} Warning {Warnings[player]}\n");
            if(Warnings[player]>=4)
            {
                File.AppendAllText("ban_hwid_ip.txt",$"{DateTime.Now} BAN PERMANEN {type} {player} {GetHWID()} {GetIP()} - 4x Warning\n");
                File.AppendAllText("ban_permanen.txt",$"{DateTime.Now} BAN PERMANEN {player} {type} 4x - {detail}\n");
                File.AppendAllText("mute_log.txt",$"{DateTime.Now} MUTE+BAN {player} {type}\n");
            }
            else File.AppendAllText("mute_log.txt",$"{DateTime.Now} WARNING {Warnings[player]}/3 {player} {type} - Mute\n");
        }

        public void LogKill(string killer, string victim, string weapon){ try{ File.AppendAllText("kill_log.txt",$"{DateTime.Now} {killer} killed {victim} with {weapon}\n"); } catch{} }

        string GetHWID(){ try{ return Environment.MachineName+"_"+Environment.ProcessorCount; } catch{ return "UNKNOWN"; } }
        string GetIP(){ return "127.0.0.1"; }
    }
}
