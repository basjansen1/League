using GalaSoft.MvvmLight;
using League.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    public class EquipmentVM : ViewModelBase
    {
        // Properties
        public int Id
        {
            get
            {
                return _equipment.Id;
            }
            set
            {
                _equipment.Id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return _equipment.Name;
            }
            set
            {
                _equipment.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int Strength
        {
            get
            {
                return _equipment.Strength;
            }
            set
            {
                _equipment.Strength = value;
                RaisePropertyChanged("Strength");
            }
        }

        public int Intelligence
        {
            get
            {
                return _equipment.Intelligence;
            }
            set
            {
                _equipment.Intelligence = value;
                RaisePropertyChanged("Intelligence");
            }
        }

        public int Agility
        {
            get
            {
                return _equipment.Agility;
            }
            set
            {
                _equipment.Agility = value;
                RaisePropertyChanged("Agility");
            }
        }

        public int Price
        {
            get
            {
                return _equipment.Price;
            }
            set
            {
                _equipment.Price = value;
                RaisePropertyChanged("Price");
            }
        }

        public Equipment ToModel()
        {
            return _equipment;
        }

        // Fields
        private Equipment _equipment;

        // Constructors
        public EquipmentVM()
        {
            _equipment = new Equipment();
        }

        public EquipmentVM(Equipment equipment)
        {
            _equipment = equipment;
        }

        public bool SetCategory(string name)
        {
            Category category = new Category();
            category.Name = name;

            using (var context = new LeagueNinjasDBEntities())
            {
                if (context.Categories.Contains(category))
                {
                 //   _equipment.
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}
