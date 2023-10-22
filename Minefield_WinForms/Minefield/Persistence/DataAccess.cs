﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Minefield.Persistence
{
    public class DataAccess
    {
        private readonly string path;

        public DataAccess(string path)
        {
            this.path = path;
        }

        public GameData Load()
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