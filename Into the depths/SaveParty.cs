using Into_the_depths.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Into_the_depths
{
    static class SaveParty
    {
        private static string filePath = @"C:\Users\adam_\source\repos\Badwolfpup\Into-the-depths\partylist.json";
        public static void SaveToFile(List<Character> party)
        {
            

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string savefile = JsonConvert.SerializeObject(party, settings);
            File.WriteAllText(filePath, savefile);
            //party.Clear();


        }

        public static List<Character> LoadFromFile()
        {
            List<Character> list = new List<Character>();

            if (File.Exists(filePath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                string savefile = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(savefile))
                {
                    list = JsonConvert.DeserializeObject<List<Character>>(savefile, settings);
                    return list;
                }
                else return list;
            }
            return list;
        }
    }
}
