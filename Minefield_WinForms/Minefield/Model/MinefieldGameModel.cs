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
        private Timer frameTick;
        private List<Mine> mineList;
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

            frameTick = new Timer();
            frameTick.Interval = 10;
            frameTick.Elapsed += OneFrame;

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
            frameTick.Stop();
        }

        public void Restrume()
        {
            StartTimers();
        }

        private void SpendTime(object? sender, EventArgs e)
        {
            gameTime++;
        }

        public void OneFrame(object? sender, EventArgs e)
        {
            mineList.ForEach(mine => mine.Move());
            untilGenerate--;

            if (untilGenerate == 0) 
            {
                GenerateMine();
                if (generateTime > 0)
                {
                    generateTime -= 10;
                    untilGenerate = generateTime;
                }
            }

            Refresh?.Invoke(this, new MinefieldEventArgs(mineList));
        }

        public void GenerateMine()
        {
            mineList.Add(new Mine(maxX));
        }

        private void StartTimers()
        {
            oneSecTick.Start();
            frameTick.Start();
        }
    }
}
