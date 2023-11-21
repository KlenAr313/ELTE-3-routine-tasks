using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Minefield.Persistence
{
    /// <summary>
    /// Class for saving and loading save files
    /// </summary>
    public class DataAccess
    {
        private string path;

        /// <summary>
        /// Path for the save file
        /// </summary>
        public string Path { get { return path; } set { path = value; } }

        /// <summary>
        /// Constructor with custome path
        /// </summary>
        /// <param name="path">Path for the save file</param>
        public DataAccess(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Constructor with the default paht
        /// </summary>
        public DataAccess() 
        {
            this.path = "./save.json";
        }

        /// <summary>
        /// Loading game data from save file
        /// </summary>
        /// <returns>Game data to build model</returns>
        public virtual GameData Load()
        {
            try
            {
                using StreamReader sr = new(path);
                string jsonData = sr.ReadToEnd();
                GameData? gameObject = JsonSerializer.Deserialize<GameData>(jsonData);
                if (gameObject == null)
                    throw new Exception();
                return gameObject;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saving game data
        /// </summary>
        /// <param name="gameObject">Data to be saved</param>
        public void Save(GameData gameObject)
        {
            try
            {
                using StreamWriter sw = new(path);
                string jsonData = JsonSerializer.Serialize<GameData>(gameObject);
                sw.Write(jsonData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
