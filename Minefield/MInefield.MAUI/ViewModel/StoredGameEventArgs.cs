using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Stroed game's event argument
    /// </summary>
    public class StoredGameEventArgs : EventArgs
    {
        /// <summary>
        /// The name of the game
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
