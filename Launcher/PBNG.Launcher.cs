// PBNG LAUNCHER - INTEGRATED ANTI-CHEAT ENTERPRISE 4 LAYER
public class PBNGLauncher {
  AntiCheatEnterprise anti = new AntiCheatEnterprise();
  void Start() {
    // Layer 1 Loading Screen - Bypass = Auto Close Client!
    var layer1 = new LoadingScreenLayer1(); // Cyberpunk Blue
    if(!anti.CheckLoadingLayer1(layer1.IsPassed, layer1.IsBypassed)) Environment.Exit(0);
    
    // Layer 2 Loading Screen - Bypass = Ban HWID+IP Permanen!
    var layer2 = new LoadingScreenLayer2(); // Cyberpunk Pink
    string hwid = GetHWID(); string ip = GetIP();
    if(anti.IsBanned(hwid, ip, account)) { MessageBox.Show("BAN PERMANEN HWID+IP!"); Environment.Exit(0); }
    if(!anti.CheckLoadingLayer2(layer2.IsPassed, hwid, ip)) Environment.Exit(0);
    
    // Launch ngpb.exe with protection
    Process.Start("Game/ngpb.exe","--server 127.0.0.1:39190 --anticheat enterprise");
  }
  string GetHWID() => Environment.MachineName + Environment.ProcessorCount;
  string GetIP() => "127.0.0.1"; // Get real IP in production
}
