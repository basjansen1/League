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
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<T> ItemList { get; set; }

        // Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ShowAddCommand { get; set; }
        public ICommand ShowEditCommand { get; set; }

        public CrudObject()
        {
            ItemList = new ObservableCollection<T>();

            DeleteCommand = new RelayCommand(DeleteItem);
            ShowAddCommand = new RelayCommand(ShowAddWindow);
            ShowEditCommand = new RelayCommand(ShowEditWindow);
        }

        public abstract void DeleteItem();
        public abstract void ShowAddWindow();
        public abstract void ShowEditWindow();
        public abstract void HideAddWindow();
        public abstract void HideEditWindow();
    }
}
