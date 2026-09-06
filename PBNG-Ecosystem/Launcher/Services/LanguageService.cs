#nullable enable
using System;
using System.Collections.Generic;
using System.IO;

namespace PBNG.Launcher.Services
{
    public class LanguageService
    {
        public static LanguageService Instance { get; } = new();
        
        public string CurrentLang { get; private set; } = "ID";
        
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
                ["verified"]
