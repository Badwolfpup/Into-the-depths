using Into_the_depths.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public ObservableCollection<List<Character>> characterList { get; set; }
        public int testint { get; set; } = 10;
        public StartPage()
        {
            InitializeComponent();
            DataContext = this;
            loadSavefiles();
        }

        private void loadSavefiles()
        {
            string info;
            string classname;
            int y = 0;
            characterList = SaveParty.LoadFromFile();
            //foreach (var character in characterList)
            //{
            //    info = "";
            //    foreach (var p in character)
            //    {
            //        if (p is Paladin)
            //        {
            //            var x = (Paladin)p;
            //            classname = x.ClassName;
            //        }
            //        else if (p is Warrior)
            //        {
            //            var x = (Warrior)p;
            //            classname = x.ClassName;
            //        }
            //        else if (p is Rogue)
            //        {
            //            var x = (Rogue)p;
            //            classname = x.ClassName;
            //        }
            //        else if (p is Ranger)
            //        {
            //            var x = (Ranger)p;
            //            classname = x.ClassName;
            //        }
            //        else if (p is Mage)
            //        {
            //            var x = (Mage)p;
            //            classname = x.ClassName;
            //        }
            //        else
            //        {
            //            var x = (Priest)p;
            //            classname = x.ClassName;
            //        }
            //        info += $"Name: {p.CharacterName} Class: {classname} Str: {p.Strength} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}\n";

            //    }
            //    switch (y)
            //    {
            //        case 0:
            //            Save1.Text = info;
            //            break;
            //        case 1:
            //            Save2.Text = info;
            //            break;
            //        case 2:
            //            Save3.Text = info;
            //            break;
            //        case 3:
            //            Save4.Text = info;
            //            break;

            //    }
            //    y++;
            //}

        }
    }
}
