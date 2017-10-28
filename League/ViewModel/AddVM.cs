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
    public abstract class AddVM <T,N> : ViewModelBase
    {
        public T VMList { get; set; }
        public N NewItem { get; set; } // ToDo instancieren

        public ICommand AddCommand { get; set; }

        public AddVM(T ViewModelList)
        {
            VMList = ViewModelList;
            AddCommand = new RelayCommand(AddItem);
        }

        public abstract void AddItem();

        public abstract bool CanAdd();

    }
}
