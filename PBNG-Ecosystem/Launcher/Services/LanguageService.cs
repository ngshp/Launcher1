using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PBNG.Launcher.Services
{
    public class LanguageService
    {
        public static LanguageService Instance { get; } = new();
        
        public string CurrentLang { get; private set; } = "ID"; // Default Indonesian
        
        private Dictionary<string, Dictionary<string, string>> translations = new()
        {
            ["ID"] = new() {
                ["app_title"] = "PBNG LAUNCHER",
                ["app_subtitle"] = "Point Blank NG - Private Server",
                ["launch"] = "🚀 LUNCURKAN GAME",
                ["update_available"] = "Update tersedia!",
                ["update_now"] = "Update sekarang?",
                ["downloading"] = "Mengunduh...",
                ["ready"] = "Siap Main Point Blank",
                ["in_launcher"] = "Di PBNG Launcher",
                ["idle"] = "Idle • Siap Main",
                ["ingame"] = "Sedang Main • In-Game",
                ["settings"] = "Pengaturan",
                ["language"] = "Bahasa / Language",
                ["version"] = "Versi",
                ["verified"] = "Terverifikasi • Build #105",
                ["discord_on"] = "Discord Rich Presence ON",
                ["updater_on"] = "Auto-Updater ON",
                ["success"] = "SUCCESS • Terverifikasi",
                ["welcome"] = "Selamat Datang",
                ["select_lang"] = "Pilih Bahasa"
            },
            ["EN"] = new() {
                ["app_title"] = "PBNG LAUNCHER",
                ["app_subtitle"] = "Point Blank NG - Private Server",
                ["launch"] = "🚀 LAUNCH GAME",
                ["update_available"] = "Update available!",
                ["update_now"] = "Update now?",
                ["downloading"] = "Downloading...",
                ["ready"] = "Ready to Play Point Blank",
                ["in_launcher"] = "In PBNG Launcher",
                ["idle"] = "Idle • Ready to Play",
                ["ingame"] = "Playing • In-Game",
                ["settings"] = "Settings",
                ["language"] = "Language",
                ["version"] = "Version",
                ["verified"] = "Verified • Build #105",
                ["discord_on"] = "Discord Rich Presence ON",
                ["updater_on"] = "Auto-Updater ON",
                ["success"] = "SUCCESS • Verified",
                ["welcome"] = "Welcome",
                ["select_lang"] = "Select Language"
            },
            ["FR"] = new() {
                ["app_title"] = "PBNG LAUNCHER",
                ["app_subtitle"] = "Point Blank NG - Serveur Privé",
                ["launch"] = "🚀 LANCER LE JEU",
                ["update_available"] = "Mise à jour disponible!",
                ["update_now"] = "Mettre à jour maintenant?",
                ["downloading"] = "Téléchargement...",
                ["ready"] = "Prêt à jouer à Point Blank",
                ["in_launcher"] = "Dans PBNG Launcher",
                ["idle"] = "Inactif • Prêt à jouer",
                ["ingame"] = "En jeu • In-Game",
                ["settings"] = "Paramètres",
                ["language"] = "Langue",
                ["version"] = "Version",
                ["verified"] = "Vérifié • Build #105",
                ["discord_on"] = "Discord Rich Presence ON",
                ["updater_on"] = "Auto-Updater ON",
                ["success"] = "SUCCÈS • Vérifié",
                ["welcome"] = "Bienvenue",
                ["select_lang"] = "Choisir la langue"
            },
            ["RU"] = new() {
                ["app_title"] = "PBNG LAUNCHER",
                ["app_subtitle"] = "Point Blank NG - Приватный Сервер",
                ["launch"] = "🚀 ЗАПУСТИТЬ ИГРУ",
                ["update_available"] = "Доступно обновление!",
                ["update_now"] = "Обновить сейчас?",
                ["downloading"] = "Загрузка...",
                ["ready"] = "Готов играть в Point Blank",
                ["in_launcher"] = "В PBNG Launcher",
                ["idle"] = "Ожидание • Готов к игре",
                ["ingame"] = "В игре • In-Game",
                ["settings"] = "Настройки",
                ["language"] = "Язык",
                ["version"] = "Версия",
                ["verified"] = "Проверено • Сборка #105",
                ["discord_on"] = "Discord Rich Presence ВКЛ",
                ["updater_on"] = "Авто-обновление ВКЛ",
                ["success"] = "УСПЕХ • Проверено",
                ["welcome"] = "Добро пожаловать",
                ["select_lang"] = "Выберите язык"
            },
            ["CN"] = new() {
                ["app_title"] = "PBNG 启动器",
                ["app_subtitle"] = "Point Blank NG - 私服",
                ["launch"] = "🚀 启动游戏",
                ["update_available"] = "有可用更新！",
                ["update_now"] = "现在更新？",
                ["downloading"] = "下载中...",
                ["ready"] = "准备玩 Point Blank",
                ["in_launcher"] = "在 PBNG 启动器中",
                ["idle"] = "空闲 • 准备就绪",
                ["ingame"] = "游戏中 • In-Game",
                ["settings"] = "设置",
                ["language"] = "语言",
                ["version"] = "版本",
                ["verified"] = "已验证 • 构建 #105",
                ["discord_on"] = "Discord 状态开启",
                ["updater_on"] = "自动更新开启",
                ["success"] = "成功 • 已验证",
                ["welcome"] = "欢迎",
                ["select_lang"] = "选择语言"
            },
            ["AR"] = new() {
                ["app_title"] = "PBNG لانشر",
                ["app_subtitle"] = "Point Blank NG - خادم خاص",
                ["launch"] = "🚀 تشغيل اللعبة",
                ["update_available"] = "التحديث متاح!",
                ["update_now"] = "تحديث الآن؟",
                ["downloading"] = "جار التحميل...",
                ["ready"] = "جاهز للعب Point Blank",
                ["in_launcher"] = "في PBNG Launcher",
                ["idle"] = "خامل • جاهز للعب",
                ["ingame"] = "في اللعبة • In-Game",
                ["settings"] = "الإعدادات",
                ["language"] = "اللغة",
                ["version"] = "الإصدار",
                ["verified"] = "تم التحقق • بناء #105",
                ["discord_on"] = "Discord مفعل",
                ["updater_on"] = "التحديث التلقائي مفعل",
                ["success"] = "نجاح • تم التحقق",
                ["welcome"] = "مرحبا",
                ["select_lang"] = "اختر اللغة"
            },
            ["IR"] = new() {
                ["app_title"] = "PBNG لانچر",
                ["app_subtitle"] = "Point Blank NG - سرور خصوصی",
                ["launch"] = "🚀 اجرای بازی",
                ["update_available"] = "آپدیت موجود است!",
                ["update_now"] = "الان آپدیت کنیم؟",
                ["downloading"] = "در حال دانلود...",
                ["ready"] = "آماده بازی Point Blank",
                ["in_launcher"] = "در PBNG Launcher",
                ["idle"] = "بیکار • آماده بازی",
                ["ingame"] = "در بازی • In-Game",
                ["settings"] = "تنظیمات",
                ["language"] = "زبان",
                ["version"] = "نسخه",
                ["verified"] = "تایید شده • ساخت #105",
                ["discord_on"] = "Discord روشن",
                ["updater_on"] = "آپدیت خودکار روشن",
                ["success"] = "موفق • تایید شده",
                ["welcome"] = "خوش آمدید",
                ["select_lang"] = "انتخاب زبان"
            }
        };

        public event Action? OnLanguageChanged;

        public void SetLanguage(string code)
        {
            if (translations.ContainsKey(code))
            {
                CurrentLang = code;
                SaveLang(code);
                OnLanguageChanged?.Invoke();
            }
        }

        public string T(string key)
        {
            if (translations.TryGetValue(CurrentLang, out var dict) && dict.TryGetValue(key, out var val))
                return val;
            // Fallback to EN
            if (translations["EN"].TryGetValue(key, out var enVal))
                return enVal;
            return key;
        }

        private void SaveLang(string code)
        {
            try { File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lang.txt"), code); } catch {}
        }

        public void LoadSavedLang()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lang.txt");
                if (File.Exists(path))
                {
                    var code = File.ReadAllText(path).Trim().ToUpper();
                    if (translations.ContainsKey(code)) CurrentLang = code;
                }
            }
            catch {}
        }

        public List<string> GetAllCodes() => new(translations.Keys);
    }
}
