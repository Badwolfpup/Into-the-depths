using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Into_the_depths.Items
{
    public class BaseEquipment : BaseItem
    {
        public string ItemName { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Spirit { get; set; }
        public int Stamina { get; set; }
        public int Armor { get; set; }
        public int MagicDefense { get; set; }

        public BaseEquipment(string name, int str, int agi, int inte, int spi, int sta, int armor, int magicdefense)
        {
            ItemName = name;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            Armor = armor;
            MagicDefense = magicdefense;
        }

        public static BaseEquipment GenerateEquipment()
        {
            BaseEquipment selectedEquipment = null;
            string[]? classFiles;
            string folderName = @"..\..\..\Items\Equipment\";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName));
            if (Directory.Exists(folderPath))
            {
                classFiles = Directory.GetFiles(folderPath, "*.cs");

                if (classFiles.Length != 0)
                {
                    Random r = new Random();
                    string randomizedClass = classFiles[r.Next(classFiles.Length)];
                    string className = Path.GetFileNameWithoutExtension(randomizedClass);
                    Type type = Type.GetType("Into_the_depths.Items.Equipment." + className);
                    if (type != null)
                    {
                        selectedEquipment = (BaseEquipment)Activator.CreateInstance(type, EquipmentName(className), r.Next(8, 19), r.Next(8, 19), r.Next(8, 19), r.Next(8, 19), r.Next(8, 19), r.Next(70, 130), r.Next(70, 130));
                    }
                }
            }
            return selectedEquipment;
        }

        private static string EquipmentName(string name)
        {
            string[] prefix = { "Wooden", "Stone", "Copper", "Bronze", "Iron", "Silver", "Gold" };
            string[] suffix;

            Random r = new Random();
            return $"{name} {prefix[r.Next(prefix.Length)]}";
        }
    }
}
