﻿using Into_the_depths.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Into_the_depths
{
    static class SaveParty
    {
        private static string folderPath = @"C:\Users\adam_\source\repos\Badwolfpup\Into-the-depths\Into the depths\Savefiles\";

        public static void SaveToFile(ObservableCollection<Character> party)
        {
            int numberSaves = Directory.GetFiles(folderPath).Length;
            string filePath = folderPath + "Savefile" + (numberSaves + 1).ToString() + ".json";

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string savefile = JsonConvert.SerializeObject(party, settings);
            File.WriteAllText(filePath, savefile);
            //party.Clear();


        }

        public static ObservableCollection<List<Character>> LoadFromFile()
        {
            ObservableCollection<List<Character>> list = new ObservableCollection<List<Character>>();

            if (Directory.Exists(folderPath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                foreach (string filePath in Directory.GetFiles(folderPath, "*.json"))
                {
                    string savefile = File.ReadAllText(filePath);
                    if (!string.IsNullOrEmpty(savefile))
                    {
                        List<Character> c = JsonConvert.DeserializeObject<List<Character>>(savefile, settings);
                        list.Add(c);

                    }

                }
            }
            return list;
        }
    }
}
