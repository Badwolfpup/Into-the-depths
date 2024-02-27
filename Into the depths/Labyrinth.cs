using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Into_the_depths
{
    public class Labyrinth : INotifyPropertyChanged
    {
        public int CurrentX, CurrentY;
        private int _counter;
        private bool[,]? _haveChecked;
        //public int y;
        public int numberX { get; set; } = 8;
        public int numberY { get; set; } = 8;

        public ObservableCollection<ObservableCollection<bool>> Map;
        public ObservableCollection<ObservableCollection<FillColor>> List { get; set; }

        public ObservableCollection<ObservableCollection<Rooms.Room>> RoomsList { get; set; }
        public Labyrinth()
        {
            List = new ObservableCollection<ObservableCollection<FillColor>>();
            Map = new ObservableCollection<ObservableCollection<bool>>();
            RoomsList = new ObservableCollection<ObservableCollection<Rooms.Room>>();
            while (!makeLab()) ;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool makeLab()
        {
            _haveChecked = new bool[numberX, numberY];
            _counter = 0;
            if (List != null) { List.Clear(); }
            if (Map != null) { Map.Clear(); }
            if (RoomsList !=null) { RoomsList.Clear(); }
            Random r = new Random();
            for (int i = 0; i < numberX; i++)
            {
                List.Add(new ObservableCollection<FillColor>());
                Map.Add(new ObservableCollection<bool>());
                RoomsList.Add(new ObservableCollection<Rooms.Room>());
                for (int j = 0; j < numberY; j++)
                {
                    if (r.Next(100) < 50)
                    {
                        Map[i].Add(true);
                        List[i].Add(new FillColor(Brushes.Black));
                        RoomsList[i].Add(new Rooms.Room());
                    }
                    else
                    {
                        Map[i].Add(false);
                        List[i].Add(new FillColor(Brushes.Black));
                        RoomsList[i].Add(new Rooms.Room());
                    }
                }
            }
            while (!StartingPoint()) { }


            if (RekursivMetod(CurrentX, CurrentY) > 15)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        private bool StartingPoint()
        {
            Random r = new Random();
            CurrentX = r.Next(numberX);
            CurrentY = r.Next(numberY);
            if (Map[CurrentX][CurrentY] == true)
            {
                List[CurrentX][CurrentY].Fill = Brushes.LightGreen;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rooms.Room CurrentRoom()
        {
            return RoomsList[CurrentX][CurrentY];
        }

        public class FillColor : INotifyPropertyChanged
        {
            private SolidColorBrush _fill;
            public SolidColorBrush Fill
            {
                get { return _fill; }
                set
                {
                    if (value != _fill)
                    {
                        _fill = value;
                        OnPropertyChanged(nameof(Fill));
                    }
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public FillColor(SolidColorBrush fill)
            {
                Fill = fill;
            }
        }

         private int RekursivMetod(int x, int y)
        {
            int RecursiveX = x;
            int RecursiveY = y;
            if (RecursiveX > 0 && Map[RecursiveX - 1][RecursiveY] == true && _haveChecked[RecursiveX - 1, RecursiveY] == false)
            {
                _counter++;
                _haveChecked[RecursiveX - 1, RecursiveY] = true;
                _counter = RekursivMetod(RecursiveX - 1, RecursiveY);
            }
            if (RecursiveY > 0 && Map[RecursiveX][RecursiveY - 1] == true && _haveChecked[RecursiveX, RecursiveY - 1] == false)
            {
                _counter++;
                _haveChecked[RecursiveX, RecursiveY - 1] = true;
                _counter = RekursivMetod(RecursiveX, RecursiveY - 1);
            }
            if (RecursiveX < numberX - 1 && Map[RecursiveX + 1][RecursiveY] == true && _haveChecked[RecursiveX + 1, RecursiveY] == false)
            {
                _counter++;
                _haveChecked[RecursiveX + 1, RecursiveY] = true;
                _counter = RekursivMetod(RecursiveX + 1, RecursiveY);
            }
            if (RecursiveY <numberY - 1 && Map[RecursiveX][RecursiveY + 1] == true && _haveChecked[RecursiveX, RecursiveY + 1] == false)
            {
                _counter++;
                _haveChecked[RecursiveX, RecursiveY + 1] = true;
                _counter = RekursivMetod(RecursiveX, RecursiveY + 1);
            }

            return _counter;
        }
    }
}

