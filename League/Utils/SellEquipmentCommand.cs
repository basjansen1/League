using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using League.ViewModel;
using System.Windows.Input;
using League.Model;
using System.Data.Entity;

namespace League.Utils
{
    public class SellEquipmentCommand : ICommand
    {
        private InventoryVM _inventoryVM;

        public SellEquipmentCommand(InventoryVM inventoryVM)
        {
            _inventoryVM = inventoryVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          //  EquipmentVM oldEquipmentVM = (EquipmentVM)parameter;

            using (var context = new LeagueNinjasDBEntities())
            {
                //  var ninjaEquipments = context.Ninjas.Where(n => n.Equals(_inventoryVM.SelectedNinja.ToModel())).First().Equipments.Remove(oldEquipmentVM.ToModel());
                _inventoryVM.SelectedNinja.AmountOfGold += _inventoryVM.SelectedEquipment.Price;
               _inventoryVM.SelectedNinja.ToModel().Equipments.Remove(_inventoryVM.SelectedEquipment.ToModel());
                context.Entry(_inventoryVM.SelectedNinja.ToModel()).State = EntityState.Modified;
                context.SaveChanges();
            }
            _inventoryVM.RemoveEquipmentFromCollection();
        }
    }
}
