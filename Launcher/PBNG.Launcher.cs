// PBNG LAUNCHER - INTEGRATED ANTI-CHEAT ENTERPRISE 4 LAYER - BEYOND LIMITED EDITION v1.0.105
using System;
using System.Diagnostics;
using System.IO;
using System.Windows; // WPF - Jangan hapus Bos! Untuk MessageBox keren!

public class PBNGLauncher
{
  AntiCheatEnterprise.AntiCheatEnterprise anti = new AntiCheatEnterprise.AntiCheatEnterprise();

  void Start()
  {
    Console.WriteLine("=== NGPB BEYOND LIMITED EDITION v1.0.105 ENTERPRISE ===");
    Console.WriteLine("RED Yard 8v8 - AUG A3 28/120 - HP 100 AP 100 - 002 7R 001 02:45");

    // Layer 1 Loading Screen - Bypass = Auto Close Client! Cyberpunk Blue
    var layer1 = new AntiCheatEnterprise.LoadingScreenLayer1();
    layer1.IsPassed = true; // Loading selesai
    Console.WriteLine($"[LAYER 1] {layer1.Theme} - Checking...");
    if(!anti.CheckLoadingLayer1(layer1.IsPassed, layer1.IsBypassed))
    {
        Console.WriteLine("[LAYER 1] BYPASS! Auto Close Client!");
        Environment.Exit(0);
    }
    Console.WriteLine("[LAYER 1] GREEN - PASSED!");

    // Layer 2 Loading Screen - Bypass = Ban HWID+IP Permanen! Cyberpunk Pink
    var layer2 = new AntiCheatEnterprise.LoadingScreenLayer2();
    layer2.IsPassed = true;
    string hwid = GetHWID();
    string ip = GetIP();
    string account = "NGPB_Player";
    layer2.HWID = hwid; layer2.IP = ip;

    Console.WriteLine($"[LAYER 2] {layer2.Theme} - HWID: {hwid} IP: {ip}");

    // Check Ban HWID+IP Permanen dulu Bos!
    if(anti.IsBanned(hwid, ip, account))
    {
        Console.WriteLine($"[BAN] HWID {hwid} IP {ip} BANNED PERMANEN!");
        MessageBox.Show($"BAN PERMANEN HWID+IP!\nHWID: {hwid}\nIP: {ip}\nReason: Banned by Enterprise AntiCheat\nWeb: https://ngpb.nhg.one", "NGPB ENTERPRISE - BANNED", MessageBoxButton.OK, MessageBoxImage.Stop);
        Environment.Exit(0);
    }

    if(!anti.CheckLoadingLayer2(layer2.IsPassed, hwid, ip))
    {
        Console.WriteLine("[LAYER 2] FAILED! Auto Close!");
        Environment.Exit(0);
    }
    Console.WriteLine("[LAYER 2] GREEN - PASSED! HWID+IP Clean!");

    // Check Name Filter GM/DEV = BAN HWID+IP!
    if(!anti.CheckNameFilter(account, hwid, ip))
    {
        MessageBox.Show($"Name {account} blocked! GM/DEV/STAFF/MOD/ADMIN not allowed! BAN HWID+IP!", "Name Filter", MessageBoxButton.OK, MessageBoxImage.Warning);
        Environment.Exit(0);
    }

    // Launch ngpb.exe with Enterprise Protection - RED Yard 8v8!
    Console.WriteLine($"[GAME] Launching Game/ngpb.exe --server 127.0.0.1:39190 --user {account} --anticheat enterprise - RED Yard 8v8!");
    try
    {
        if(File.Exists("Game/ngpb.exe"))
        {
            Process.Start("Game/ngpb.exe",$"--server 127.0.0.1:39190 --user {account} --anticheat enterprise --hwid {hwid}");
        }
        else if(File.Exists("GameClient/bin/Release/net8.0-windows/win-x64/publish/ngpb.exe"))
        {
            Process.Start("GameClient/bin/Release/net8.0-windows/win-x64/publish/ngpb.exe",$"--server 127.0.0.1:39190 --user {account} --anticheat enterprise");
        }
        else
        {
            Console.WriteLine("[INFO] ngpb.exe not found - Run BUILD-LOCALHOST.bat first Bos!");
            Console.WriteLine("[INFO] Or download PBNG-ENTERPRISE-ALL-IN-ONE.zip 200 MB from Releases v1.0.105!");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"[ERROR] Launch failed: {ex.Message}");
    }

    Console.WriteLine("[DONE] Launcher Finished Bos! RED Yard Ready! 002 7R 001 02:45 HP 100 AP 100!");
  }

  string GetHWID() => Environment.MachineName + "_" + Environment.ProcessorCount + "_" + Environment.UserName;
  string GetIP() => "127.0.0.1"; // Get real IP in production - For VPS use 0.0.0.0:39190

  [STAThread]
  public static void Main(string[] args)
  {
    new PBNGLauncher().Start();
  }
}
