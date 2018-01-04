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
        public string ItemToEditCategory { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<string> CategoryNamesList { get; set; }
        public string FirstCategory { get; set; }

        public EditEquipmentVM(EquipmentVM Item) : base(Item)
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                CategoryList = context.Categories.ToList();

                CategoryNamesList = CategoryList.Select(c => c.Name).ToList();
            }

            FirstCategory = CategoryNamesList.First();
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
            window.Close();
        }

        public override bool CanEdit()
        {
            if(ItemToBeEdited.Name != null 
                && ItemToEditCategory == null 
                && ItemToBeEdited.Agility != 0
                && ItemToBeEdited.Intelligence != 0 
                && ItemToBeEdited.Price != 0
                && ItemToBeEdited.Strength != 0)
                return true;
            else
            {
                MessageBox.Show("Please enter all fields!");
                return false;
            }
        }
    }
}
