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
        public ICommand AddNinjaCommand { get; set; }
        public string NameText { get; set; }
        public string AmountGoldText { get; set; }

        public AddNinjaVM(NinjaListVM ViewModelList)
            : base(ViewModelList)
        {
            NewItem = new NinjaVM();
            VMList = ViewModelList;

            AddNinjaCommand = new RelayCommand(AddItem);
        }

        public override void AddItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                NewItem.Id = context.Ninjas.Max(i => i.Id) + 1; // Get the highest ID and increment this
                NewItem.Name = NameText;
                // TODO CHECK IF PARSING WENT RIGHT
                NewItem.AmountOfGold = Int32.Parse(AmountGoldText);

                if (!CanAdd())
                    return;

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
