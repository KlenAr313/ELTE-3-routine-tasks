using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Persistence
{
    public class GameData
    {
        private readonly List<Mine> mineList;
        private readonly Submarine submarine;
        private readonly int gameTime;

        public List<Mine> MineList { get { return mineList; } }
        public Submarine Submarine { get { return submarine; } }
        public int GameTime { get { return gameTime; } }
            
        public GameData(List<Mine> mineList, Submarine submarine, int gameTime)
        {
            this.mineList = mineList;
            this.submarine = submarine;
            this.gameTime = gameTime;
        }

    }
}
