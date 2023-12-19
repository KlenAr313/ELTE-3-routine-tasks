using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    public class RadarModel
    {
        public bool[,] Target { get; private set; }

        Random r;

        public int TargetC { get; set; }

        public event EventHandler<RadarEventArgs>? Bombed;
        public event EventHandler<RadarEventArgs>? End;
        private int n;

        public RadarModel(int n) 
        {
            this.n = n;
            r = new Random();
            int rn;
            TargetC = 0;
            Target = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rn = r.Next(0, 4);
                    if(rn == 0 && TargetC <= n*2)
                    {
                        Target[i,j] = true;
                        TargetC++;
                    }
                    else
                        Target[i, j] = false;
                }
            }


            for (int i = n-1;i >= 0 && TargetC <= n * 2; i--)
            {
                for(int j = n-1; j >= 0; j--)
                {
                    rn = r.Next(0, 4);
                    if (rn == 0 && TargetC <= n * 2)
                    {
                        Target[i, j] = true;
                        TargetC++;
                    }
                }
            }
        }

        public void Bombing(int r, int c)
        {
            for (int i = (r-1 >= 0 ? r-1 : 0) ; i <= (r+1 < n ? r+1 : n-1); i++)
            {
                for (int j = (c-1 >= 0 ? c-1 : 0); j <= (c+1 < n ? c+1 : n-1) ; j++)
                {
                    if (Target[i,j])
                        TargetC--;
                    Target[i, j] = false;
                }
            }

            OnChange();

            if(TargetC <= 0)
            {
                OnWin();
            }
        }

        private void OnWin()
        {
            End?.Invoke(this, new RadarEventArgs(Target));
        }

        private void OnChange()
        {
            Bombed?.Invoke(this, new RadarEventArgs(Target));
        }
    }
}
