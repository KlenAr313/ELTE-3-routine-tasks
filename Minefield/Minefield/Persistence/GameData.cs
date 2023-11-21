using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Persistence
{
    /// <summary>
    /// Game data for data access
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// List of active mines
        /// </summary>
        public List<Mine> mineList { get; set; }

        /// <summary>
        /// Instace of a submarine
        /// </summary>
        public Submarine submarine { get; set; }

        /// <summary>
        /// Time of the game
        /// </summary>
        public int gameTime { get; set; }

        /// <summary>
        /// Remaining time for nex mine generation
        /// </summary>
        public int untilGenerate { get; set; }

        /// <summary>
        /// Base line for the next untiolGenerate start point
        /// </summary>
        public int generateTime { get; set; }

        /// <summary>
        /// Constructor of Game data
        /// </summary>
        /// <param name="mineList">List of active mines</param>
        /// <param name="submarine">Instace of a submarine</param>
        /// <param name="gameTime">Time of the game</param>
        /// <param name="untilGenerate">Remaining time for nex mine generation</param>
        /// <param name="generateTime">Base line for the next untiolGenerate start point</param>
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
