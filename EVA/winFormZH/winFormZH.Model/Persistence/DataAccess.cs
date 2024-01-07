using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace winFormZH.Model.Persistence
{
    public class DataAccess : IDataAccess
    {
        public GameData Load(string path)
        {
            try
            {
                using StreamReader sr = new(path);
                string jsonData = sr.ReadToEnd();
                GameData? gameData = JsonSerializer.Deserialize<GameData>(jsonData);
                if (gameData == null)
                    throw new Exception();
                return gameData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(string path, GameData gameData)
        {
            try
            {
                using StreamWriter sw = new(path);
                string jsonData = JsonSerializer.Serialize<GameData>(gameData);
                sw.Write(jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
