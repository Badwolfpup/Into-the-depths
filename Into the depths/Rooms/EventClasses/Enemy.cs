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

namespace Into_the_depths.Rooms.EventTypes
{
    public class Enemy : BaseEvent, INotifyPropertyChanged
    {
        private string _attackText;
        public BaseMonster selectedMonster { get; set; }

        public string EventText
        {
            get { return _attackText; }
            set
            {
                if (_attackText != value)
                {
                    _attackText = value;
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
            string folderPath = @"C:\Users\adam_\source\repos\Badwolfpup\Into-the-depths\Into the depths\MonsterClasses\Monster";
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
    }
}
