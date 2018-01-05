using GalaSoft.MvvmLight.Command;
using League.Model;
using League.View;
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
    public class EditNinjaVM : EditVM<NinjaVM, EditNinjaView>
    {
        public EditNinjaVM(NinjaVM Item)
            : base(Item)
        {
        }

        public override void EditItem(EditNinjaView window)
        {
            if (CanEdit())
            {
                using (var context = new LeagueNinjasDBEntities())
                {
                    Ninja ninja = ItemToBeEdited.ToModel();
                    context.Entry(ninja).State = EntityState.Modified;
                    context.SaveChanges();
                }
                window.Close();
            }
        }

        public override bool CanEdit()
        {
            if (ItemToBeEdited.Name != "" && ItemToBeEdited.AmountOfGold != 0)
                return true;
            else
            {
                MessageBox.Show("Please enter all fields");
                return false;
            }
        }
    }
}
