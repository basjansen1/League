using League.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace League.ViewModel
{
    public class AddEquipmentVM : AddVM<EquipmentListVM, EquipmentVM>
    {
        public AddEquipmentVM(EquipmentListVM ViewModelList) : base(ViewModelList)
        { 
            NewItem = new EquipmentVM();
            VMList = ViewModelList;
        }
        public override void AddItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                NewItem.Id = context.Equipments.Max(i => i.Id) + 1; // Get the highest ID and increment this
                VMList.ItemList.Add(NewItem);
                context.Equipments.Add(NewItem.ToModel());
                context.SaveChanges();
            }
            VMList.HideAddWindow();
        }

        public override bool CanAdd()
        {
            if (NewItem.Name != null)
            {
                return true;
            } else
            {
                MessageBox.Show("You have to give a name to the equipment!");
                return false;
            }
        }
    }
}
