using GalaSoft.MvvmLight.Command;
using League.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace League.ViewModel
{
    public class AddNinjaVM : AddVM<NinjaListVM, NinjaVM>
    {
       public AddNinjaVM(NinjaListVM ViewModelList)
            : base(ViewModelList)
        {
            NewItem = new NinjaVM();
            VMList = ViewModelList;
            
            MessageBox.Show("New AddNinjaWindow!");
        }

        public override void AddItem()
        {
            if (CanAdd())
            {
                using (var context = new LeagueNinjasDBEntities())
                {
                    NewItem.Id = context.Ninjas.Max(i => i.Id) + 1; // Get the highest ID and increment this
                    
                    VMList.ItemList.Add(NewItem);
                    context.Ninjas.Add(NewItem.ToModel());
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                }
                VMList.HideAddWindow();
            }
        }

        public override bool CanAdd()
        {
            if (NewItem.Name != null)
                return true;
            else
            {
                MessageBox.Show("You have to give a name to the Ninja!");
                return false;
            }
        }
    }
}
