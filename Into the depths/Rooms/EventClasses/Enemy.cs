using Into_the_depths.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Into_the_depths.Monster;
using Into_the_depths.Items;

namespace Into_the_depths.Rooms.EventTypes
{
    public class Enemy : BaseEvent, INotifyPropertyChanged
    {
        private string _EventText;
        public BaseMonster selectedMonster { get; set; }

        public BaseEquipment LootedEquipment { get; set; }

        public bool HasLoot { get; set; }

        public string EventText
        {
            get { return _EventText; }
            set
            {
                if (_EventText != value)
                {
                    _EventText = value;
                    OnPropertyChanged(nameof(EventText));
                }
            }
        }
        public Enemy()
        {
            SelectMonster();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void SelectMonster()
        {
            string[]? classFiles;
            string folderName = @"..\..\..\MonsterClasses\Monster\";
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
                    Type type = Type.GetType("Into_the_depths.MonsterClasses.Monster." + className);
                    if (type != null)
                    {
                        selectedMonster = (BaseMonster)Activator.CreateInstance(type, className, 12, 12, 12, 12, 12, 100, 100, 0, 100, 100, 1);
                        EventText = $"You are attacked by a {className}!";
                    }
                }
            }
        }

        private void Loot()
        {
            Random r = new Random();
            int lootchance;
            if (r.Next(100) > 50) 
            {
                LootedEquipment = BaseEquipment.GenerateEquipment();
                HasLoot = true;
            }
        }
    }
}
