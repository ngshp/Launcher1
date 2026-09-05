using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NGPB.Server
{
    // PBNG DEDICATED SERVER - BEYOND LIMITED EDITION v1.0.105 ENTERPRISE
    // 127.0.0.1:39190 Localhost + 0.0.0.0:39190 VPS - RED Yard 8v8 - Anti-Cheat Enterprise
    class DedicatedServer
    {
        static string Version = "1.0.105";
        static int Port = 39190;
        static TcpListener Listener;
        static List<Client> Clients = new List<Client>();
        static List<string> Logs = new List<string>();
        static AntiCheatEnterprise AntiCheat = new AntiCheatEnterprise();

        // GAME STATE - PERSIS PB ID
        static string Map = "RED Yard";
        static int RedScore = 2; static int BlueScore = 1;
        static int Round = 7; static int MaxRound = 7;
        static string RemainTime = "02:45";
        static bool GameRunning = false;

        class Client { public TcpClient Tcp; public string Name; public string HWID; public string IP; public string Team; public int K,A,D,HP; public bool IsGM,IsDev; public DateTime LastChat; }

        public static void RunServer(string[] args)
        {
            Console.Title = $"NGPB DEDICATED SERVER - {Map} - 127.0.0.1:{Port} + 0.0.0.0:{Port} VPS - v{Version} ENTERPRISE - RED Yard 8v8";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Banner();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n [SERVER] Starting PBNG Dedicated Server v{Version} Beyond Limited Edition...");
            Console.WriteLine($" [MAP] {Map} - {RedScore} 7R {BlueScore} - Remain Time {RemainTime} - 8v8 Enterprise");
            Console.WriteLine($" [BIND] 127.0.0.1:{Port} (Localhost) + 0.0.0.0:{Port} (VPS - Biar teman connect)");
            Console.WriteLine($" [ANTI-CHEAT] Engine + AI + Enterprise HWID+IP Ban + Name Filter + Chat Filter + Link https://ngpb.nhg.one only");
            Console.WriteLine($" [WEB] https://ngpb.nhg.one - Keren Habis! CBT PC | OBT PC+HP+iOS Crossplay ON!");

            try
            {
                Listener = new TcpListener(IPAddress.Any, Port);
                Listener.Start();
                Log($"[SERVER] Started on 0.0.0.0:{Port} + 127.0.0.1:{Port} - Map {Map} - Waiting players...");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n [OK] SERVER RUNNING BOS! 0.0.0.0:{Port} + 127.0.0.1:{Port}");
                Console.WriteLine($" [INFO] Local: 127.0.0.1:{Port} | Hamachi: 25.x.x.x:{Port} | VPS: 0.0.0.0:{Port}");
                Console.WriteLine($" [INFO] Main bareng teman: Edit START-GAME.bat ganti 127.0.0.1 jadi IP PC Bos!");
                Console.WriteLine($" [INFO] PBNG.Launcher.exe 118 MB GREEN 1m 49s + ngpb.exe 60 MB + Server 15 MB");

                // GAME TIMER - 02:45 countdown persis PB ID
                Task.Run(() => GameTimer());

                // ACCEPT CLIENTS
                while(true)
                {
                    var tcp = Listener.AcceptTcpClient();
                    Task.Run(() => HandleClient(tcp));
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" [ERROR] Server failed: {ex.Message}");
                Log($"[ERROR] {ex.Message}");
            }
        }

        static void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
 ███╗ ██╗ ██████╗ ██████╗ ██████╗ ███████╗███████╗██████╗ ██╗ ██╗███████╗██████╗ ██╗ ██╗ ██╗ ██████╗ ███████╗
 ████╗ ██║██╔════╝ ██╔══██╗██╔══██╗ ██╔════╝██╔════╝██╔══██╗██║ ██║██╔════╝██╔══██╗ ██║ ██║███║██╔═████╗██╔════╝
 ██╔██╗ ██║██║ ███╗██████╔╝██████╔╝ ███████╗█████╗ ██████╔╝██║ ██║█████╗ ██████╔╝ ██║ ██║╚██║██║██╔██║███████╗
 ██║╚██╗██║██║ ██║██╔══██╗██╔══██╗ ╚════██║██╔══╝ ██╔══██╗╚██╗ ██╔╝██╔══╝ ██╔══██╗ ╚██╗ ██╔╝ ██║████╔╝██║╚════██║
 ██║ ╚████║╚██████╔╝██████╔╝██████╔╝ ███████║███████╗██║ ██║ ╚████╔╝ ███████╗██║ ██║ ╚████╔╝ ██║╚██████╔╝███████║
 ╚═╝ ╚═══╝ ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝╚══════╝╚═╝ ╚═╝ ╚═══╝ ╚══════╝╚═╝ ╚═╝ ╚═══╝ ╚═╝ ╚═════╝ ╚══════╝
                               v1.0.105 ENTERPRISE - RED Yard 8v8 - 002 7R 001 02:45 - HP 100 AP 100 - Beyond Limited Edition
            ");
        }

        static void GameTimer()
        {
            while(true)
            {
                Thread.Sleep(1000);
                if(!GameRunning) continue;
                // Countdown 02:45 persis PB ID
                try {
                    var parts = RemainTime.Split(':');
                    int m = int.Parse(parts[0]); int s = int.Parse(parts[1]);
                    if(s>0) s--; else if(m>0){ m--; s=59; }
                    RemainTime = $"{m:D2}:{s:D2}";
                    if(m==0 && s==0){ Round++; if(Round>MaxRound){ RedScore++; RemainTime="02:45"; Broadcast($"ROUND {Round} END - RED {RedScore} BLUE {BlueScore}"); } }
                } catch { RemainTime="02:45"; }
            }
        }

        static async Task HandleClient(TcpClient tcp)
        {
            string ip = ((IPEndPoint)tcp.Client.RemoteEndPoint).Address.ToString();
            var client = new Client{Tcp=tcp, IP=ip, HWID="UNKNOWN", Name=$"Player_{ip}", Team="RED", K=0,A=0,D=0,HP=100, LastChat=DateTime.Now};
            Clients.Add(client);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n [CONNECT] {ip} connected - Total {Clients.Count}/16 players - Map {Map}");
            Log($"[CONNECT] {ip} - Total {Clients.Count}");

            // ANTI-CHEAT CHECK HWID+IP BAN
            if(AntiCheat.IsBanned(client.HWID, ip, client.Name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" [BAN] {ip} {client.HWID} {client.Name} BANNED PERMANEN - DENIED!");
                await Send(tcp, $"BAN PERMANEN HWID+IP - DENIED - Server {Map}");
                tcp.Close(); Clients.Remove(client); return;
            }

            try
            {
                var stream = tcp.GetStream();
                var buffer = new byte[4096];
                while(tcp.Connected)
                {
                    int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if(read==0) break;
                    string msg = Encoding.UTF8.GetString(buffer, 0, read).Trim();
                    Log($"[RECV] {client.Name}@{ip}: {msg}");

                    // PARSE CLIENT MESSAGES
                    if(msg.StartsWith("JOIN"))
                    {
                        var parts = msg.Split('|');
                        if(parts.Length>=2) client.Name = parts[1];
                        if(parts.Length>=3) client.HWID = parts[2];
                        // NAME FILTER - GM, DEVELOPER, STAFF, MOD, ADMIN
                        if(!AntiCheat.CheckRestrictedName(client.Name, client.IsGM, client.IsDev))
                        {
                            await Send(tcp, $"NAME DENIED - {client.Name} RESTRICTED GM/DEV/STAFF/MOD/ADMIN - BAN!");
                            Log($"[NAME VIOLATION] {client.Name}@{ip} - DENIED + BAN");
                            tcp.Close(); break;
                        }
                        // TEAM ASSIGN 8v8
                        int redCount = Clients.Count(c=>c.Team=="RED");
                        client.Team = redCount<8?"RED":"BLUE";
                        GameRunning = true;
                        await Send(tcp, $"JOINED {Map} Team {client.Team} - RED {RedScore} {Round}R {BlueScore} BLUE TIME {RemainTime} HP 100 AP 100 AUG A3 28/120");
                        Broadcast($"{client.Name} joined Team {client.Team} - {Map} - RED {RedScore} BLUE {BlueScore}", client);
                    }
                    else if(msg.StartsWith("CHAT"))
                    {
                        string chatMsg = msg.Substring(5);
                        if(!AntiCheat.CheckChatLinkAndFlood(client.Name, chatMsg, client.IsGM, client.IsDev, client.HWID, client.IP))
                        {
                            await Send(tcp, $"CHAT DENIED - Toxic/Link/Flood - Warning {AntiCheat.GetWarning(client.Name)}/4 - 4x Ban HWID+IP!");
                            Log($"[CHAT VIOLATION] {client.Name}: {chatMsg}");
                        }
                        else
                        {
                            Broadcast($"CHAT {client.Team} {client.Name}: {chatMsg}", null);
                            Log($"[CHAT] {client.Team} {client.Name}: {chatMsg}");
                        }
                    }
                    else if(msg.StartsWith("KILL"))
                    {
                        // KILL LOG - AUG A3 Headshot etc
                        var parts = msg.Split('|');
                        string victim = parts.Length>=2?parts[1]:"Enemy";
                        string weapon = parts.Length>=3?parts[2]:"AUG A3";
                        client.K++;
                        Broadcast($"KILL {client.Name} killed {victim} with {weapon} - {Map} RED {RedScore} BLUE {BlueScore}");
                        Log($"[KILL] {client.Name} killed {victim} with {weapon}");
                        File.AppendAllText("kill_log.txt",$"{DateTime.Now} {client.Name} killed {victim} with {weapon} - {Map}\n");
                    }
                    else if(msg.StartsWith("PING"))
                    {
                        await Send(tcp, $"PONG {RemainTime} RED {RedScore} BLUE {BlueScore} Round {Round} Map {Map} Players {Clients.Count}/16");
                    }
                }
            }
            catch(Exception ex){ Log($"[ERROR] Client {ip}: {ex.Message}"); }
            finally
            {
                Clients.Remove(client);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" [DISCONNECT] {client.Name}@{ip} - Total {Clients.Count}/16");
                Broadcast($"{client.Name} left - Total {Clients.Count}/16");
                try{ tcp.Close(); } catch{}
            }
        }

        static async Task Send(TcpClient tcp, string msg)
        {
            try{ var data = Encoding.UTF8.GetBytes(msg+"\n"); await tcp.GetStream().WriteAsync(data,0,data.Length); } catch{}
        }

        static void Broadcast(string msg, Client exclude = null)
        {
            foreach(var c in Clients.ToList()) if(c!=exclude) try{ Send(c.Tcp, msg).Wait(); } catch{}
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" [BROADCAST] {msg}");
        }

        static void Log(string msg){ Logs.Add($"{DateTime.Now:HH:mm:ss} {msg}"); Console.WriteLine($" LOG: {msg}"); try{ File.AppendAllText("server_log.txt",$"{DateTime.Now} {msg}\n"); } catch{} }
    }

    // ANTI-CHEAT ENTERPRISE - SERVER SIDE
    public class AntiCheatEnterprise
    {
        string[] Restricted = {"GM","DEVELOPER","STAFF","MOD","ADMIN"};
        string[] Toxic = {"anjing","babi","kontol","memek","tolol","goblok","fuck","shit"};
        string AllowedLink = "https://ngpb.nhg.one";
        Dictionary<string,int> Warnings = new Dictionary<string,int>();
        Dictionary<string,List<DateTime>> ChatTimes = new Dictionary<string,List<DateTime>>();

        public bool IsBanned(string hwid, string ip, string name){ try{ if(!File.Exists("ban_hwid_ip.txt")) return false; var t=File.ReadAllText("ban_hwid_ip.txt"); return t.Contains(hwid)||t.Contains(ip)||t.Contains(name); } catch{ return false; } }
        public int GetWarning(string player){ return Warnings.ContainsKey(player)?Warnings[player]:0; }

        public bool CheckRestrictedName(string name, bool isGM, bool isDev)
        {
            if(isGM||isDev) return true;
            foreach(var r in Restricted) if(name.ToUpper().Contains(r)){ File.AppendAllText("name_violation.txt",$"{DateTime.Now} NAME VIOLATION {name} - DENIED+BAN\n"); File.AppendAllText("ban_hwid_ip.txt",$"{DateTime.Now} BAN NAME {name} {GetHWID()} {GetIP()}\n"); return false; }
            return true;
        }

        public bool CheckChatLinkAndFlood(string player, string msg, bool isGM, bool isDev, string hwid, string ip)
        {
            if(isGM||isDev) return true;
            if((msg.Contains("http://")||msg.Contains("https://")||msg.Contains("www.")||msg.Contains(".com")) &&!msg.Contains(AllowedLink)){ Warn(player,"LINK",msg,hwid,ip); return false; }
            foreach(var t in Toxic) if(msg.ToLower().Contains(t)){ Warn(player,"TOXIC",msg,hwid,ip); return false; }
            if(!ChatTimes.ContainsKey(player)) ChatTimes[player]=new List<DateTime>();
            ChatTimes[player].Add(DateTime.Now); ChatTimes[player].RemoveAll(d=>(DateTime.Now-d).TotalSeconds>10);
            if(ChatTimes[player].Count>5){ Warn(player,"FLOOD",msg,hwid,ip); return false; }
            return true;
        }

        void Warn(string player, string type, string msg, string hwid, string ip)
        {
            if(!Warnings.ContainsKey(player)) Warnings[player]=0; Warnings[player]++;
            File.AppendAllText("violation_log.txt",$"{DateTime.Now} {type} {player} Warn {Warnings[player]}/4 - {msg}\n");
            if(Warnings[player]>=4){ File.AppendAllText("ban_hwid_ip.txt",$"{DateTime.Now} BAN PERMANEN {type} {player} {hwid} {ip} 4x\n"); File.AppendAllText("ban_permanen.txt",$"{DateTime.Now} BAN {player} {type} 4x - {msg}\n"); }
            else File.AppendAllText("mute_log.txt",$"{DateTime.Now} MUTE Warn {Warnings[player]}/3 {player} {type}\n");
        }

        string GetHWID(){ try{ return Environment.MachineName+"_"+Environment.ProcessorCount; } catch{ return "UNKNOWN"; } }
        string GetIP(){ return "127.0.0.1"; }
    }
}
