using PBNG.Launcher.Services;

public partial class Form1 : Form
{
    private DiscordService discord = new();
    private UpdateService updater = new();

    private async void Form1_Load(object sender, EventArgs e)
    {
        try { discord.Init("1234567890123456789"); } catch {}
        discord.SetPresence("In PBNG Launcher", "Browsing");

        var (hasUpdate, ver, url) = await updater.CheckAsync();
        if (hasUpdate && MessageBox.Show($"Update v{ver} tersedia! Update?", "PBNG", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            await updater.DownloadAndInstallAsync(url);
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e) => discord.Dispose();
}
