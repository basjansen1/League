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
        private MarketPlaceVM _marketPlace;
        public event EventHandler CanExecuteChanged;

        public BuyEquipmentCommand(MarketPlaceVM marketPlace)
        {
            _marketPlace = marketPlace;
        }

        public bool CanExecute(object parameter) // An equipmentVM object will be passed into this parameter
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                var ninja = context.Ninjas.Where(n => n.Equals(_marketPlace.NinjaList.SelectedItem.ToModel())).First(); // get selected ninja 
                var equipmentsOfNinja = ninja.Equipments.Where(e => e.Category.Equals(_marketPlace.EquipmentList.SelectedItem.Category)).First(); // get selected ninja var equipmentsOfNinja

                if (equipmentsOfNinja == null)
                {
                   if (ninja.AmountGold >= equipmentsOfNinja.Price)
                    {
                        return true;
                    } else
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
                var ninja = context.Ninjas.Where(n => n.Equals(_marketPlace.NinjaList.SelectedItem.ToModel())).First(); // get selected ninja
                ninja.Equipments.Add(_marketPlace.EquipmentList.SelectedItem.ToModel());

                context.SaveChanges();
            }
        }
    }
}
