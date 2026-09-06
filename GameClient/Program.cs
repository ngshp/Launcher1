using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameClient
{
    // FORM SPLASH LOADING PBNG KEREN
    public class SplashForm : Form
    {
        private Timer timer;
        private int progress = 0;
        private PictureBox bg;
        private Panel progressBar;
        private Panel progressFill;

        public SplashForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 450);
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.BackColor = Color.Black;

            // Background image splash_ngpb_800.png
            bg = new PictureBox();
            bg.Dock = DockStyle.Fill;
            bg.SizeMode = PictureBoxSizeMode.StretchImage;
            try {
                bg.Image = Image.FromFile("splash_ngpb_800.png");
            } catch {
                // kalo file gak ketemu, pake background_client_game.png
                try { bg.Image = Image.FromFile("background_client_game.png"); } catch {}
            }
            this.Controls.Add(bg);

            // Progress bar bawah animasi
            progressBar = new Panel();
            progressBar.Size = new Size(600, 8);
            progressBar.Location = new Point(100, 380);
            progressBar.BackColor = Color.FromArgb(30, 30, 60);
            progressBar.BorderStyle = BorderStyle.None;
            bg.Controls.Add(progressBar);

            progressFill = new Panel();
            progressFill.Size = new Size(0, 8);
            progressFill.Location = new Point(0, 0);
            progressFill.BackColor = Color.FromArgb(0, 200, 255); // biru neon
            progressBar.Controls.Add(progressFill);

            // Timer loading 3 detik
            timer = new Timer();
            timer.Interval = 30; // 30ms x 100 = 3 detik
            timer.Tick += (s,e) => {
                progress += 2;
                progressFill.Width = (int)(progressBar.Width * progress / 100.0);
                if(progress >= 100){
                    timer.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
            timer.Start();
        }
    }

    // MAIN ENTRY POINT ngpb.exe
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. TAMPILIN SPLASH KEREN 3 DETIK
            using(var splash = new SplashForm()){
                splash.ShowDialog();
            }

            // 2. BARU JALANIN FORM UTAMA GAME LU
            // Ganti MainForm() jadi nama Form utama lu kalo beda
            // Contoh: Form1, GameForm, ClientForm, LobbyForm
            Application.Run(new Form1());
        }
    }
}
