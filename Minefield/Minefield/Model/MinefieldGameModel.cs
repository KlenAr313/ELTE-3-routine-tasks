using Minefield.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Minefield.Model
{
    /// <summary>
    /// Class of Minefield game
    /// </summary>
    public class MinefieldGameModel : IDisposable
    {
        private Timer oneSecTick;
        private int gameTime;

        /// <summary>
        /// Timer for game time
        /// </summary>
        public Timer OneSecTick { get { return oneSecTick; } }
        
        /// <summary>
        /// Passed time of game since start
        /// </summary>
        public int GameTime { get { return gameTime; } }

        private readonly List<Mine> mineList;
        private readonly Submarine submarine;

        private readonly int maxX;
        private readonly int maxY;
        private int untilGenerate;
        private int generateTime;

        private EventHandler<MinefieldEventArgs>? refresh;

        /// <summary>
        /// Event to refresh frontend
        /// </summary>
        public EventHandler<MinefieldEventArgs>? Refresh { get { return refresh; } set { refresh = value; } }

        private EventHandler? end;

        /// <summary>
        /// Event at game over
        /// </summary>
        public EventHandler? End { get { return end; } set { end = value; } }

        /// <summary>
        /// Constructor in case of new game
        /// </summary>
        /// <param name="maxX">Maximum horizontal position</param>
        /// <param name="maxY">Maximum vertical position</param>
        public MinefieldGameModel(int maxX, int maxY)
        {
            oneSecTick = new Timer
            {
                Interval = 1000
            };
            oneSecTick.Elapsed += SpendTime;

            gameTime = 0;
            mineList = new List<Mine>();
            submarine = new Submarine(maxX, maxY);

            this.maxX = maxX;
            this.maxY = maxY;
            untilGenerate = 20;
            generateTime = 250;

            Directions.Reset();
        }

        /// <summary>
        /// Constructor in case of loading a saved game
        /// </summary>
        /// <param name="maxX">Maximum horizontal position</param>
        /// <param name="maxY">Maximum vertical position</param>
        /// <param name="dataAccess">Instance of a data acces</param>
        public MinefieldGameModel(int maxX, int maxY, DataAccess dataAccess) 
        {
            oneSecTick = new Timer
            {
                Interval = 1000
            };
            oneSecTick.Elapsed += SpendTime;

            GameData gameData = dataAccess.Load();

            if(gameData.maxX != maxX || gameData.maxY != maxY)
            {
                throw new NotSupportedException("Not supported savefile");
            }

            gameTime = gameData.gameTime;
            untilGenerate = gameData.untilGenerate;
            generateTime = gameData.generateTime;
            mineList = gameData.mineList;
            submarine = gameData.submarine;

            this.maxX = maxX;
            this.maxY = maxY;

            Directions.Reset();
        }

        /// <summary>
        /// Saving the current status of the game
        /// </summary>
        /// <param name="dataAccess"></param>
        public void SaveGame(DataAccess dataAccess)
        {
            GameData gameData = new(mineList, submarine, gameTime, untilGenerate, generateTime, maxX, maxY);
            dataAccess.Save(gameData);
        }

        /// <summary>
        /// Start the game's timers
        /// </summary>
        public void StartGame() 
        {
            StartTimers();
        }

        /// <summary>
        /// Pauses the timer 
        /// </summary>
        public void Pause() 
        {
            oneSecTick.Stop();
        }
        
        /// <summary>
        /// Start the game's timers
        /// </summary>
        public void Restrume()
        {
            StartTimers();
        }

        /// <summary>
        /// Move every element of the game, send signal to frontend
        /// </summary>
        public void OnFrame()
        {
            if(oneSecTick.Enabled)
            {
                MoveMines();
            
                MoveSubmarine();

                refresh?.Invoke(this, new MinefieldEventArgs(mineList, submarine));

                Collision();
            }
        }

        private void SpendTime(object? sender, EventArgs e)
        {
            gameTime++;
        }

        private void StartTimers()
        {
            oneSecTick.Start();
        }

        private void MoveSubmarine()
        {
            if (Directions.Up) submarine.MoveUp();
            if (Directions.Down) submarine.MoveDown();
            if (Directions.Left) submarine.MoveLeft();
            if (Directions.Right) submarine.MoveRight();
        }

        private void MoveMines()
        {
            mineList.RemoveAll(mine => mine.Y > maxY - 30);

            mineList.ForEach(mine =>
            { mine.Move(); });

            untilGenerate--;

            if (untilGenerate <= 0)
            {
                GenerateMine();
                if (generateTime > 0)
                {
                    generateTime -= 2;
                    untilGenerate = generateTime;
                }
            }
        }

        private void GenerateMine()
        {
            mineList.Add(new Mine(maxX));
        }

        private void Collision()
        {
            mineList.ForEach((mine) =>
            {
                if ( mine.Y > submarine.Y - 45 && mine.Y < submarine.Y + 115 && mine.X > submarine.X - 50 && mine.X < submarine.X + 120 )
                {
                    Pause();
                    end?.Invoke(this, EventArgs.Empty);
                }
            });
        }

        /// <summary>
        /// Implement IDisposeable
        /// </summary>
        public void Dispose()
        {
            oneSecTick.Dispose();
            OneSecTick.Dispose();
        }
    }
}
