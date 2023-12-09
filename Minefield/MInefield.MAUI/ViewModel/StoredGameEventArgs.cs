using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    public class StoredGameEventArgs : EventArgs
    {
        public string Name { get; set; } = string.Empty;
    }
}
