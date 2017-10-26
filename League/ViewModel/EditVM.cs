using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public abstract class EditVM<T,W> : ViewModelBase
    {
        public T ItemToBeEdited { get; set; } 
        public ICommand EditCommand { get; set; }

        public EditVM(T Item)
        {
            ItemToBeEdited = Item;
            EditCommand = new RelayCommand<W>(EditItem);
        }

        public abstract void EditItem(W window); 
        public abstract bool CanEdit(); // Show error through a message box when item cannot be editted
    }
}
