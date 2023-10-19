using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Minefield.Model
{
    public class MinefieldGameModel
    {
        public System.Timers.Timer oneSecTick;
        public int gameTime;


        public MinefieldGameModel()
        {
            oneSecTick = new System.Timers.Timer();
            oneSecTick.Interval = 1000;
            gameTime = 0;
            oneSecTick.Elapsed += SpendTime;
        }

        public void NewGame() 
        {
            gameTime = 0;
            oneSecTick.Start();
        }

        public void Pause() 
        {
            oneSecTick.Stop();
        }

        public void Restrume()
        {
            oneSecTick.Start();
        }

        public void Reset() { }

        private void SpendTime(object? sender, EventArgs e)
        {
            gameTime++;
        }

    }
}
