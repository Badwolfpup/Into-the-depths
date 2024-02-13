using Into_the_depths.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<ObservableCollection<Character>> characterList { get; set; }

        public ObservableCollection<Character> chosenSave { get; set; }  
        public int testint { get; set; } = 10;

        private readonly MainWindow parentWindow;

        private Border _border = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public StartPage(MainWindow w)
        {
            InitializeComponent();
            parentWindow = w;
            DataContext = this;
            loadSavefiles();
        }

        private void loadSavefiles()
        {
            string info;
            string classname;
            int y = 0;
            characterList = SaveParty.LoadFromFile();
        }

        private void newGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.CharacterCreationPage();
        }

        private void loadGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_border != null) parentWindow.ClosePage(chosenSave);
            else MessageBox.Show("You need to select a save first.");
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border b = sender as Border;

            chosenSave = b.DataContext as ObservableCollection<Character>;

            if (_border != null)
            {
                _border.BorderBrush = Brushes.Crimson;

            }
            b.BorderBrush = Brushes.Blue;
            _border = b;
        }

        private void deleteSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (chosenSave != null)
            {
                SaveParty.DeleteSaveFile(chosenSave[0].saveID);
                characterList.Remove(chosenSave);
            }
            else MessageBox.Show("You need to select a save first");
        }
    }
}
