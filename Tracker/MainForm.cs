using System.Drawing.Text;
using System.Runtime.InteropServices;
using Timer = Tracker.Classes.Timer;

namespace Tracker
{
    public partial class MainForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private Timer timer = new Timer();

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainForm(PrivateFontCollection privateFontCollection)
        {
            InitializeComponent();
            this.Height = 39;
        }

        private void lbl_timer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pause(sender, e);
        }

        private void Pause(object sender, EventArgs e)
        {
            button1.Text = "►";
            timer1.Enabled = false;
            //button1.Click = null;
            button1.Click -= button1_Click;
            button1.Click -= Pause;
            button1.Click += Resume;
            lbl_timer.ForeColor = Color.Crimson;
        }

        private void Resume(object sender, EventArgs e)
        {
            button1.Text = "||";
            timer1.Enabled = true;
            button1.Click -= button1_Click;
            button1.Click -= Resume;
            button1.Click += Pause;
            lbl_timer.ForeColor = Color.FromArgb(255, 0, 192, 0); ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Time = timer.Time.Add(new TimeSpan(0, 0, 1));
            lbl_timer.Text = timer.ToString();
        }
    }
}