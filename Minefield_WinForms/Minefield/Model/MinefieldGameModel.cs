using System;
using System.Collections.Generic;
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
        public List<Mine> mineList;
        public int gameTime;

        private int maxX;
        private int maxY;
        private int untilGenerate;
        private int generateTime;

        public EventHandler<MinefieldEventArgs>? Refresh;


        public MinefieldGameModel(int maxX, int maxY)
        {
            gameTime = 0;

            oneSecTick = new Timer();
            oneSecTick.Interval = 1000;
            oneSecTick.Elapsed += SpendTime;

            mineList = new List<Mine>();

            this.maxX = maxX;
            this.maxY = maxY;
            untilGenerate = 300;
            generateTime = 300;
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
            mineList.ForEach(mine => mine.Move());
            untilGenerate--;

            if (untilGenerate == 0) 
            {
                GenerateMine();
                if (generateTime > 0)
                {
                    generateTime -= 3;
                    untilGenerate = generateTime;
                }
            }

            Refresh?.Invoke(this, new MinefieldEventArgs(mineList));
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
    }
}
