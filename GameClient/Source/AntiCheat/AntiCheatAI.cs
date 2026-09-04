using System; using System.Diagnostics; using System.Collections.Generic; using System.Threading; using System.Linq; using System.IO;
namespace NGPB.AntiCheat {
public class AntiCheatAI {
public static string Version = "1.0.105-AI";
private bool isRunning = true;
private List<string> blacklisted = new List<string> { "cheatengine", "artmoney", "speedhack", "wpe pro", "process hacker" };
public class AIModel {
public double MaxSpeed = 8.0;
public bool IsSpeedHack(float speed) => speed > MaxSpeed * 1.5;
public bool IsAimbot(float dYaw, float dPitch, double dt) {
double aimSpeed = Math.Sqrt(dYaw*dYaw + dPitch*dPitch) / Math.Max(dt,0.001);
return aimSpeed > 500 && dYaw < 2.0;
}
public bool IsWallhack(bool canSee, int hits) => hits > 3 && canSee;
}
private AIModel ai = new AIModel();
public void Start() {
Console.WriteLine($"[ANTI-CHEAT AI v{Version}] Protecting ngpb.exe");
new Thread(() => { while(isRunning) { Scan(); Thread.Sleep(2000); } }).Start();
new Thread(() => { while(isRunning) { CheckMem(); Thread.Sleep(3000); } }).Start();
}
void Scan() {
try { foreach(var p in Process.GetProcesses()) { string n = p.ProcessName.ToLower(); if(blacklisted.Any(b => n.Contains(b))) { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine($"[DETECTED] BLACKLIST {p.ProcessName} PID {p.Id} - BAN!"); Console.ResetColor(); File.AppendAllText("banlist.txt", $"{DateTime.Now} BLACKLIST {p.ProcessName}\n"); } } } catch {}
}
long lastMem=0;
void CheckMem() {
try { var ngpb = Process.GetProcessesByName("ngpb").FirstOrDefault(); if(ngpb!=null) { long cur = ngpb.WorkingSet64; if(lastMem!=0 && Math.Abs(cur-lastMem)>100_000_000) { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine($"[DETECTED] MEMORY TAMPER {lastMem}->{cur}"); Console.ResetColor(); } lastMem=cur; } } catch {}
}
public bool ValidateMove(float speed) => !ai.IsSpeedHack(speed);
public bool ValidateAim(float dYaw,float dPitch,double dt) => !ai.IsAimbot(dYaw,dPitch,dt);
public bool ValidateShot(bool throughWall, ref int wallHits) { if(throughWall) wallHits++; else wallHits=Math.Max(0,wallHits-1); return !ai.IsWallhack(throughWall, wallHits); }
public void Stop()=>isRunning=false;
}
}
