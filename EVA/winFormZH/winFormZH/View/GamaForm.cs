using winFormZH.Model.Model;
using winFormZH.Model.Persistence;

namespace winFormZH
{
    public partial class GamaForm : Form
    {
        private IDataAccess dataAccess = null!;
        private GameModel gameModel = null!;
        private GridButton[,]? gridButtons;

        public GamaForm()
        {
            InitializeComponent();

            dataAccess = new DataAccess();

            gameModel = new GameModel(5, 5, dataAccess);
            gameModel.FieldChanged += Model_FieldChanged;
            gameModel.GameCreated += Model_GameCreated;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            gameModel.NewGame(Convert.ToInt32(numericRows.Value), Convert.ToInt32(numericColumns.Value));
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    gameModel.LoadGame(openFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to load!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    gameModel.SaveGame(saveFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Model_GameCreated(object? sender, CreatedEventArgs e)
        {
            if (gridButtons != null)
            {
                foreach (Button button in gridButtons)
                {
                    tableLayoutGrid.Controls.Remove(button);
                }
            }
            gridButtons = new GridButton[e.X, e.Y];

            tableLayoutGrid.RowCount = e.X;
            tableLayoutGrid.ColumnCount = e.Y;

            for (int i = 0; i < e.X; i++)
            {
                for (int j = 0; j < e.Y; j++)
                {
                    gridButtons[i, j] = new GridButton(i, j);
                    gridButtons[i, j].Text = e.Table[i,j].ToString();
                    gridButtons[i, j].BackColor = Color.AliceBlue;
                    gridButtons[i, j].Dock = DockStyle.Fill;
                    gridButtons[i, j].Click += GridButton_Click;
                    tableLayoutGrid.Controls.Add(gridButtons[i, j], j ,i);
                }
            }

            tableLayoutGrid.RowStyles.Clear();
            tableLayoutGrid.ColumnStyles.Clear();

            for (int i = 0; i < e.X; i++)
            {
                tableLayoutGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(e.X)));
            }

            for (int i = 0; i < e.Y; i++)
            {
                tableLayoutGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(e.Y)));
            }

        }

        private void Model_FieldChanged(object? sender, FieldEventArgs e)
        {
            if(gridButtons != null)
                gridButtons[e.X, e.Y].Text = e.Num.ToString();
        }

        private void GridButton_Click(object? sender, EventArgs e)
        {
            if(sender is GridButton button)
            {
                gameModel.Step(button.X, button.Y);
            }
        }
    }
}
