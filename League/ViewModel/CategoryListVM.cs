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
            throw new NotImplementedException();
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

        public void GetEquipmentOfCategory(Category category)
        {
            
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
