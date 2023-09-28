using System.Xml;

namespace UnoDuo
{
    public partial class Form1 : Form
    {
        private int points = 0;
        private Random rnd = new Random();
        private DateTime time;

        public Form1()
        {
            InitializeComponent();
            time = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = ClientSize.Width - button1.Width;
            int y = ClientSize.Height - button1.Height - statusStrip1.Height;
            button1.Location = new Point(rnd.Next(x), rnd.Next(y));

            if (!timer1.Enabled)
            {
                time = DateTime.Now;
                timer1.Start();
            }
            else
            {
                ++points;
                if (points == 100)
                {
                    timer1.Stop();
                    fYou(); 
                    GameClosing();
                }

            }
            UpdateStatusBar(sender, e);
        }

        private void fYou()
        {
            button1.Enabled = false;
            button1.Width = 300;
            button1.Text = "You are a jerk, leave me alone";
        }

        private void UpdateStatusBar(object sender, EventArgs e)
        {
            double elapsedSeconds = (DateTime.Now - time).TotalSeconds;
            statusLabel1.Text = $"Points: {points} | Elapsed time: {elapsedSeconds:F0} sec";
        }

        private void GameClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && timer1.Enabled)
            {
                double elapsedSeconds = (DateTime.Now - time).TotalSeconds;
                double pushPerSeconds = points / elapsedSeconds;
                MessageBox.Show($"Pushes per seconds: {pushPerSeconds:F2}", "Results",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GameClosing()
        {
            double elapsedSeconds = (DateTime.Now - time).TotalSeconds;
            double pushPerSeconds = points / elapsedSeconds;
            MessageBox.Show($"Pushes per seconds: {pushPerSeconds:F2}", "Results",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}