using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using League.ViewModel;
using System.Windows.Input;
using League.Model;

namespace League.Utils
{
    public class SellEquipmentCommand : ICommand
    {
        private InventoryVM _inventoryVM;

        public SellEquipmentCommand(InventoryVM inventoryVM)
        {
            _inventoryVM = inventoryVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EquipmentVM oldEquipmentVM = (EquipmentVM)parameter;

            using (var context = new LeagueNinjasDBEntities())
            {
                var ninjaEquipments = context.Ninjas.Where(n => n.Equals(_inventoryVM.SelectedNinja.ToModel())).First().Equipments.Remove(oldEquipmentVM.ToModel());

                context.SaveChanges();
            }
        }
    }
}
