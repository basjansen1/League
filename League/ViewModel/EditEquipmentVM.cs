using League.Model;
using League.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace League.ViewModel
{
    public class EditEquipmentVM : EditVM<EquipmentVM, EditEquipmentView>
    {
        public EditEquipmentVM(EquipmentVM Item) : base(Item)
        {
        }

        public override void EditItem(EditEquipmentView window)
        {
            if (CanEdit())
            {
                using (var context = new LeagueNinjasDBEntities())
                {
                    Equipment equipment = ItemToBeEdited.ToModel();
                    context.Entry(equipment).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public override bool CanEdit()
        {
            if(ItemToBeEdited.Name != null)
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
