using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winFormZH.Model.Persistence
{
    public class GameData
    {
        public int X { get; set; }

        public int Y { get; set; }

        public List<int> Table { get; set; } = null!;

        public int GameStepCount { get; set; }

        public GameData(int[,] Table, int GameStepCount, int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Table = new List<int>();
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    this.Table.Add(Table[i, j]);
                }
            }
            this.GameStepCount = GameStepCount;
        }

        public GameData() { }
    }
}
