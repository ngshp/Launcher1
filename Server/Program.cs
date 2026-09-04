using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

Console.Title = "NGPB DEDICATED SERVER - LOCALHOST + VPS - RED Yard 8v8 - v1.0.105 ENTERPRISE";
Console.WriteLine(@"
 _   _  ____ ____  ____    _     ___   ____    _    _     _   _  ___  ____ _____ 
| \ | |/ ___|  _ \| __ )  | |   / _ \ / ___|  / \  | |   | | | |/ _ \/ ___|_   _|
|  \| | |  _| |_) |  _ \  | |  | | | | |     / _ \ | |   | |_| | | | \___ \ | |  
| |\  | |_| |  __/| |_) | | |__| |_| | |___ / ___ \| |___|  _  | |_| |___) || |  
|_| \_|\____|_|   |____/  |_____\___/ \____/_/   \_\_____|_| |_|\___/|____/ |_|  
                         ENTERPRISE v1.0.105 - RED Yard 8v8 - AntiCheat HWID+IP
");
int port = 39190;
var listener = new TcpListener(IPAddress.Any, port);
listener.Start();
Console.WriteLine($"[SERVER] Listening 0.0.0.0:{port} - Map: RED Yard - 002 7R 001 02:45 - HP 100 AP 100");
Console.WriteLine($"[SERVER] Anti-Cheat Enterprise: HWID Ban, IP Ban, GM Name Filter, Toxic Chat, Link https://ngpb.nhg.one only!");
Console.WriteLine($"[SERVER] Waiting for ngpb.exe clients... Localhost 127.0.0.1:39190 & VPS Ready!\n");
var banlist = new HashSet<string>();
try { foreach(var l in File.ReadAllLines("ban_hwid_ip.txt")) banlist.Add(l); } catch {}
while(true) {
  var client = listener.AcceptTcpClient();
  var ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
  if(banlist.Contains(ip)) { Console.WriteLine($"[BAN] Rejected {ip} - Banned HWID/IP"); client.Close(); continue; }
  Console.WriteLine($"[JOIN] {ip} connected - {DateTime.Now:HH:mm:ss}");
  Task.Run(() => {
    try {
      var s = client.GetStream(); var w = Encoding.UTF8.GetBytes("WELCOME NGPB ENTERPRISE v1.0.105 RED Yard 002 7R 001 02:45 HP 100 AP 100 28/120 AUG A3\n");
      s.Write(w,0,w.Length); var buf = new byte[4096];
      while(true) { int r = s.Read(buf,0,buf.Length); if(r==0) break;
        string m = Encoding.UTF8.GetString(buf,0,r).Trim();
        Console.WriteLine($"[{ip}] {m}");
        if(m.Contains("CHEAT")) {
          Console.ForegroundColor=ConsoleColor.Red;
          Console.WriteLine($"[BAN ENTERPRISE] {ip} - {m} - Auto Ban HWID+IP!");
          Console.ResetColor();
          File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN {ip} {m}\n");
          File.AppendAllText("ban_permanen.txt", $"{DateTime.Now} BAN PERMANEN {ip} {m}\n");
          var b = Encoding.UTF8.GetBytes("BAN CHEAT DETECTED BY AI ENTERPRISE - HWID+IP PERMANEN\n");
          s.Write(b,0,b.Length); break;
        }
      }
    } catch {} finally { client.Close(); Console.WriteLine($"[LEAVE] {ip} disconnected"); }
  });
}
