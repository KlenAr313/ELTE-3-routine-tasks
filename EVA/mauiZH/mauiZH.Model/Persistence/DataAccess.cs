using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mauiZH.Model.Persistence
{
    public class DataAccess : IDataAccess
    {
        private String? directory = String.Empty;

        public DataAccess(String? saveDirectory = null) 
        {
            directory = saveDirectory;
        }

        public GameData Load(string path)
        {
            if (!String.IsNullOrEmpty(directory))
                path = Path.Combine(directory, path);

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
            if (!String.IsNullOrEmpty(directory))
                path = Path.Combine(directory, path);

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
