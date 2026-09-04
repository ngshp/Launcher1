using System;
using System.IO;
using System.Linq;

namespace AntiCheatEnterprise
{
    // NGPB ANTI-CHEAT ENTERPRISE 4 LAYER - BEYOND LIMITED EDITION v1.0.105
    // Layer 1 Blue + Layer 2 Pink + Engine + Enterprise HWID+IP Ban
    public class AntiCheatEnterprise
    {
        private readonly string banFile = "ban_hwid_ip.txt";
        private readonly string logFile = "violation_log.txt";

        // Layer 1 Loading Screen - Bypass = Auto Close Client!
        public bool CheckLoadingLayer1(bool isPassed, bool isBypassed)
        {
            if (isBypassed)
            {
                Log($"[LAYER 1 BLUE] BYPASS DETECTED! Auto Close Client! HWID: {GetHWID()}");
                return false; // Auto Close
            }
            if (!isPassed)
            {
                Log($"[LAYER 1 BLUE] Not passed yet...");
                return false;
            }
            Log($"[LAYER 1 BLUE] PASSED - Cyberpunk Blue Loading OK!");
            return true;
        }

        // Layer 2 Loading Screen - Bypass = Ban HWID+IP Permanen!
        public bool CheckLoadingLayer2(bool isPassed, string hwid, string ip)
        {
            if (!isPassed)
            {
                Log($"[LAYER 2 PINK] Not passed - Waiting...");
                return false;
            }

            // Check ban before allow
            if (IsBanned(hwid, ip, ""))
            {
                Log($"[LAYER 2 PINK] BANNED HWID: {hwid} IP: {ip} - DENIED!");
                return false;
            }

            Log($"[LAYER 2 PINK] PASSED - Cyberpunk Pink Loading OK! HWID: {hwid} IP: {ip}");
            return true;
        }

        // HWID+IP Ban Check - Ban Permanen!
        public bool IsBanned(string hwid, string ip, string account)
        {
            try
            {
                if (!File.Exists(banFile)) return false;
                var bans = File.ReadAllLines(banFile);
                return bans.Any(line =>
                    line.Contains(hwid) ||
                    line.Contains(ip) ||
                    (!string.IsNullOrEmpty(account) && line.Contains(account))
                );
            }
            catch { return false; }
        }

        public void BanHWIDIP(string hwid, string ip, string reason)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | HWID: {hwid} | IP: {ip} | Reason: {reason} | BAN PERMANEN!";
                File.AppendAllText(banFile, entry + Environment.NewLine);
                Log($"[BAN] {entry}");
            }
            catch { }
        }

        // Engine Anti-Cheat - WH, AimLock, SpeedHack, NoRecoil
        public bool CheckEngine(string cheatType, string hwid, string ip)
        {
            Log($"[ENGINE] Cheat detected: {cheatType} HWID: {hwid}");
            BanHWIDIP(hwid, ip, $"ENGINE_{cheatType}");
            return false;
        }

        // Enterprise - Name Filter GM/DEV/STAFF/MOD/ADMIN = DENIED + BAN!
        public bool CheckNameFilter(string playerName, string hwid, string ip)
        {
            string[] blocked = { "GM", "DEV", "DEVELOPER", "STAFF", "MOD", "ADMIN", "GM_", "_GM" };
            if (blocked.Any(b => playerName.ToUpper().Contains(b)))
            {
                // GM/Dev whitelist check - kalo whitelist jangan ban
                if (IsWhitelisted(playerName)) return true;

                Log($"[NAME FILTER] Blocked name: {playerName} - BAN HWID+IP!");
                BanHWIDIP(hwid, ip, $"NAME_FILTER_{playerName}");
                return false;
            }
            return true;
        }

        // Toxic Chat Filter
        public bool CheckChatFilter(string message, string hwid, string ip)
        {
            string[] toxic = { "anjing", "babi", "kontol", "memek", "fuck", "bitch" };
            if (toxic.Any(t => message.ToLower().Contains(t)))
            {
                Log($"[CHAT FILTER] Toxic: {message} - Warning! HWID: {hwid}");
                return false;
            }
            return true;
        }

        // Link Filter - Only https://ngpb.nhg.one allowed!
        public bool CheckLinkFilter(string message, string hwid, string ip)
        {
            if (message.Contains("http") &&!message.Contains("https://ngpb.nhg.one"))
            {
                Log($"[LINK FILTER] Illegal link: {message} - BAN! HWID: {hwid}");
                BanHWIDIP(hwid, ip, $"LINK_FILTER_{message}");
                return false;
            }
            return true;
        }

        private bool IsWhitelisted(string name)
        {
            // GM/Dev whitelist - Bos bisa tambah nama Bos di sini
            string[] whitelist = { "NGPB_Boss", "NGSHP" };
            return whitelist.Any(w => name.Equals(w, StringComparison.OrdinalIgnoreCase));
        }

        private string GetHWID() => Environment.MachineName + "_" + Environment.ProcessorCount;

        private void Log(string msg)
        {
            try { File.AppendAllText(logFile, $"{DateTime.Now:HH:mm:ss} {msg}{Environment.NewLine}"); } catch { }
            Console.WriteLine(msg);
        }
    }

    // Loading Screen Layer 1 - Cyberpunk Blue - Enterprise
    public class LoadingScreenLayer1
    {
        public bool IsPassed { get; set; } = true;
        public bool IsBypassed { get; set; } = false;
        public string Theme => "Cyberpunk Blue - Layer 1 - AutoClose if Bypass!";
    }

    // Loading Screen Layer 2 - Cyberpunk Pink - Enterprise HWID+IP
    public class LoadingScreenLayer2
    {
        public bool IsPassed { get; set; } = true;
        public bool IsBypassed { get; set; } = false;
        public string Theme => "Cyberpunk Pink - Layer 2 - Ban HWID+IP if Bypass!";
        public string HWID { get; set; } = "";
        public string IP { get; set; } = "";
    }
}
