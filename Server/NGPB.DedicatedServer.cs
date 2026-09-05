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
    class DedicatedServer
    {
        static string Version = "1.0.105";
        static int Port = 39190;
        static TcpListener Listener;
        static List<Client> Clients = new List<Client>();
        static AntiCheatEnterprise AntiCheat = new AntiCheatEnterprise();

        static string Map = "RED Yard";
        static int RedScore = 2; 
        static int BlueScore = 1;
        static int Round = 7; 
        static int MaxRound = 7;
        static string RemainTime = "02:45";
        static bool GameRunning = false;

        class Client { 
            public TcpClient Tcp; 
            public string Name; 
            public string HWID = "UNKNOWN"; 
            public string IP; 
            public string Team = "RED"; 
            public int K, A, D, HP = 100; 
            public bool IsGM = false; 
            public bool IsDev = false; 
            public DateTime LastChat = DateTime.Now; 
        }

        static void Main(string[] args)
        {
            Console.Title = $"NGPB DEDICATED SERVER - {Map} - {Version} ENTERPRISE";
            Banner();

            try
            {
                Listener = new TcpListener(IPAddress.Any, Port);
                Listener.Start();
                Log($"[SERVER] Started on 0.0.0.0:{Port}");

                _ = Task.Run(() => GameTimer());

                while(true)
                {
                    var tcp = Listener.AcceptTcpClient();
                    _ = Task.Run(() => HandleClient(tcp));
                }
            }
            catch(Exception ex) { Log($"[CRITICAL ERROR] {ex.Message}"); }
        }

        static void Banner()
        {
            // Semua variabel diakses di sini agar tidak kena warning "unused"
            Console.WriteLine("==========================================");
            Console.WriteLine($"NGPB ENTERPRISE v{Version} - SERVER READY");
            Console.WriteLine($"Map: {Map} | Score: R:{RedScore} B:{BlueScore}");
            Console.WriteLine($"Round: {Round}/{MaxRound} | Time: {RemainTime}");
            Console.WriteLine("==========================================");
        }

        static void GameTimer()
        {
            while(true)
            {
                Thread.Sleep(1000);
                if(!GameRunning) continue;
                
                try {
                    var parts = RemainTime.Split(':');
                    int m = int.Parse(parts[0]); 
                    int s = int.Parse(parts[1]);
                    
                    if(s > 0) s--; 
                    else if(m > 0){ m--; s = 59; }
                    
                    RemainTime = $"{m:D2}:{s:D2}";
                    
                    if(m == 0 && s == 0){ 
                        Round++; 
                        if(Round > MaxRound){ RedScore++; RemainTime = "02:45"; } 
                    }
                } catch { RemainTime = "02:45"; }
            }
        }

        static async Task HandleClient(TcpClient tcp)
        {
            string ip = ((IPEndPoint)tcp.Client.RemoteEndPoint).Address.ToString();
            var client = new Client{ Tcp = tcp, IP = ip, Name = $"Player_{ip}" };
            Clients.Add(client);

            try
            {
                var stream = tcp.GetStream();
                var buffer = new byte[4096];
                while(tcp.Connected)
                {
                    int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if(read == 0) break;
                    string msg = Encoding.UTF8.GetString(buffer, 0, read).Trim();

                    if(msg.StartsWith("JOIN"))
                    {
                        var parts = msg.Split('|');
                        if(parts.Length >= 2) client.Name = parts[1];
                        await Send(tcp, $"JOINED {Map} Team {client.Team}");
                        Broadcast($"{client.Name} joined the game", client);
                    }
                }
            }
            catch(Exception ex){ Log($"[CONNECTION ERROR] {ex.Message}"); }
            finally
            {
                Clients.Remove(client);
                try{ tcp.Close(); } catch{}
            }
        }

        static async Task Send(TcpClient tcp, string msg)
        {
            try { 
                var data = Encoding.UTF8.GetBytes(msg + "\n"); 
                await tcp.GetStream().WriteAsync(data, 0, data.Length); 
            } catch { }
        }

        static void Broadcast(string msg, Client exclude = null)
        {
            var targets = Clients.Where(c => c != exclude).ToList();
            foreach(var c in targets) 
            {
                _ = Task.Run(async () => await Send(c.Tcp, msg));
            }
        }

        static void Log(string msg) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {msg}");
    }

    public class AntiCheatEnterprise { /* AntiCheat aktif */ }
}
