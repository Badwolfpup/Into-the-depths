using Into_the_depths.Classes;
using Into_the_depths.Items;
using Into_the_depths.Items.Equipment;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Into_the_depths.Classes
{
    public partial class Character : ObservableObject
    {
        #region private properties
        [ObservableProperty]
        private string _characterName;
        [ObservableProperty]
        private int _strength;
        [ObservableProperty]
        private int _agility;
        [ObservableProperty]
        private int _intellect;
         [ObservableProperty]
        private int _spirit;
        [ObservableProperty]
        private int _stamina;
        [ObservableProperty]
        private int _maxHP;
        [ObservableProperty]
        private int _currentHP;
        [ObservableProperty]
        private int _maxMP;
        [ObservableProperty]
        private int _currentMP;
        [ObservableProperty]
        private int _xp;
        [ObservableProperty]
        private int _level;
        [ObservableProperty]
        private int _armor;
        [ObservableProperty]
        private int _magicDefense;
        [ObservableProperty]
        private ObservableCollection<BaseEquipment> _equipment;
        [ObservableProperty]
        private int _baseStrength;
        [ObservableProperty]
        private int _baseAgility;
        [ObservableProperty]
        private int _baseIntellect;
        [ObservableProperty]
        private int _baseSpirit;
        [ObservableProperty]
        private int _baseStamina;
        #endregion

 
        public string saveID { get; set; }

        public Character(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
        {
            CharacterName = charactername;
            BaseStrength = str;
            BaseAgility = agi;
            BaseIntellect = inte;
            BaseSpirit = spi;
            BaseStamina = sta;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            MaxHP = hp;
            CurrentHP = hp;
            MaxMP = mp;
            CurrentMP = mp;
            Xp = xp;
            Armor = armor;
            MagicDefense = magicdefense;
            Level = 1;
            StartingEquipment();
            saveID = saveid;
        }




        private void StartingEquipment()
        {
            Equipment = new ObservableCollection<BaseEquipment>
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
                PropertyInfo[] pItem = item.GetType().GetProperties();
                PropertyInfo[] pClass = typeof(Character).GetProperties();

                foreach (var propItem in pItem)
                {
                    foreach (var propClass in pClass) 
                    {
                        if (propItem.Name == propClass.Name)
                        {
                            int newValue = (int)propClass.GetValue(this) + (int)propItem.GetValue(item);
                            propClass.SetValue(this, newValue);
                        }                    
                    }
                }
            }            
        }

        private void ChangeEquipment(BaseEquipment newItem)
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
