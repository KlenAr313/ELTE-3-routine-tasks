using Minefield.Model;

namespace Minefield.WinForms
{
    public partial class MinefieldForm : Form
    {
        private MinefieldGameModel gameModel;
        private bool pause;

        public MinefieldForm()
        {
            InitializeComponent();
            gameModel = new MinefieldGameModel();
            gameModel.oneSecTick.Elapsed += tmr_GameTime_Tick;
        }

        private void mni_NewGame_Click(object sender, EventArgs e)
        {
            gameModel.NewGame();
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

        private void tmr_GameTime_Tick(object? sender, EventArgs e)
        {
            lbl_GameTime.Text = TimeSpan.FromSeconds(gameModel.gameTime).ToString("g");
        }

        private void MinefieldForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !pause)
            {
                gameModel.Pause();
                pause = true;
                mni_SaveGame.Enabled = true;
                lbl_Paused.Visible = true;
            }
            else if (e.KeyCode == Keys.Escape && pause)
            {
                gameModel.Restrume();
                pause = false;
                mni_SaveGame.Enabled = false;
                lbl_Paused.Visible = false;
            }
        }
    }
}