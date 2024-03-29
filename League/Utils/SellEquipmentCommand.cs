﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using League.ViewModel;
using System.Windows.Input;
using League.Model;
using System.Data.Entity;
using System.Windows;

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
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Attach(_inventoryVM.SelectedNinja.ToModel());
                _inventoryVM.SelectedNinja.AmountOfGold += _inventoryVM.SelectedEquipment.Price;
                Equipment equipmentToDelete = context.Equipments.Find(_inventoryVM.SelectedEquipment.Id);
               // MessageBox.Show((_inventoryVM.SelectedNinja.ToModel().Equipments.Contains(equipmentToDelete)).ToString());
                _inventoryVM.SelectedNinja.ToModel().Equipments.Remove(equipmentToDelete);
                context.Entry(_inventoryVM.SelectedNinja.ToModel()).State = EntityState.Modified;
                context.SaveChanges();
            }

            _inventoryVM.RemoveEquipmentFromCollection();
        }
    }
}
