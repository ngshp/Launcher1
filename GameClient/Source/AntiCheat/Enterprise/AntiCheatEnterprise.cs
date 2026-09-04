using System; using System.Collections.Generic; using System.IO; using System.Linq; using System.Text.RegularExpressions;
namespace NGPB.AntiCheat.Enterprise {
public class AntiCheatEnterprise {
public static string Version = "1.0.105-ENTERPRISE";
private static readonly string[] RestrictedNames = new string[] { "GM", "DEVELOPER", "DEV", "STAFF", "STAF", "MOD", "MODERATOR", "ADMIN", "ADM", "OWNER" };
private static readonly string AllowedLink = "https://ngpb.nhg.one";
private static readonly Regex LinkRegex = new Regex(@"https?://[^\s]+", RegexOptions.Compiled);
private Dictionary<string, int> playerWarnings = new Dictionary<string, int>();
private HashSet<string> bannedHWID = new HashSet<string>();
private HashSet<string> bannedIP = new HashSet<string>();
private HashSet<string> bannedAccounts = new HashSet<string>();
public AntiCheatEnterprise() {
Console.WriteLine($"[ANTI-CHEAT ENTERPRISE v{Version}] HWID Ban, IP Ban, Name Filter, Chat Filter, Link Whitelist ON");
Console.WriteLine($"[ENTERPRISE] Allowed Link: {AllowedLink}");
}
public bool CheckLoadingLayer1(bool passed, bool bypassed) {
if(bypassed ||!passed) {
Console.WriteLine("[ENTERPRISE] LAYER 1 BYPASS = AUTO CLOSE CLIENT!");
File.AppendAllText("security_log.txt", $"{DateTime.Now} LAYER 1 BYPASS - AUTO CLOSE\n");
Environment.Exit(0); return false;
} return true;
}
public bool CheckLoadingLayer2(bool passed, string hwid, string ip) {
if(!passed) {
Console.WriteLine($"[ENTERPRISE] LAYER 2 BYPASS = BAN HWID:{hwid} IP:{ip} PERMANEN!");
BanHWIDIP(hwid, ip, "BYPASS LAYER 2"); Environment.Exit(0); return false;
} return true;
}
void BanHWIDIP(string hwid, string ip, string reason) {
bannedHWID.Add(hwid); bannedIP.Add(ip);
File.AppendAllText("ban_hwid_ip.txt", $"{DateTime.Now} BAN PERMANEN HWID:{hwid} IP:{ip} REASON:{reason}\n");
File.AppendAllText("ban_permanen.txt", $"{hwid} {ip} {reason}\n");
}
public bool CheckCheat(string player, string cheatType, string hwid, string ip) {
if(!playerWarnings.ContainsKey(player)) playerWarnings[player]=0;
playerWarnings[player]++;
Console.WriteLine($"[ENTERPRISE] CHEAT: {player} - {cheatType} - Warning {playerWarnings[player]}/4");
File.AppendAllText("cheat_log.txt", $"{DateTime.Now} {player} {cheatType} Warning {playerWarnings[player]}/4 HWID:{hwid} IP:{ip}\n");
if(playerWarnings[player] >= 4) {
BanHWIDIP(hwid, ip, $"CHEAT {cheatType} 4x"); bannedAccounts.Add(player);
File.AppendAllText("ban_permanen.txt", $"{DateTime.Now} BAN PERMANEN {player} {cheatType}\n");
return false;
} return true;
}
public bool CheckRestrictedName(string playerName, bool isGM, bool isDev) {
string upper = playerName.ToUpper();
foreach(var r in RestrictedNames) {
if(upper.Contains(r)) {
if(!isGM &&!isDev) {
Console.WriteLine($"[ENTERPRISE] RESTRICTED NAME: {playerName} contains {r} - Only GM/Dev! AUTO BAN!");
File.AppendAllText("name_violation.txt", $"{DateTime.Now} RESTRICTED NAME {playerName} {r} - DENIED\n");
return false;
}
}
} return true;
}
private Dictionary<string, List<DateTime>> chatFlood = new Dictionary<string, List<DateTime>>();
public bool CheckChatLinkAndFlood(string player, string message, bool isGM, bool isDev, string hwid, string ip) {
if(!chatFlood.ContainsKey(player)) chatFlood[player]=new List<DateTime>();
chatFlood[player].Add(DateTime.Now);
chatFlood[player] = chatFlood[player].Where(t => (DateTime.Now - t).TotalSeconds < 10).ToList();
if(chatFlood[player].Count > 5) {
return HandleViolation(player, "FLOOD CHAT", hwid, ip, true);
}
var links = LinkRegex.Matches(message);
foreach(Match link in links) {
string url = link.Value;
if(!url.StartsWith(AllowedLink)) {
if(!isGM &&!isDev) {
Console.WriteLine($"[ENTERPRISE] ILLEGAL LINK: {player} - {url} - Only {AllowedLink} allowed!");
return HandleViolation(player, $"ILLEGAL LINK: {url}", hwid, ip, true);
}
}
}
return true;
}
bool HandleViolation(string player, string reason, string hwid, string ip, bool isChat=false) {
if(!playerWarnings.ContainsKey(player)) playerWarnings[player]=0;
playerWarnings[player]++;
File.AppendAllText("violation_log.txt", $"{DateTime.Now} {player} {reason} Warning {playerWarnings[player]}/4\n");
if(playerWarnings[player] >= 4) {
BanHWIDIP(hwid, ip, $"{reason} 4x"); bannedAccounts.Add(player);
File.AppendAllText("ban_permanen.txt", $"{DateTime.Now} BAN PERMANEN {player} {reason}\n");
return false;
} else if(playerWarnings[player] == 3 && isChat) {
File.AppendAllText("mute_log.txt", $"{DateTime.Now} MUTE {player} {reason} 3x\n");
Console.WriteLine($"[ENTERPRISE] WARNING 3x MUTE: {player} - {reason}");
} return true;
}
public void CheckBypassSecurity(bool isBypassed, string hwid, string ip) {
if(isBypassed) {
File.AppendAllText("bypass_log.txt", $"{DateTime.Now} BYPASS SECURITY HWID:{hwid} IP:{ip} - BAN PERMANEN\n");
BanHWIDIP(hwid, ip, "BYPASS SECURITY"); Environment.Exit(0);
}
}
public bool IsBanned(string hwid, string ip, string account) {
return bannedHWID.Contains(hwid) || bannedIP.Contains(ip) || bannedAccounts.Contains(account);
}
}
}
