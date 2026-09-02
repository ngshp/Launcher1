using System;
using System.Windows;
using PBNG.Launcher.Services;

namespace PBNG.Launcher
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            // Init Discord RPC
            var discord = new DiscordService();
            try
            {
                // GANTI dengan ID asli dari discord.com/developers/applications
                discord.Init("1234567890123456789");
            }
            catch {}

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
