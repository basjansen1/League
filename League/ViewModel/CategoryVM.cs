using GalaSoft.MvvmLight;
using League.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    public class CategoryVM : ViewModelBase
    {
        //Properties
        public string Name
        {
            get
            {
                return _category.Name;
            }
            set
            {
                _category.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        // Field
        private Category _category;

        // Constructors
        public CategoryVM()
        {
            _category = new Category();
        }

        public CategoryVM(Category category)
        {
            _category = category;
        }

        public Category ToModel()
        {
            return _category;
        }
    }
}
