namespace Minefield.WinForms
{
    public partial class MinefieldForm : Form
    {
        public MinefieldForm()
        {
            InitializeComponent();
        }

        private void mni_NewGame_Click(object sender, EventArgs e)
        {
            tmr_GameTime.Start();
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

        private void tmr_GameTime_Tick(object sender, EventArgs e)
        {
            lbl_GameTime.Text = tmr_GameTime.
        }
    }
}