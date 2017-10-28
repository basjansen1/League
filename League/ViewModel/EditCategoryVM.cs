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
    public class EditCategoryVM : EditVM<CategoryVM, EditCategoryView>
    {
        public EditCategoryVM(CategoryVM Item)
            : base(Item)
        {
        }

        public override void EditItem(EditCategoryView window)
        {
            if (CanEdit())
            {
                using (var context = new LeagueNinjasDBEntities())
                {
                    Category category = ItemToBeEdited.ToModel();
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            window.Close();
        }

        public override bool CanEdit()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                var categories = context.Categories.ToList();

                return categories.Any(c => c.Name == ItemToBeEdited.Name);
            }
        }
    }
}
