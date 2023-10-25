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
    public class MinefieldGameModel : IDisposable
    {
        private Timer oneSecTick;
        private int gameTime;

        public Timer OneSecTick { get { return oneSecTick; } }
        public int GameTime { get { return gameTime; } }

        private readonly List<Mine> mineList;
        private readonly Submarine submarine;

        private readonly int maxX;
        private readonly int maxY;
        private int untilGenerate;
        private int generateTime;

        private EventHandler<MinefieldEventArgs>? refresh;
        public EventHandler<MinefieldEventArgs>? Refresh { get { return refresh; } set { refresh = value; } }

        private EventHandler? end;
        public EventHandler? End { get { return end; } set { end = value; } }

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
            untilGenerate = 250;
            generateTime = 250;

            Directions.Reset();
        }

        public MinefieldGameModel(int maxX, int maxY, DataAccess dataAccess) 
        {
            oneSecTick = new Timer
            {
                Interval = 1000
            };
            oneSecTick.Elapsed += SpendTime;

            GameData gameData = dataAccess.Load();

            gameTime = gameData.gameTime;
            untilGenerate = gameData.untilGenerate;
            generateTime = gameData.generateTime;
            mineList = gameData.mineList;
            submarine = gameData.submarine;

            this.maxX = maxX;
            this.maxY = maxY;

            Directions.Reset();
        }

        public void SaveGame(DataAccess dataAccess)
        {
            GameData gameData = new(mineList, submarine, gameTime, untilGenerate, generateTime);
            dataAccess.Save(gameData);
        }

        public void StartGame() 
        {
            StartTimers();
        }

        public void Pause() 
        {
            oneSecTick.Stop();
        }
        
        public void Restrume()
        {
            StartTimers();
        }

        public void OnFrame()
        {
            MoveMines();
            
            MoveSubmarine();

            refresh?.Invoke(this, new MinefieldEventArgs(mineList, submarine));

            Collision();
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
                if ( mine.Y > submarine.Y - 45 && mine.Y < submarine.Y + 115 && mine.X > submarine.X - 45 && mine.X < submarine.X + 123 )
                {
                    end?.Invoke(this, EventArgs.Empty);
                }
            });
        }

        public void Dispose()
        {
            oneSecTick.Dispose();
            OneSecTick.Dispose();
        }
    }
}
