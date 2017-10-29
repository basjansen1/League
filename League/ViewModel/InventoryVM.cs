using GalaSoft.MvvmLight;
using League.Model;
using League.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public class InventoryVM : ViewModelBase
    {
        public NinjaVM SelectedNinja { get; set; }
        public ICommand SellAllItemsCommand { get; set; }
        public ICommand BuyEquipmentCommand { get; set; }
        public ICommand SellEquipmentCommand { get; set; }

        public InventoryVM(NinjaVM selectedNinja)
        {
            SelectedNinja = selectedNinja;
            SellAllItemsCommand = new SellAllItemsCommand(this);
            BuyEquipmentCommand = new BuyEquipmentCommand(this);
            SellEquipmentCommand = new SellEquipmentCommand(this);
        }

        public int GetTotalStrenght()
        {
            int strength = 0;

            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Where(n => n.Equals(SelectedNinja.ToModel())).First().Equipments.ToList().ForEach(e => strength += e.Strength);
            }
            return strength;
        } 

        public int GetTotalInteligence()
        {
            int inteligence = 0;

            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Where(n => n.Equals(SelectedNinja.ToModel())).First().Equipments.ToList().ForEach(e => inteligence += e.Intelligence);
            }
            return inteligence;
        }

        public int GetTotalAgility()
        {
            int agility = 0;

            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Where(n => n.Equals(SelectedNinja.ToModel())).First().Equipments.ToList().ForEach(e => agility += e.Agility);
            }
            return agility;

        }
        
    }
}
