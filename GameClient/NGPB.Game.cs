// NGPB GAME CLIENT - PERSIS PB ID
// - Map RED Yard 8v8 002 7R 001 02:45 HP 100 AP 100
// - Weapon AUG A3 28/120 Scope Muzzle Grip
// - 6 Panel UI: Gameplay + Map Preview + Weapon Preview + Character + Main Menu + Scoreboard + HUD Overview
// - Anti-Cheat Engine: Scan memory Cheat Engine, DLL Injection
// - Anti-Cheat AI: Detect WH, AimLock, NoRecoil behavior ML
// - Anti-Cheat Enterprise: HWID+IP Ban, GM Name Filter, Toxic Chat 4x Ban, Link https://ngpb.nhg.one only, Flood 5msg/10s Mute 3x Ban 4x
// - Integrated ke ngpb.exe, ga bisa di bypass!
public class GameClient {
  AntiCheatEnterprise ac = new AntiCheatEnterprise();
  void OnPlayerChat(string player, string msg, string hwid, string ip) {
    ac.CheckChatLinkAndFlood(player, msg, isGM, isDev, hwid, ip);
  }
  void OnPlayerJoin(string name, bool isGM) {
    if(!ac.CheckRestrictedName(name, isGM, isDev)) Ban(name);
  }
}
