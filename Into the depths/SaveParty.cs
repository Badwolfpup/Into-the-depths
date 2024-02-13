using Into_the_depths.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace Into_the_depths
{
    static class SaveParty
    {
        private static string folderName = @"..\..\..\Savefiles\";
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName));
        //private static string folderPath = @"C:\Users\adam_\source\repos\Badwolfpup\Into-the-depths\Into the depths\Savefiles\";

        private static ObservableCollection<ObservableCollection<Character>> list = new ObservableCollection<ObservableCollection<Character>>();

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

        public static ObservableCollection<ObservableCollection<Character>> LoadFromFile()
        {
            

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
                        ObservableCollection<Character> c = JsonConvert.DeserializeObject<ObservableCollection<Character>>(savefile, settings);
                        list.Add(c);

                    }

                }
            }
            return list;
        }

        public static void DeleteSaveFile(string saveid)
        {
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
                        ObservableCollection<Character> c = JsonConvert.DeserializeObject<ObservableCollection<Character>>(savefile, settings);
                        if (c[0].saveID == saveid) 
                        { 
                            File.Delete(filePath);
                            return;
                        }

                    }
                    
                }
            }
        }
    }
}
