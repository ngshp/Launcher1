using System;
using System.Drawing;
using System.Windows.Forms;

public class SplashForm : Form
{
    private Timer timer;
    private int progress = 0;
    private PictureBox bg;

    public SplashForm()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(800, 450);
        this.TopMost = true;
        this.ShowInTaskbar = false;

        bg = new PictureBox();
        bg.Dock = DockStyle.Fill;
        bg.SizeMode = PictureBoxSizeMode.StretchImage;
        // taro splash_ngpb_800.png di folder GameClient/Resources/
        bg.Image = Image.FromFile("splash_ngpb_800.png");
        this.Controls.Add(bg);

        timer = new Timer();
        timer.Interval = 30;
        timer.Tick += (s,e) => {
            progress += 2;
            if(progress >= 100){
                timer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        };
        timer.Start();
    }
}
