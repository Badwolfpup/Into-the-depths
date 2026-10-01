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
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    [ObservableObject]
    public partial class CharacterCreation : Page
    {
        [ObservableProperty]
        private ObservableCollection<Character> _characterList;
        [ObservableProperty]
        private int _unassignedPoints = 12;
        [ObservableProperty]
        private int _strength = 12;
        [ObservableProperty]
        private int _agility = 12;
        [ObservableProperty]
        private int _intellect = 12;
        [ObservableProperty]
        private int _spirit = 12;
        [ObservableProperty]
        private int stamina = 12;
        [ObservableProperty]
        private Dictionary<string, int> _statDictionary;
        

        int selectedChar;
       

        public ICommand ChangeStat { get; set; }

        private Border? _previouslyclickedBorder = null;

        private string _classIsChecked = "Paladin";

        private string _saveID;

        private readonly MainWindow parentWindow;




        public CharacterCreation(MainWindow w)
        {
            InitializeComponent();
            DataContext = this;
            parentWindow = w;
            _saveID = GenerateSaveID();
            CharacterList = new ObservableCollection<Character>();
            ChangeStat = new RelayCommand(IncrementOrDecrement);
            StatDictionary = new Dictionary<string, int>
            {
                { "Strength", 12 },
                { "Agility", 12 },
                { "Intellect", 12 },
                { "Spirit", 12 },
                { "Stamina", 12 }
            };
        }


        private void IncrementOrDecrement(object parameter)
        {
            if (parameter is string[] param)
            {

                string stat = param[0];
                bool IncOrDec = bool.Parse(param[1]);
                int tempStat;
                
                Type type = this.GetType();
                PropertyInfo p = type.GetProperty(stat);
                tempStat = (int)p.GetValue(this);
                
                if(IncOrDec)
                {
                    if (tempStat < 20 && UnassignedPoints != 0) 
                    {
                        tempStat++;
                        p.SetValue(this, tempStat, null);
                        UnassignedPoints--;
                    }
                } 
                else
                {
                    tempStat--;
                    p.SetValue(this, tempStat, null);
                    UnassignedPoints++;
                }
            }
        }

        private string GenerateSaveID()
        {
            string x = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                x += r.Next(10).ToString();
            }
            return x;
        }

        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (CharName.Text != "")
            {
                if (CharacterList.Count < 4)
                {
                    Type type = Type.GetType("Into_the_depths.Classes." + _classIsChecked); 
                    if (type != null)
                    {
                        var p = (Character)Activator.CreateInstance(type, CharName.Text, Strength, Agility, Intellect, Spirit, Stamina, 100, 100, 0, 100, 100, _saveID);
                        CharacterList.Add(p);
                        CharName.Text = "";
                        Strength = 12; Agility = 12; Intellect = 12; Spirit = 12; Stamina = 12; UnassignedPoints = 12;
                    }

                    
                }
                else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
            }
            else MessageBox.Show("You need to give the character a name first");
        }

        private void Class_checked(object sender, RoutedEventArgs e) 
        { 
            RadioButton r = (RadioButton)sender;
            _classIsChecked = r.Content.ToString();
        }

        private void deleteChar_Click(object sender, RoutedEventArgs e)
        {
            if (_previouslyclickedBorder != null)
            {
                Character c = _previouslyclickedBorder.DataContext as Character;
                CharacterList.Remove(c);
            }
            else MessageBox.Show("You need to select a character before you can delete it");
        }

        private void createParty_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterList.Count > 3)
            {
                SaveParty.SaveToFile(CharacterList);
                parentWindow.ClosePage(CharacterList);
                //CharacterList.Clear();
                //CharacterList = SaveParty.LoadFromFile();
                //addCharToPartyGrid();
            }
            else MessageBox.Show("You need to add 4 characters to the party");
        }

        #region ClickOnBorder





        #endregion

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;

            if (_previouslyclickedBorder != null)
            {
                _previouslyclickedBorder.BorderBrush = Brushes.Coral;
            }

            clickedBorder.BorderBrush = Brushes.Blue;
            _previouslyclickedBorder = clickedBorder;
        }


    }
}
