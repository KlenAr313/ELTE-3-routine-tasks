using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeTetris
{
    public class FakeTetrisModel
    {
        private bool[,] map;
        private Random random;
        private NextEventArgs next;

        public event EventHandler<NextEventArgs>? Next;

        public event EventHandler<PlaceEventArgs>? Place;

        public event EventHandler<EventArgs>? Bed;

        public FakeTetrisModel()
        {
            random = new Random();
            map = new bool[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    map[i, j] = false;
            }

            next = new NextEventArgs(random.Next(1, 5));
        }

        public void isGood(int x, int y)
        {
            bool good = false;
            if (!map[x, y])
            {
                PlaceEventArgs place = new PlaceEventArgs(next.Type, x, y);
                switch (next.Type)
                {
                    case 1:
                        if (x < 3 && y < 4 && !map[x + 1, y])
                        {
                            Place?.Invoke(this, place); 
                            map[x, y] = true;
                            map[x + 1, y] = true; 
                            good = true;
                        }
                        break;
                    case 2:
                        if (x < 4 && y < 3 && !map[x, y + 1])
                        {
                            Place?.Invoke(this, place);
                            map[x, y] = true;
                            map[x, y + 1] = true; 
                            good = true;
                        }
                        break;
                    case 3:
                        if (x < 3 && y < 3 && !map[x + 1, y] && !map[x + 1, y + 1])
                        {
                            Place?.Invoke(this, place);
                            map[x, y] = true;
                            map[x + 1, y] = true; 
                            map[x + 1, y + 1] = true; 
                            good = true;
                        }
                        break;
                    case 4:
                        if (x < 3 && y < 3 && !map[x, y + 1] && !map[x + 1, y + 1])
                        {
                            Place?.Invoke(this, place);
                            map[x, y] = true;
                            map[x, y + 1] = true; 
                            map[x + 1, y + 1] = true; 
                            good = true;
                        }
                        break;
                    default: break;
                }
                if (good)
                {
                    next = new NextEventArgs(random.Next(1, 5));
                    Next?.Invoke(this, next);
                    return;
                }
            }
            Bed?.Invoke(this, new EventArgs());
        }

        public void New()
        {
            Next?.Invoke(this, next);
        }

    }
}
