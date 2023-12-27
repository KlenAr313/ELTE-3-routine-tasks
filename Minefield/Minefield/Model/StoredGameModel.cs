using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Stored game modell
    /// </summary>
    public class StoredGameModel
    {
        /// <summary>
        /// Property of name
        /// </summary>
        public string Name { get; set; } = string.Empty; 

        /// <summary>
        /// Property of modification date
        /// </summary>
        public DateTime Modified {  get; set; }

        /// <summary>
        /// Constructor of the model
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="modified">Modification date</param>
        public StoredGameModel(string name, DateTime modified)
        {
            Name = name;
            Modified = modified;
        }
    }
}
