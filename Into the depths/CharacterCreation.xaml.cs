using Into_the_depths.Classes;
using Into_the_depths.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page
    {
        List<Character> characterList = new List<Character>();
        int unassignedPoints = 12;
        int selectedChar;
        private readonly MainWindow parentWindow;
        public CharacterCreation(MainWindow w)
        {
            InitializeComponent();
            unassignedText.Text = unassignedPoints.ToString();
            parentWindow = w;
        }

        #region changestats
        private void StrPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StrValue.Text, out x);
            if (x < 20 && unassignedPoints != 0)
            {
                x++;
                StrValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void StrMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StrValue.Text, out x);
            if (x > 0)
            {
                x--;
                StrValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void AgiPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(AgiValue.Text, out x);
            if (x < 20 && unassignedPoints != 0)
            {
                x++;
                AgiValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void AgiMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(AgiValue.Text, out x);
            if (x > 0)
            {
                x--;
                AgiValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }


        private void IntPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(IntValue.Text, out x);
            if (x < 20 && unassignedPoints != 0)
            {
                x++;
                IntValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }
        private void IntMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(IntValue.Text, out x);
            if (x > 0)
            {
                x--;
                IntValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }
        private void SpiPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(SpiValue.Text, out x);
            if (x < 20 && unassignedPoints != 0)
            {
                x++;
                SpiValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void SpiMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(SpiValue.Text, out x);
            if (x < 20)
            {
                x--;
                SpiValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void StaPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StaValue.Text, out x);
            if (x < 20 && unassignedPoints != 0)
            {
                x++;
                StaValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }

        private void StaMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StaValue.Text, out x);
            if (x < 20)
            {
                x--;
                StaValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = unassignedPoints.ToString();
            }
        }
        #endregion

        private void addCharToPartyGrid()
        {
            borderChar1.BorderBrush = Brushes.Coral;
            borderChar2.BorderBrush = Brushes.Coral;
            borderChar3.BorderBrush = Brushes.Coral;
            borderChar4.BorderBrush = Brushes.Coral;
            borderChar1.Visibility = Visibility.Hidden;
            borderChar2.Visibility = Visibility.Hidden;
            borderChar3.Visibility = Visibility.Hidden;
            borderChar4.Visibility = Visibility.Hidden;
            string classname;
            PartyGrid.Children.Clear();

            int y = 1;
            foreach (var p in characterList)
            {
                if (p is Paladin)
                {
                    var x = (Paladin)p;
                    classname = x.ClassName;
                }
                else if (p is Warrior)
                {
                    var x = (Warrior)p;
                    classname = x.ClassName;
                }
                else if (p is Rogue)
                {
                    var x = (Rogue)p;
                    classname = x.ClassName;
                }
                else if (p is Ranger)
                {
                    var x = (Ranger)p;
                    classname = x.ClassName;
                }
                else if (p is Mage)
                {
                    var x = (Mage)p;
                    classname = x.ClassName;
                }
                else
                {
                    var x = (Priest)p;
                    classname = x.ClassName;
                }


                switch (y)
                {
                    case 1:
                        {
                            char1Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
                                $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
                            borderChar1.Visibility = Visibility.Visible;
                            break;
                        }
                    case 2:
                        {
                            char2Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
                                $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
                            borderChar2.Visibility = Visibility.Visible;
                            break;
                        }
                    case 3:
                        {
                            char3Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
                                $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
                            borderChar3.Visibility = Visibility.Visible;
                            break;
                        }
                    case 4:
                        {
                            char4Text.Text = $"Name: {p.CharacterName}  Class: {classname} \n " +
                                $"Str: {p.Strength.ToString()} Agi: {p.Agility} Int: {p.Intellect} Spi: {p.Spirit} Sta: {p.Stamina}";
                            borderChar4.Visibility = Visibility.Visible;
                            break;
                        }
                    default: break;
                }
                y++;

            }
            CharName.Clear();
            StrValue.Text = "12";
            AgiValue.Text = "12";
            IntValue.Text = "12";
            SpiValue.Text = "12";
            StaValue.Text = "12";
            unassignedPoints = 12;
            unassignedText.Text = unassignedPoints.ToString();

        }
        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (RBPaladin.IsChecked == true)
            {
                if (CharName.Text != "" || CharName.Text.Length < 13)
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        Paladin p = new Paladin(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
            else if (RBWarrior.IsChecked == true)
            {
                if (CharName.Text != "")
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        Warrior p = new Warrior(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
            else if (RBRogue.IsChecked == true)
            {
                if (CharName.Text != "")
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Rogue(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
            else if (RBRanger.IsChecked == true)
            {
                if (CharName.Text != "")
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Ranger(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
            else if (RBMage.IsChecked == true)
            {
                if (CharName.Text != "")
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Mage(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
            else if (RBPriest.IsChecked == true)
            {
                if (CharName.Text != "")
                {
                    if (characterList.Count < 4)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Priest(CharName.Text, str, agi, inte, spi, sta, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        addCharToPartyGrid();
                    }
                    else MessageBox.Show("You have reached the maximum number of characters. You need to delete a character from your party before adding new ones");
                }
                else MessageBox.Show("You need to give the character a name first");
            }
        }



        private void deleteChar_Click(object sender, RoutedEventArgs e)
        {
            if (borderChar1.BorderBrush == Brushes.Blue)
            {
                characterList.RemoveAt(0);
                addCharToPartyGrid();
            }
            else if (borderChar2.BorderBrush == Brushes.Blue)
            {
                characterList.RemoveAt(1);
                addCharToPartyGrid();
            }
            else if (borderChar3.BorderBrush == Brushes.Blue)
            {
                characterList.RemoveAt(2);
                addCharToPartyGrid();
            }
            else if (borderChar4.BorderBrush == Brushes.Blue)
            {
                characterList.RemoveAt(3);
                addCharToPartyGrid();
            }
            else MessageBox.Show("You need to select a character before you can delete it");
        }

        private void createParty_Click(object sender, RoutedEventArgs e)
        {
            if (characterList.Count > 3)
            {
                SaveParty.SaveToFile(characterList);
                parentWindow.closeCharCreatePage();
                //characterList.Clear();
                //characterList = SaveParty.LoadFromFile();
                //addCharToPartyGrid();
            }
            else MessageBox.Show("You need to add 4 characters to the party");
        }

        #region ClickOnBorder
        private void borderChar1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderChar1.BorderBrush = Brushes.Blue;
            borderChar2.BorderBrush = Brushes.Coral;
            borderChar3.BorderBrush = Brushes.Coral;
            borderChar4.BorderBrush = Brushes.Coral;
            selectedChar = 0;
        }

        private void borderChar2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderChar2.BorderBrush = Brushes.Blue;
            borderChar1.BorderBrush = Brushes.Coral;
            borderChar3.BorderBrush = Brushes.Coral;
            borderChar4.BorderBrush = Brushes.Coral;
            selectedChar = 1;
        }

        private void borderChar3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderChar3.BorderBrush = Brushes.Blue;
            borderChar1.BorderBrush = Brushes.Coral;
            borderChar2.BorderBrush = Brushes.Coral;
            borderChar4.BorderBrush = Brushes.Coral;
            selectedChar = 2;
        }

        private void borderChar4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            borderChar4.BorderBrush = Brushes.Blue;
            borderChar1.BorderBrush = Brushes.Coral;
            borderChar2.BorderBrush = Brushes.Coral;
            borderChar3.BorderBrush = Brushes.Coral;
            selectedChar = 3;
        }
        #endregion




    }
}
