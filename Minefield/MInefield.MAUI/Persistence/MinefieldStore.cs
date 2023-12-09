using Minefield.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInefield.MAUI.Persistence
{
    public class MinefieldStore : IStore
    {
        public async Task<IEnumerable<string>> GetFile()
        {
            return await Task.Run(() => 
                Directory.GetFiles(FileSystem.AppDataDirectory)
                .Select(Path.GetFileName)
                .Where(name => name?.EndsWith(".json") ?? false)
                .OfType<string>());
        }

        public async Task<DateTime> GetModifiedTime(string name)
        {
            FileInfo info = new(Path.Combine(FileSystem.AppDataDirectory, name));

            return await Task.Run(() => info.LastAccessTime);
        }
    }
}
