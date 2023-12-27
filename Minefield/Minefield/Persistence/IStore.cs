using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Persistence
{
    /// <summary>
    /// Interface of game store
    /// </summary>
    public interface IStore
    {
        /// <summary>
        /// File querry
        /// </summary>
        /// <returns>List of files</returns>
        Task<IEnumerable<string>> GetFile();

        /// <summary>
        /// Time of modification querry
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>Last modification's date</returns>
        Task<DateTime> GetModifiedTime(string name);
    }
}
