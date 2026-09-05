using System; using System.IO; using System.IO.Compression; using System.Windows;

namespace PBNG.Launcher
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // AUTO APPLY UPDATE - ini yang di powershell kode gambar bos!
            // pas launcher.exe di update, dia bakal restart pake --apply-update
            if(e.Args.Length > 0 && e.Args[0] == "--apply-update")
            {
                try
                {
                    if(File.Exists("PBNG.Launcher.v360.new.exe"))
                    {
                        if(File.Exists("PBNG.Launcher.v360.exe.old")) File.Delete("PBNG.Launcher.v360.exe.old");
                        File.Move("PBNG.Launcher.v360.exe", "PBNG.Launcher.v360.exe.old");
                        File.Move("PBNG.Launcher.v360.new.exe", "PBNG.Launcher.v360.exe");
                    }
                    if(File.Exists("hero.png.new"))
                    {
                        if(File.Exists("hero.png")) File.Delete("hero.png");
                        File.Move("hero.png.new", "hero.png");
                    }
                    if(File.Exists("skin.zip"))
                    {
                        if(Directory.Exists("skin")) Directory.Delete("skin", true);
                        ZipFile.ExtractToDirectory("skin.zip", "skin");
                        File.Delete("skin.zip");
                    }
                    if(File.Exists("icons.zip"))
                    {
                        if(Directory.Exists("icons")) Directory.Delete("icons", true);
                        ZipFile.ExtractToDirectory("icons.zip", "icons");
                        File.Delete("icons.zip");
                    }
                    // auto update file client game
                    foreach(var f in Directory.GetFiles("Game", "*.new", SearchOption.AllDirectories))
                    {
                        var target = f.Substring(0, f.Length - 4);
                        if(File.Exists(target)) File.Delete(target);
                        File.Move(f, target);
                    }
                    File.Delete("update_launcher.pending");
                    File.Delete("PBNG.Launcher.v360.exe.old");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Auto update failed: {ex.Message}");
                }
            }
            base.OnStartup(e);
        }
    }
}
