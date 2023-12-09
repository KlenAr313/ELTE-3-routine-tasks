using Minefield.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class StoredGameBrowserModel
    {
        private readonly IStore store;

        public List<StoredGameModel> StoredGames { get; private set; }

        public event EventHandler? StoreChanged;

        public StoredGameBrowserModel(IStore store)
        {
            this.store = store;

            StoredGames = new List<StoredGameModel>();
        }

        public async Task Update()
        {
            if(store == null) return;

            StoredGames.Clear();

            foreach (var name in await store.GetFile())
            {
                if (name == "Sus") continue;

                StoredGames.Add(new StoredGameModel(name, await store.GetModifiedTime(name)));
            }

            StoredGames = StoredGames.OrderByDescending(i => i.Modified).ToList();
        
            StoreChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
