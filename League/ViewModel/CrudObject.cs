using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public abstract class CrudObject <T> : ViewModelBase
    {
        private T _selectedItem;
        public T ItemVM { get; set; } // intented for adding an item
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                base.RaisePropertyChanged();
            }
        }
        ObservableCollection<T> ItemList { get; set; }

        // Commands
        ICommand AddCommand { get; set; }
        ICommand EditCommand { get; set; }
        ICommand DeleteCommand { get; set; }
        ICommand ShowAddCommand { get; set; }
        ICommand ShowEditCommand { get; set; }

        public CrudObject()
        {
            ItemList = new ObservableCollection<T>();

            AddCommand = new RelayCommand(AddItem);
            EditCommand = new RelayCommand(EditItem);
            DeleteCommand = new RelayCommand(DeleteItem);
            ShowAddCommand = new RelayCommand(ShowAddWindow);
            ShowEditCommand = new RelayCommand(ShowEditWindow);
        }

        public abstract void AddItem();
        public abstract void EditItem();
        public abstract void DeleteItem();
        public abstract void ShowAddWindow();
        public abstract void ShowEditWindow();
    }
}
