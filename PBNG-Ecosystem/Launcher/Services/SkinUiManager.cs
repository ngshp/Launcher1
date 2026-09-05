using System; using System.IO; using System.IO.Compression;

namespace PBNG.Launcher.Services
{
    public class SkinUiManager
    {
        public static SkinUiManager Instance = new SkinUiManager();
        
        public void ApplyAutoUpdate(string heroNew = "hero.png.new", string skinZip="skin.zip", string iconsZip="icons.zip")
        {
            // Auto ganti hero.png / tampilan
            if(File.Exists(heroNew)) { if(File.Exists("hero.png")) File.Delete("hero.png"); File.Move(heroNew, "hero.png"); }
            // Auto ganti skin / UI
            if(File.Exists(skinZip)) { if(Directory.Exists("skin")) Directory.Delete("skin", true); ZipFile.ExtractToDirectory(skinZip, "skin"); File.Delete(skinZip); }
            // Auto ganti ico / icon PNG
            if(File.Exists(iconsZip)) { if(Directory.Exists("icons")) Directory.Delete("icons", true); ZipFile.ExtractToDirectory(iconsZip, "icons"); File.Delete(iconsZip); }
            // Auto ganti ICO launcher
            if(File.Exists("icons/app.ico")) File.Copy("icons/app.ico", "PBNG.Launcher.v360.ico", true);
        }

        public void ChangeSkin(string skinName)
        {
            // skinName: tactical, cyber, dark, red, blue - auto download + apply
            var url = $"https://cdn.pbng.id/launcher-v360/skins/{skinName}.zip";
        }
    }
}
