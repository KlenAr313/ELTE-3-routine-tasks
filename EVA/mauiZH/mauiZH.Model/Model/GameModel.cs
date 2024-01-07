using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mauiZH.Model.Persistence;

namespace mauiZH.Model.Model
{
    public class GameModel
    {
        private IDataAccess dataAccess;
        private int[,] table;
        private int gameStepCount;

        private int x;
        private int y;

        public event EventHandler<FieldEventArgs>? FieldChanged;

        public event EventHandler<CreatedEventArgs>? GameCreated;

        public GameModel(int x, int y, IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            this.x = x;
            this.y = y;
            table = new int[x, y];
            gameStepCount = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    table[i, j] = 0;
                }
            }
        }

        public void NewGame(int x, int y)
        {
            this.x = x;
            this.y = y;
            table = new int[x, y];
            gameStepCount = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    table[i, j] = 0;
                }
            }

            OnGameCreated();
        }

        public void Step(int x, int y)
        {
            int num = ++table[x, y];
            gameStepCount++;

            FieldChanged?.Invoke(this, new FieldEventArgs(gameStepCount, x, y, num));
        }

        public void LoadGame(string path)
        {
            if(dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            GameData gameData = dataAccess.Load(path);
            int it = 0;
            table = new int[gameData.X, gameData.Y];
            for (int i = 0; i < gameData.X; i++)
            {
                for(int j = 0; j < gameData.Y; j++)
                {
                    table[i, j] = gameData.Table[it];
                    it++;
                }
            }
            gameStepCount = gameData.GameStepCount;
            x = gameData.X;
            y = gameData.Y;

            OnGameCreated();
        }

        public void SaveGame(string path)
        {
            if(dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            dataAccess.Save(path, new GameData(table, gameStepCount, x, y));
        }

        private void OnGameCreated()
        {
            GameCreated?.Invoke(this, new CreatedEventArgs(gameStepCount, x, y, table));
        }
    }
}
