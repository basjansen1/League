using League.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _inventoryVM.SelectedNinja.ToModel().Equipments.Count() != 0;
        }

        public void Execute(object parameter)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Attach(_inventoryVM.SelectedNinja.ToModel());
                _inventoryVM.SelectedNinja.ToModel().Equipments.ToList().ForEach(e => _inventoryVM.SelectedNinja.AmountOfGold += e.Price);
                context.Ninjas.Find(_inventoryVM.SelectedNinja.Id).Equipments.Clear();
                context.Entry(_inventoryVM.SelectedNinja.ToModel()).State = EntityState.Modified;
                context.SaveChanges();
            }
            _inventoryVM.UpdateNinjaEquipmentsCollection();
        }
    }
}
