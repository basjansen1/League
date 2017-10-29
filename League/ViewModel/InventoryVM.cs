using GalaSoft.MvvmLight;
using League.Model;
using League.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<EquipmentVM> NinjaEquipmentsCollection { get; set; }

        public InventoryVM(NinjaVM selectedNinja)
        {
            SelectedNinja = selectedNinja;
            SellAllItemsCommand = new SellAllItemsCommand(this);
            BuyEquipmentCommand = new BuyEquipmentCommand(this);
            SellEquipmentCommand = new SellEquipmentCommand(this);
            NinjaEquipmentsCollection = new ObservableCollection<EquipmentVM>();
        }

        public int GetTotalStrenght
        {
            get
            {
                int strength = 0;

                using (var context = new LeagueNinjasDBEntities())
                {
                    Ninja ninja = SelectedNinja.ToModel();
                    context.Ninjas.Where(n => n.Id == ninja.Id).First().Equipments.ToList().ForEach(e => strength += e.Strength);
                }
                return strength;
            }
        }

        public int GetTotalInteligence
        {
            get
            {
                int inteligence = 0;

                using (var context = new LeagueNinjasDBEntities())
                {
                    Ninja ninja = SelectedNinja.ToModel();
                    context.Ninjas.Where(n => n.Id == ninja.Id).First().Equipments.ToList().ForEach(e => inteligence += e.Intelligence);
                }
                return inteligence;
            }
        }

        public int GetTotalAgility
        {
            get
            {
                int agility = 0;

                using (var context = new LeagueNinjasDBEntities())
                {
                    Ninja ninja = SelectedNinja.ToModel();
                    context.Ninjas.Where(n => n.Id == ninja.Id).First().Equipments.ToList().ForEach(e => agility += e.Agility);
                }
                return agility;
            }
        }

        public int GetTotalWorth
        {
            get
            {
                int worth = 0;

                using (var context = new LeagueNinjasDBEntities())
                {
                    Ninja ninja = SelectedNinja.ToModel();
                    context.Ninjas.Where(n => n.Id == ninja.Id).First().Equipments.ToList().ForEach(e => worth += e.Price);
                }
                return worth;
            }
        }

        public void UpdateNinjaEquipmentsCollection()
        {
            NinjaEquipmentsCollection.Clear();
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Where(n => n.Equals(SelectedNinja.ToModel())).First().Equipments.Select(e => new EquipmentVM(e)).ToList().ForEach(e => NinjaEquipmentsCollection.Add(e));
            }
        }
        
    }
}
