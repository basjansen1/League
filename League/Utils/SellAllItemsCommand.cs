using League.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public class SellAllItemsCommand : ICommand
    {
        private InventoryVM _inventoryVM;

        public SellAllItemsCommand(InventoryVM inventoryVM)
        {
            _inventoryVM = inventoryVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
               return context.Ninjas.Where(n => n.Equals(_inventoryVM.SelectedNinja.ToModel())).First().Equipments.Count != 0;
            }
        }

        public void Execute(object parameter)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                var ninjaEquipments = context.Ninjas.Where(n => n.Equals(_inventoryVM.SelectedNinja.ToModel())).First().Equipments.ToList();

                foreach(Equipment e in ninjaEquipments)
                {
                    ninjaEquipments.Remove(e);
                }

                context.SaveChanges();
            }
        }
    }
}
