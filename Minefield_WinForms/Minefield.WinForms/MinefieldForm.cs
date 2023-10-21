using Minefield.Model;
using Timer = System.Timers.Timer;

namespace Minefield.WinForms
{
    public partial class MinefieldForm : Form
    {
        private MinefieldGameModel gameModel;
        private List<PictureBox> mines = new List<PictureBox>();
        private PictureBox submarine;
        private bool pause;
        private bool isGameOver;

        public MinefieldForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            gameModel = new MinefieldGameModel(this.Width, this.Height);
            frameTick.Interval = 10;
            frameTick.Tick += Frame;

            submarine = new PictureBox();
            CreateSubmarine(250, 700);
            this.Controls.Add(submarine);
        }

        private void mni_NewGame_Click(object sender, EventArgs e)
        {
            mines.ForEach(m => this.Controls.Remove(m));
            mines = new List<PictureBox>();

            gameModel = new MinefieldGameModel(this.Width, this.Height);
            gameModel.oneSecTick.Elapsed += GameTime;
            gameModel.Refresh += Refresh;
            gameModel.End += GameOver;
            gameModel.NewGame();

            frameTick.Start();

            this.Controls.Remove(submarine);
            CreateSubmarine(250, 700);
            this.Controls.Add(submarine);

            Directions.Reset();

            pause = false;
            mni_SaveGame.Enabled = false;
            lbl_Paused.Visible = false;

            isGameOver = false;
        }

        private void mni_LoadGame_Click(object sender, EventArgs e)
        {

        }

        private void mni_SaveGame_Click(object sender, EventArgs e)
        {

        }

        private void mni_Exit_Click(object sender, EventArgs e)
        {
            gameModel.Pause();
            frameTick.Stop();
            pause = true;
            lbl_Paused.Visible = true;
            if (MessageBox.Show("Are you sure you want to exit?", "Minefield", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                gameModel.Restrume();
                frameTick.Start();
                pause = false;
                lbl_Paused.Visible = false;
            }
        }

        private void MinefieldForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: Directions.Up = true; break;
                case Keys.Down: Directions.Down = true; break;
                case Keys.Left: Directions.Left = true; break;
                case Keys.Right: Directions.Right = true; break;
                case Keys.Escape:
                    if (!pause && !isGameOver)
                    {
                        gameModel.Pause();
                        frameTick.Stop();
                        pause = true;
                        mni_SaveGame.Enabled = true;
                        lbl_Paused.Visible = true;
                    }
                    else if (pause && !isGameOver)
                    {
                        gameModel.Restrume();
                        frameTick.Start();
                        pause = false;
                        mni_SaveGame.Enabled = false;
                        lbl_Paused.Visible = false;
                    }
                    break;
            }
        }

        private void MinefieldForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: Directions.Up = false; break;
                case Keys.Down: Directions.Down = false; break;
                case Keys.Left: Directions.Left = false; break;
                case Keys.Right: Directions.Right = false; break;
            }
        }

        private void GameTime(object? sender, EventArgs e)
        {
            lbl_GameTime.Text = TimeSpan.FromSeconds(gameModel.GameTime).ToString("g");
            GC.Collect();
        }

        private void Frame(object? sender, EventArgs e)
        {
            gameModel.OnFrame();
        }

        private void Refresh(object? sender, MinefieldEventArgs e)
        {
            this.Controls.Remove(submarine);
            CreateSubmarine(e.Submarine.X, e.Submarine.Y);
            this.Controls.Add(submarine);

            mines.ForEach(m => this.Controls.Remove(m));
            mines.Clear();
            e.Mines.ForEach(m =>
            {
                PictureBox mine = new PictureBox();
                mine.Image = Properties.Resources.mineMini;
                mine.Location = new Point(m.X, m.Y);
                mine.Name = "mine";
                mine.Size = new Size(50, 50);
                mines.Add(mine);
                this.Controls.Add(mine);
            });

        }

        private void GameOver(object? sender, EventArgs e)
        {
            if (!isGameOver)
            {
                gameModel.Pause();
                frameTick.Stop();
                MessageBox.Show($"You have lost the game.\nYour Time: {TimeSpan.FromSeconds(gameModel.GameTime).ToString("g")}",
                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isGameOver = true;
            }
        }

        private void CreateSubmarine(int x, int y)
        {
            submarine = new PictureBox();
            submarine.Image = Properties.Resources.submarineMini;
            submarine.Location = new Point(x, y);
            submarine.Name = "submarine";
            submarine.Size = new Size(128, 120);
        }
    }
}