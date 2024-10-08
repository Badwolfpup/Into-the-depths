﻿using Into_the_depths.Classes;
using Into_the_depths.Monster;
using Into_the_depths.Rooms;
using Into_the_depths.Rooms.Events;
using Into_the_depths.Rooms.EventTypes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private bool _canGoToNextRoom = true;

        private bool _inCombat = true;

        private Character _clickedcharacter;

        private Border? _clickedBorder = null;

        private Character _currentCharacter;

        private BaseMonster _currentMonster;

        private BaseEvent _currentEvent;

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

        public Labyrinth Minimap { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Minimap = new Labyrinth();

            CurrentRoom = Minimap.CurrentRoom();
            
            //CharacterCreationPage();
            StartPagePage();
            if (CharacterList != null) _currentCharacter = CharacterList[0];
            _currentEvent = _currentRoom.EventList[0];
            _currentMonster = (_currentEvent as Enemy).selectedMonster;
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
            if ((e.Key == System.Windows.Input.Key.Up || e.Key == System.Windows.Input.Key.Down || e.Key == System.Windows.Input.Key.Left || e.Key == System.Windows.Input.Key.Right) && _canGoToNextRoom && !_inCombat)
            {
                if (e.Key == Key.Up)
                {
                    if (Minimap.CurrentY > 0)
                    {
                        if (Minimap.Map[Minimap.CurrentX][Minimap.CurrentY - 1] == true)
                        {
                            Minimap.CurrentY--;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY].Fill = Brushes.LightGreen;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY + 1].Fill = Brushes.LightSkyBlue;
                            CurrentRoom = Minimap.CurrentRoom();
                        }
                        else Minimap.List[Minimap.CurrentX][Minimap.CurrentY - 1].Fill = Brushes.LightGray;
                    }
                }
                else if (e.Key == Key.Down)
                {
                    if (Minimap.CurrentY < Minimap.Map.Count - 1)
                    {
                        if (Minimap.Map[Minimap.CurrentX][Minimap.CurrentY + 1] == true)
                        {
                            Minimap.CurrentY++;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY].Fill = Brushes.LightGreen;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY - 1].Fill = Brushes.LightSkyBlue;
                            CurrentRoom = Minimap.CurrentRoom();
                        }
                        else Minimap.List[Minimap.CurrentX][Minimap.CurrentY + 1].Fill = Brushes.LightGray;
                    }
                }
                else if ((e.Key == Key.Left))
                {
                    if (Minimap.CurrentX > 0)
                    {
                        if (Minimap.Map[Minimap.CurrentX - 1][Minimap.CurrentY] == true)
                        {
                            Minimap.CurrentX--;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY].Fill = Brushes.LightGreen;
                            Minimap.List[Minimap.CurrentX + 1][Minimap.CurrentY].Fill = Brushes.LightSkyBlue;
                            CurrentRoom = Minimap.CurrentRoom();
                        }
                        else Minimap.List[Minimap.CurrentX - 1][Minimap.CurrentY].Fill = Brushes.LightGray;
                    }
                }
                else if ((e.Key == Key.Right))
                {
                    if (Minimap.CurrentX < Minimap.Map.Count - 1)
                    {
                        if (Minimap.Map[Minimap.CurrentX + 1][Minimap.CurrentY] == true)
                        {
                            Minimap.CurrentX++;
                            Minimap.List[Minimap.CurrentX][Minimap.CurrentY].Fill = Brushes.LightGreen;
                            Minimap.List[Minimap.CurrentX - 1][Minimap.CurrentY].Fill = Brushes.LightSkyBlue;
                            CurrentRoom = Minimap.CurrentRoom();
                        }
                        else Minimap.List[Minimap.CurrentX + 1][Minimap.CurrentY].Fill = Brushes.LightGray;
                    }
                }

            } 
            else if (e.Key == System.Windows.Input.Key.D1 || e.Key == System.Windows.Input.Key.NumPad1 && _inCombat)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D2 || e.Key == System.Windows.Input.Key.NumPad2 && _inCombat)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D3 || e.Key == System.Windows.Input.Key.NumPad3 && _inCombat)
            {

            }
            else if (e.Key == System.Windows.Input.Key.D4 || e.Key == System.Windows.Input.Key.NumPad4 && _inCombat)
            {

            }
        }
    }
}
