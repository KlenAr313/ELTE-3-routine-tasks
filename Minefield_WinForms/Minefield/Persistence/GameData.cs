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
        public List<Mine> mineList { get; set; }
        public Submarine submarine { get; set; }
        public int gameTime { get; set; }
        public int untilGenerate { get; set; }
        public int generateTime { get; set; }

        public GameData(List<Mine> mineList, Submarine submarine, int gameTime, int untilGenerate, int generateTime)
        {
            this.mineList = mineList;
            this.submarine = submarine;
            this.gameTime = gameTime;
            this.generateTime = generateTime;
            this.untilGenerate = untilGenerate;
        }

    }
}
