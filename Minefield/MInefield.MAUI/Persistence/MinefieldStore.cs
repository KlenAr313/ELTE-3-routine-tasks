using Minefield.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.Persistence
{
    /// <summary>
    /// Model of game store
    /// </summary>
    public class MinefieldStore : IStore
    {
        /// <summary>
        /// Querry of files
        /// </summary>
        /// <returns>List of files</returns>
        public async Task<IEnumerable<string>> GetFile()
        {
            return await Task.Run(() => 
                Directory.GetFiles(FileSystem.AppDataDirectory)
                .Select(Path.GetFileName)
                .Where(name => name?.EndsWith(".json") ?? false)
                .OfType<string>());
        }

        /// <summary>
        /// Time of modification querry
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>Last modification's date</returns>
        public async Task<DateTime> GetModifiedTime(string name)
        {
            FileInfo info = new(Path.Combine(FileSystem.AppDataDirectory, name));

            return await Task.Run(() => info.LastAccessTime);
        }
    }
}
