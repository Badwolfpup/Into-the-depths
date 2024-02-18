using Into_the_depths.Classes;
using Into_the_depths.Rooms.Events;
using Into_the_depths.Rooms.EventTypes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Frame frame;

        private Rooms.Room _currentRoom;

        private Character _clickedcharacter;

        private Border? _clickedBorder = null;

        private ObservableCollection<Character> _characterlist;

        public ObservableCollection<Character> CharacterList
        {
            get { return _characterlist; }
            set
            {
                if (_characterlist != value)
                {
                    _characterlist = value;
                    OnPropertyChanged(nameof(CharacterList));
                }
            }

        }

        public Character ClickedCharacter 
        {
            get { return _clickedcharacter; }
            set
            {
                if (_clickedcharacter != value)
                {
                    _clickedcharacter = value;
                    OnPropertyChanged(nameof(ClickedCharacter));
                }
            }
        }
        public ObservableCollection<Rooms.Room> RoomsList { get; set; }
        public Rooms.Room CurrentRoom 
        { 
            get { return _currentRoom; }
            set
            {
                if (_currentRoom != value)
                {
                    _currentRoom = value;
                    OnPropertyChanged(nameof(CurrentRoom));
                }
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            RoomsList = new ObservableCollection<Rooms.Room>
            {
                new Rooms.Room()
            };
            CurrentRoom = RoomsList.Last();
            
            //CharacterCreationPage();
            StartPagePage();
            //Enemy e = new Enemy();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void CharacterCreationPage()
        {
            Content = null;
            CharacterCreation c = new CharacterCreation(this);
            Content = c;
        }

        public void ClosePage(ObservableCollection<Character> c)
        {
            
            CharacterList = c;
            ClickedCharacter = CharacterList.First();
            Content = MainGrid;
            
        }



        private void StartPagePage()
        {
            StartPage s = new StartPage(this);
            Content = s;
        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            ClickedCharacter = border.DataContext as Character;

            if (_clickedBorder != null)
            {
                _clickedBorder.BorderBrush = Brushes.Coral;
            }
            border.BorderBrush = Brushes.Blue;
            _clickedBorder = border;
        }


        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
            {
                RoomsList.Add(new Rooms.Room());
                CurrentRoom = RoomsList.Last();
            } 
            else if (e.Key == System.Windows.Input.Key.D1 || e.Key == System.Windows.Input.Key.NumPad1)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D2 || e.Key == System.Windows.Input.Key.NumPad2)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D3 || e.Key == System.Windows.Input.Key.NumPad3)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D4 || e.Key == System.Windows.Input.Key.NumPad4)
            {

            }
        }
    }
}
