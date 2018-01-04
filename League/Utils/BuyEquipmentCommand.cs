using League.Model;
using League.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace League.Utils
{
    public class BuyEquipmentCommand : ICommand
    {
        private MarketPlaceVM _marketPlace;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public BuyEquipmentCommand(MarketPlaceVM marketPlace)
        {
            _marketPlace = marketPlace;
        }

        public bool CanExecute(object parameter)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                if (_marketPlace.EquipmentList.SelectedItem != null)
                {

                    var ninja = context.Ninjas.Find(_marketPlace.NinjaList.SelectedItem.Id);
                    var equipmentsOfNinja = ninja.Equipments.Where(e => e.Category.Equals(_marketPlace.EquipmentList.SelectedItem.Category)).ToList();

                    if (equipmentsOfNinja.Count == 0)
                    {
                           if (ninja.AmountGold >= _marketPlace.EquipmentList.SelectedItem.Price)
                           {
                            ninja.AmountGold -= _marketPlace.EquipmentList.SelectedItem.Price;
                            context.SaveChanges();
                               return true;
                           } else
                           {
                                return false;
                            }
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            }
        }

        public void Execute(object parameter)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                var ninja = context.Ninjas.Where(n => n.Id == _marketPlace.NinjaList.SelectedItem.Id).First(); // get selected ninja
                var equipment = _marketPlace.EquipmentList.SelectedItem.ToModel();
                ninja.Equipments.Add(context.Equipments.Where(e => e.Id == equipment.Id).First());

                context.SaveChanges();
                _marketPlace.Inventory.AddEquipmentToCollection(equipment);
            }
        }
    }
}
