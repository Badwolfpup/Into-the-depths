using Into_the_depths.Classes;
using Into_the_depths.Items;
using Into_the_depths.Items.Equipment;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace Into_the_depths.Classes
{
    public class Character : INotifyPropertyChanged
    {
        #region private properties
        private string _charactername;
        private int _strength;
        private int _agility;
        private int _intellect;
        private int _spirit;
        private int _stamina;
        private int _maxhp;
        private int _currenthp;
        private int _maxmp;
        private int _currentmp;
        private int _xp;
        private int _level;
        private int _armor;
        private int _magicdefense;
        private ObservableCollection<BaseItem> _baseequipment;
        #endregion

        #region public properties
        public string CharacterName
        {
            get { return _charactername; }
            set
            {
                if (_charactername != value)
                {
                    _charactername = value;
                    OnPropertyChanged(nameof(CharacterName));
                }
            }
        }
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (_agility != value)
                {
                    _agility = value;
                    OnPropertyChanged(nameof(Agility));
                }
            }
        }
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if (_intellect != value)
                {
                    _intellect = value;
                    OnPropertyChanged(nameof(Intellect));
                }
            }
        }
        public int Spirit
        {
            get { return _spirit; }
            set
            {
                if (_spirit != value)
                {
                    _spirit = value;
                    OnPropertyChanged(nameof(Spirit));
                }
            }
        }
        public int Stamina
        {
            get { return _stamina; }
            set
            {
                if (_stamina != value)
                {
                    _stamina = value;
                    OnPropertyChanged(nameof(Stamina));
                }
            }
        }
        public int MaxHP
        {
            get { return _maxhp; }
            set
            {
                if (_maxhp != value)
                {
                    _maxhp = value;
                    OnPropertyChanged(nameof(MaxHP));
                }
            }
        }

        public int CurrentHP
        {
            get { return _currenthp; }
            set
            {
                if (_currenthp != value)
                {
                    _currenthp = value;
                    OnPropertyChanged(nameof(_currenthp));
                }
            }
        }
        public int MaxMP
        {
            get { return _maxmp; }
            set
            {
                if (_maxmp != value)
                {
                    _maxmp = value;
                    OnPropertyChanged(nameof(MaxMP));
                }
            }
        }

        public int CurrentMP
        {
            get { return _currentmp; }
            set
            {
                if (_currentmp != value)
                {
                    _currentmp = value;
                    OnPropertyChanged(nameof(CurrentMP));
                }
            }
        }
        public int XP
        {
            get { return _xp; }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    OnPropertyChanged(nameof(XP));
                }
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }

        public int Armor
        {
            get { return _armor; }
            set
            {
                if (_armor != value)
                {
                    _armor = value;
                    OnPropertyChanged(nameof(Armor));
                }
            }
        }
        public int MagicDefense
        {
            get { return _magicdefense; }
            set
            {
                if (_magicdefense != value)
                {
                    _magicdefense = value;
                    OnPropertyChanged(nameof(MagicDefense));
                }
            }
        }
     
        public ObservableCollection<BaseItem> Equipment
        {
            get { return _baseequipment; } 
            set
            {
                if (_baseequipment != value)
                {
                    _baseequipment = value;
                    OnPropertyChanged(nameof(Equipment));
                }
            }
        }
        #endregion

        public string saveID { get; set; }

        public Character(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
        {
            CharacterName = charactername;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            MaxHP = hp;
            CurrentHP = hp;
            MaxMP = mp;
            CurrentMP = mp;
            XP = xp;
            Armor = armor;
            MagicDefense = magicdefense;
            Level = 1;
            StartingEquipment();
            saveID = saveid;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void StartingEquipment()
        {
            Equipment = new ObservableCollection<BaseItem>
            {
                new Head("Basic head", 2, 2, 2, 2, 2, 10, 10),
                new Neck("Basic neck", 2, 2, 2, 2, 2, 10, 10),
                new Shoulder("Basic shoulder", 2, 2, 2, 2, 2, 10, 10),
                new Chest("Basic chest", 2, 2, 2, 2, 2, 10, 10),
                new Arm("Basic arm", 2, 2, 2, 2, 2, 10, 10),
                new Hand("Basic hand", 2, 2, 2, 2, 2, 10, 10),
                new Legs("Basic legs", 2, 2, 2, 2, 2, 10, 10),
                new Feet("Basic feet", 2, 2, 2, 2, 2, 10, 10),
                new MainHand("Basic Main hand", 2, 2, 2, 2, 2, 10, 10),
                new OffHand("Basic off-hand", 2, 2, 2, 2, 2, 10, 10)
            };
            AddStatsFromStartingEquipment();
        }

        private void AddStatsFromStartingEquipment()
        {
            PropertyInfo p;
            foreach (var item in Equipment)
            {
                Type type = item.GetType();
                p = type.GetProperty("Strength");
                //p = item.GetType().GetProperty("Strength");
                Strength += (int)p.GetValue(item);

                p = item.GetType().GetProperty("Agility");
                Agility += (int)p.GetValue(item);

                p = item.GetType().GetProperty("Intellect");
                Intellect += (int)p.GetValue(item);

                p = item.GetType().GetProperty("Spirit");
                Spirit += (int)p.GetValue(item);

                p = item.GetType().GetProperty("Stamina");
                Stamina += (int)p.GetValue(item);

                p = item.GetType().GetProperty("Armor");
                Armor += (int)p.GetValue(item);

                p = item.GetType().GetProperty("MagicDefense");
                MagicDefense += (int)p.GetValue(item);
            }            
        }

        private void ChangeEquipment(BaseItem newItem)
        {
            foreach (var oldItem in Equipment)
            {
                if (newItem.GetType().Equals(oldItem.GetType()))
                {
                    PropertyInfo[] pNewItem = newItem.GetType().GetProperties();
                    PropertyInfo[] pOldItem = oldItem.GetType().GetProperties();
                    PropertyInfo[] pClass = typeof(Character).GetProperties();
                    int x = Equipment.IndexOf(oldItem);
                    Equipment.Remove(oldItem);
                    Equipment.Insert(x, newItem);
                    foreach (var newProperty in pNewItem)
                    {
                        foreach(var oldProperty in pOldItem)
                        {
                            if (newProperty.Name == oldProperty.Name)
                            {
                                foreach (var classProperty in pClass)
                                {
                                    if (classProperty.Name == newProperty.Name)
                                    {
                                        int newValue = (int)classProperty.GetValue(this) + (int)newProperty.GetValue(newItem, null) - (int)oldProperty.GetValue(oldItem, null);
                                        classProperty.SetValue(this, newValue);
                                    }
                                }                              
                            }
                        }   
                    }
                }
            }
        }
    }
}
