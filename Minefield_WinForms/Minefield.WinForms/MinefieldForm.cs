using Minefield.Model;
using Timer = System.Timers.Timer;

namespace Minefield.WinForms
{
    public partial class MinefieldForm : Form
    {
        private MinefieldGameModel gameModel;
        private List<PictureBox> mines = new List<PictureBox>();
        private bool pause;

        public MinefieldForm()
        {
            InitializeComponent();
            gameModel = new MinefieldGameModel(this.Width, this.Height);
            frameTick.Interval = 10;
            frameTick.Tick += Frame;
        }

        private void mni_NewGame_Click(object sender, EventArgs e)
        {
            gameModel = new MinefieldGameModel(this.Width, this.Height);
            gameModel.oneSecTick.Elapsed += GameTime;
            gameModel.Refresh += Refresh;
            gameModel.NewGame();
            mines.ForEach(m => this.Controls.Remove(m));

            frameTick.Start();

            mines = new List<PictureBox>();

            pause = false;
            mni_SaveGame.Enabled = false;
            lbl_Paused.Visible = false;
        }

        private void mni_LoadGame_Click(object sender, EventArgs e)
        {

        }

        private void mni_SaveGame_Click(object sender, EventArgs e)
        {

        }

        private void mni_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Minefield", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void MinefieldForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !pause)
            {
                gameModel.Pause();
                frameTick.Stop();
                pause = true;
                mni_SaveGame.Enabled = true;
                lbl_Paused.Visible = true;
            }
            else if (e.KeyCode == Keys.Escape && pause)
            {
                gameModel.Restrume();
                frameTick.Start();
                pause = false;
                mni_SaveGame.Enabled = false;
                lbl_Paused.Visible = false;
            }
        }

        private void GameTime(object? sender, EventArgs e)
        {
            lbl_GameTime.Text = TimeSpan.FromSeconds(gameModel.gameTime).ToString("g");
        }

        private void Frame(object? sender, EventArgs e)
        {
            gameModel.OnFrame();
        }

        private void Refresh(object? sender, MinefieldEventArgs e)
        {
            mines.ForEach(m => this.Controls.Remove(m));
            e.Mines.ForEach(m =>
            {
                PictureBox mine = new PictureBox();
                mine.Image = Properties.Resources.mine;
                mine.Location = new Point(m.x, m.y);
                mine.Name = "mine";
                mine.Size = new Size(200, 200);
                mines.Add(mine);
                this.Controls.Add(mine);
            });
        }
    }
}