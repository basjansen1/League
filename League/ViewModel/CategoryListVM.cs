using League.Model;
using League.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    public class CategoryListVM : CrudObject<CategoryVM>
    {
        private AddCategoryView _addView;
        private EditCategoryView _editView;
        public override void DeleteItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Categories.Remove(SelectedItem.ToModel());
                context.SaveChanges();
            }
            ItemList.Remove(SelectedItem);
        }

        public override void ShowAddWindow()
        {
            _addView = new AddCategoryView();
            _addView.Show();
        }

        public override void ShowEditWindow()
        {
            _editView = new EditCategoryView();
            _editView.Show();
        }

        public List<EquipmentVM> GetEquipmentOfCategory(string category)
        {
            List<EquipmentVM> equipmentList;

            using (var context = new LeagueNinjasDBEntities())
            {
                equipmentList = context.Equipments.Where(e => e.Category.Equals(category)).Select(s => new EquipmentVM(s)).ToList();
            }
            return equipmentList;
        }

        public override void HideAddWindow()
        {
            _addView.Close();
        }

        public override void HideEditWindow()
        {
            _editView.Close();
        }
    }
}
