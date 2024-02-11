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

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Character> characterList  { get; set; }
        private int unassignedPoints = 12;
        private int strength = 12;
        private int agility = 12;
        private int intellect = 12;
        private int spirit = 12;
        private int stamina = 12;
        public int Strength
        {
            get { return strength; }
            set
            {
                if (strength != value)
                {
                    strength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        public int Agility
        {
            get { return agility; }
            set
            {
                if (agility != value)
                {
                    agility = value;
                    OnPropertyChanged(nameof(Agility));
                }
            }
        }
        public int Intellect
        {
            get { return intellect; }
            set
            {
                if (intellect != value)
                {
                    intellect = value;
                    OnPropertyChanged(nameof(Intellect));
                }
            }
        }
        public int Spirit
        {
            get { return spirit; }
            set
            {
                if (spirit != value)
                {
                    spirit = value;
                    OnPropertyChanged(nameof(Spirit));
                }
            }
        }
        public int Stamina
        {
            get { return stamina; }
            set
            {
                if (stamina != value)
                {
                    stamina = value;
                    OnPropertyChanged(nameof(Stamina));
                }
            }
        }

        int selectedChar;
        public int UnassignedPoints
        {
            get { return unassignedPoints; }
            set
            {
                if (unassignedPoints != value)
                {
                    unassignedPoints = value;
                    OnPropertyChanged(nameof(UnassignedPoints));
                }
            }
        }

        public ICommand ChangeStat { get; set; }

        private Border? _previouslyclickedBorder = null;

        private string _classIsChecked = "Paladin";

        private readonly MainWindow parentWindow;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CharacterCreation(MainWindow w)
        {
            InitializeComponent();
            DataContext = this;
            parentWindow = w;
            characterList = new ObservableCollection<Character>();
            ChangeStat = new RelayCommand(IncrementOrDecrement);
        }

        #region changestats
        private void StrPlus_Click(object sender, RoutedEventArgs e)
        {

            //if (Strength < 20 && UnassignedPoints != 0)
            //{
            //    Strength++;
            //    UnassignedPoints--;
            //}
        }

        private void StrMinus_Click(object sender, RoutedEventArgs e)
        {
            //if (Strength > 0)
            //{
            //    Strength--;
            //    UnassignedPoints++;
            //}
        }

        private void AgiPlus_Click(object sender, RoutedEventArgs e)
        {

            //if (Agility < 20 && UnassignedPoints != 0)
            //{
            //    Agility++;
            //    UnassignedPoints--;
            //}
        }

        private void AgiMinus_Click(object sender, RoutedEventArgs e)
        {
            //if (Agility > 0)
            //{
            //    Agility--;
            //    UnassignedPoints++;
            //}
        }

        private void IntPlus_Click(object sender, RoutedEventArgs e)
        {
            //if (Intellect < 20 && UnassignedPoints != 0)
            //{
            //    Intellect++;
            //    UnassignedPoints--;
            //}
        }
        private void IntMinus_Click(object sender, RoutedEventArgs e)
        {
            //if (Intellect > 0)
            //{
            //    Intellect--;
            //    UnassignedPoints++;

            //}
        }
        private void SpiPlus_Click(object sender, RoutedEventArgs e)
        {
            //if (Spirit < 20 && UnassignedPoints != 0)
            //{
            //    Spirit++;
            //    UnassignedPoints--;
            //}
        }
        private void SpiMinus_Click(object sender, RoutedEventArgs e)
        {
            //if (Spirit < 20)
            //{
            //    Spirit--;
            //    UnassignedPoints++;
            //}
        }
        private void StaPlus_Click(object sender, RoutedEventArgs e)
        {
            //if (Stamina < 20 && UnassignedPoints != 0)
            //{
            //    Stamina++;
            //    UnassignedPoints--;
            //}
        }

        private void StaMinus_Click(object sender, RoutedEventArgs e)
        {
            //if (Stamina < 20)
            //{
            //    Stamina--;
            //    UnassignedPoints++;
            //}
        }
        #endregion

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
                    Strength--;
                    p.SetValue(this, tempStat, null);
                    UnassignedPoints++;
                }
            }
        }
        //private void addCharToPartyGrid()
        //{
        //    borderChar1.BorderBrush = Brushes.Coral;
        //    borderChar2.BorderBrush = Brushes.Coral;
        //    borderChar3.BorderBrush = Brushes.Coral;
        //    borderChar4.BorderBrush = Brushes.Coral;
        //    borderChar1.Visibility = Visibility.Hidden;
        //    borderChar2.Visibility = Visibility.Hidden;
        //    borderChar3.Visibility = Visibility.Hidden;
        //    borderChar4.Visibility = Visibility.Hidden;
        //    string classname;
        //    PartyGrid.Children.Clear();
        //    string iconSource;
        //    int y = 1;
        //    foreach (var p in characterList)
        //    {
        //        if (p is Paladin)
        //        {
        //            var x = (Paladin)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/paladin%20ikon.jpg";
        //        }
        //        else if (p is Warrior)
        //        {
        //            var x = (Warrior)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/warrior%20ikon.jpg";
        //        }
        //        else if (p is Rogue)
        //        {
        //            var x = (Rogue)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/rogue%20ikon.jpg";
        //        }
        //        else if (p is Ranger)
        //        {
        //            var x = (Ranger)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/ranger%20ikon.jpg";
        //        }
        //        else if (p is Mage)
        //        {
        //            var x = (Mage)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/mage%20ikon.jpg";
        //        }
        //        else
        //        {
        //            var x = (Priest)p;
        //            classname = x.ClassName;
        //            iconSource = "pack://application:,,,/Into the depths;component/Image/Icon/priest%20ikon.jpg";
        //        }


        //        switch (y)
        //        {
        //            case 1:
        //                {
        //                    char1Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
        //                        $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
        //                    borderChar1.Visibility = Visibility.Visible;
        //                    ikon1.Source = new BitmapImage(new Uri(iconSource));
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    char2Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
        //                        $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
        //                    borderChar2.Visibility = Visibility.Visible;
        //                    ikon2.Source = new BitmapImage(new Uri(iconSource));
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    char3Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
        //                        $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
        //                    borderChar3.Visibility = Visibility.Visible;
        //                    ikon3.Source = new BitmapImage(new Uri(iconSource));
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    char4Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
        //                        $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
        //                    borderChar4.Visibility = Visibility.Visible;
        //                    ikon4.Source = new BitmapImage(new Uri(iconSource));
        //                    break;
        //                }
        //            default: break;
        //        }
        //        y++;

        //    }
        //    CharName.Clear();
        //    Strength = 12;
        //    Agility = 12;
        //    Intellect = 12;
        //    Spirit = 12;
        //    Stamina = 12;
        //    UnassignedPoints = 12;
        //}

        
        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (CharName.Text != "")
            {
                if (characterList.Count < 4)
                {
                    Type type = Type.GetType("Into_the_depths.Classes." + _classIsChecked); 
                    if (type != null)
                    {
                        var p = (Character)Activator.CreateInstance(type, CharName.Text, Strength, Agility, Intellect, Spirit, Stamina, 100, 100, 0, 100, 100);
                        characterList.Add(p);
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
                characterList.Remove(c);
            }
            else MessageBox.Show("You need to select a character before you can delete it");
        }

        private void createParty_Click(object sender, RoutedEventArgs e)
        {
            if (characterList.Count > 3)
            {
                SaveParty.SaveToFile(characterList);
                parentWindow.ClosePage(characterList);
                //characterList.Clear();
                //characterList = SaveParty.LoadFromFile();
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
