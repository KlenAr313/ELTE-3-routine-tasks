using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.WinForms
{
    /// <summary>
    /// Class of Form for the game
    /// </summary>
    public partial class MinefieldForm : Form
    {
        private MinefieldGameModel gameModel;
        private List<PictureBox> mines = new();
        private PictureBox submarine;
        private bool pause;
        private bool isGameOver;

        /// <summary>
        /// Constructor of the Form
        /// </summary>
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

            isGameOver = true;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            mines.ForEach(m => this.Controls.Remove(m));
            mines = new List<PictureBox>();

            gameModel = new MinefieldGameModel(this.Width, this.Height);
            gameModel.OneSecTick.Elapsed += GameTime;
            gameModel.Refresh += Refresh;
            gameModel.End += GameOver;
            gameModel.StartGame();

            frameTick.Start();

            this.Controls.Remove(submarine);
            CreateSubmarine(250, 700);
            this.Controls.Add(submarine);

            Directions.Reset();

            pause = false;
            mni_SaveGame.Enabled = false;
            mni_LoadGame.Enabled = false;
            lbl_Paused.Visible = false;

            isGameOver = false;
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataAccess dataAcces = new(openFileDialog.FileName);
                    gameModel = new MinefieldGameModel(this.Width, this.Height, dataAcces);
                    gameModel.OneSecTick.Elapsed += GameTime;
                    gameModel.Refresh += Refresh;
                    gameModel.End += GameOver;

                    mines.ForEach(m => this.Controls.Remove(m));
                    mines = new List<PictureBox>();

                    this.Controls.Remove(submarine);
                    CreateSubmarine(250, 700);
                    this.Controls.Add(submarine);

                    MessageBox.Show("let's continue!", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gameModel.StartGame();

                    frameTick.Start();

                    pause = false;
                    mni_SaveGame.Enabled = false;
                    mni_LoadGame.Enabled = false;
                    lbl_Paused.Visible = false;

                    isGameOver = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to load game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Directions.Reset();
            }
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataAccess dataAccess = new(saveFileDialog.FileName);
                    gameModel.SaveGame(dataAccess);
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to save game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
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
                        mni_LoadGame.Enabled = true;
                        lbl_Paused.Visible = true;
                    }
                    else if (pause && !isGameOver)
                    {
                        gameModel.Restrume();
                        frameTick.Start();
                        pause = false;
                        mni_SaveGame.Enabled = false;
                        mni_LoadGame.Enabled = false;
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
                PictureBox mine = new()
                {
                    Image = Properties.Resources.mineMini,
                    Location = new Point(m.X, m.Y),
                    Name = "mine",
                    Size = new Size(50, 50)
                };
                mines.Add(mine);
                this.Controls.Add(mine);
            });

        }

        private void GameOver(object? sender, EventArgs e)
        {
            if (!isGameOver)
            {
                frameTick.Stop();
                MessageBox.Show($"You have lost the game.\nYour Time: {TimeSpan.FromSeconds(gameModel.GameTime).ToString("g")}",
                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mni_LoadGame.Enabled = true;
                isGameOver = true;
            }
        }

        private void CreateSubmarine(int x, int y)
        {
            submarine = new PictureBox
            {
                Image = Properties.Resources.submarineMini,
                Location = new Point(x, y),
                Name = "submarine",
                Size = new Size(128, 120)
            };
        }
    }
}