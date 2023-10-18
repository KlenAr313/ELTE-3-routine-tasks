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
        public int gameTime;

        public EventHandler<EventArgs>? oneSecTic;

        public MinefieldGameModel()
        {
            gameTime = 0;
            oneSecTic += SpendTime;
        }

        public void Start() { }

        public void Stop() 
        {
            oneSecTic -= SpendTime;
        }

        public void Restrume()
        {
            oneSecTic += SpendTime;
        }

        public void Reset() { }

        private void SpendTime(object? sender, EventArgs e)
        {
            gameTime++;
        }

    }
}
