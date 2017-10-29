using League.Model;
using League.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.Utils
{
    public class BuyEquipmentCommand : ICommand
    {
        private InventoryVM _inventory;
        public event EventHandler CanExecuteChanged;

        public BuyEquipmentCommand(InventoryVM inventory)
        {
            _inventory = inventory;
        }

        public bool CanExecute(object parameter) // An equipmentVM object will be passed into this parameter
        {
            EquipmentVM newEquipmentVM = (EquipmentVM)parameter;

            using (var context = new LeagueNinjasDBEntities())
            {
                var ninja = context.Ninjas.Where(n => n.Equals(_inventory.SelectedNinja.ToModel())).First(); // get selected ninja 
                var equipmentsOfNinja = ninja.Equipments.Where(e => e.Category.Equals(newEquipmentVM.Category)).ToList(); // get selected ninja var equipmentsOfNinja = ninja.Select(n => n.Equipments.Where(e => e.Category.Equals(newEquipmentVM.Category))).ToList(); // get equipment of the selected ninja where the category equals the category of the newEquipment

                if (equipmentsOfNinja.Count == 0 && _inventory.SelectedNinja.AmountOfGold >= newEquipmentVM.Price)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public void Execute(object parameter)
        {
            EquipmentVM newEquipmentVM = (EquipmentVM)parameter;

            using (var context = new LeagueNinjasDBEntities())
            {
                var ninja = context.Ninjas.Where(n => n.Equals(_inventory.SelectedNinja.ToModel())).First(); // get selected ninja
                ninja.Equipments.Add(newEquipmentVM.ToModel());

                context.SaveChanges();
            }
        }
    }
}
