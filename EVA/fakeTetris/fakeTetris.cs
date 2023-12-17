using System.Drawing;
using System.Xml.Linq;

namespace fakeTetris
{
    public partial class fakeTetris : Form
    {
        private GridButton[,] buttons;
        private GridButton[,] nextButtons;
        private FakeTetrisModel model;
        public fakeTetris()
        {
            InitializeComponent();

            model = new FakeTetrisModel();
            model.Next += Next;
            model.Place += Place;
            model.Bed += Bed;
            buttons = new GridButton[4, 4];
            nextButtons = new GridButton[4, 4];

            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++)
                {
                    GridButton button = new GridButton(i,j);
                    button.BackColor = Color.White;
                    button.Dock = DockStyle.Fill;
                    button.Click += new EventHandler(GridClick);
                    buttons[i,j] = button;
                    tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    GridButton button = new GridButton(i, j);
                    button.BackColor = Color.White;
                    button.Dock = DockStyle.Fill;
                    nextButtons[i, j] = button;
                    NextGrid.Controls.Add(button, j, i);
                }
            }

            model.New();
        }

        private void GridClick(object? sender, EventArgs e)
        {
            if(sender is GridButton gridButton)
            {
                model.isGood(gridButton.X, gridButton.Y);
            }
        }

        private void Next(object? sender, NextEventArgs e)
        {
            for(int i = 0;i < 2;i++)
            {
                for(int j = 0;j < 2;j++)
                    nextButtons[i,j].BackColor = Color.White;
            }
            nextButtons[0,0].BackColor = Color.Red;
            switch (e.Type)
            {
                case 1:
                    nextButtons[1,0].BackColor = Color.Red; break;
                case 2:
                    nextButtons[0,1].BackColor = Color.Red; break;
                case 3:
                    nextButtons[1,0].BackColor = Color.Red;
                    nextButtons[1,1].BackColor = Color.Red; break;
                case 4:
                    nextButtons[0,1].BackColor = Color.Red;
                    nextButtons[1,1].BackColor = Color.Red; break;
                default:
                    break;
            }
        }

        private void Place(object? sender, PlaceEventArgs e)
        {
            label1.Visible = false;
            buttons[e.X, e.Y].BackColor = Color.Red;
            switch (e.Type)
            {
                case 1:
                    buttons[e.X+1, e.Y].BackColor = Color.Red; break;
                case 2:
                    buttons[e.X, e.Y+1].BackColor = Color.Red; break;
                case 3:
                    buttons[e.X+1, e.Y].BackColor = Color.Red;
                    buttons[e.X+1, e.Y+1].BackColor = Color.Red; break;
                case 4:
                    buttons[e.X, e.Y + 1].BackColor = Color.Red;
                    buttons[e.X+1, e.Y + 1].BackColor = Color.Red; break;
                default:
                    break;
            }
        }

        private void Bed(object? sender, EventArgs e)
        {
            label1.Visible = true;
        }
    }
}
