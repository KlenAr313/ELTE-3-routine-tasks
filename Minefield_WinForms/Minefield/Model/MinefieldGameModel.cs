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
    public class MinefieldGameModel
    {
        public Timer oneSecTick;
        private int gameTime;

        public int GameTime { get { return gameTime; } }

        private List<Mine> mineList;
        private Submarine submarine;

        private int maxX;
        private int maxY;
        private int untilGenerate;
        private int generateTime;

        public EventHandler<MinefieldEventArgs>? Refresh;

        public EventHandler? End;


        public MinefieldGameModel(int maxX, int maxY)
        {
            gameTime = 0;

            oneSecTick = new Timer();
            oneSecTick.Interval = 1000;
            oneSecTick.Elapsed += SpendTime;

            mineList = new List<Mine>();
            submarine = new Submarine(maxX, maxY);

            this.maxX = maxX;
            this.maxY = maxY;
            untilGenerate = 250;
            generateTime = 250;
        }

        public void NewGame() 
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

            Refresh?.Invoke(this, new MinefieldEventArgs(mineList, submarine));

            Collision();
        }

        private void SpendTime(object? sender, EventArgs e)
        {
            gameTime++;
        }


        public void GenerateMine()
        {
            mineList.Add(new Mine(maxX));
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

        private void Collision()
        {
            mineList.ForEach((mine) =>
            {
                if ( mine.Y > submarine.Y - 45 && mine.Y < submarine.Y + 115 && mine.X > submarine.X - 45 && mine.X < submarine.X + 123 )
                {
                    End?.Invoke(this, EventArgs.Empty);
                }
            });
        }
    }
}
