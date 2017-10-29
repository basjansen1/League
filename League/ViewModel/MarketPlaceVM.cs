using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using League.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public class MarketPlaceVM : ViewModelBase
    {
        public CategoryListVM CategoryList { get; set; }
        public EquipmentListVM EquipmentList { get; set; }
        public NinjaListVM NinjaList { get; set; }
        public InventoryVM Inventory { get; set; }
        public ObservableCollection<EquipmentVM> EquipentsOfSelectedCategoryCollection { get; set; }
        public ICommand UpdateCollectionCommand { get; set; } // When a category is selected, the equipmentsdatagrid has to be updated
        public ICommand BuyEquipmentCommand { get; set; }
        public MarketPlaceVM(CategoryListVM categoryList, EquipmentListVM equipmentVM, NinjaListVM ninjaList, InventoryVM inventory)
        {
            CategoryList = categoryList;
            EquipmentList = equipmentVM;
            NinjaList = ninjaList;
            Inventory = inventory;
            EquipentsOfSelectedCategoryCollection = new ObservableCollection<EquipmentVM>();
            UpdateCollectionCommand = new RelayCommand(UpdateEquipmentCollection);
            BuyEquipmentCommand = new BuyEquipmentCommand(this);
        }

        public void UpdateEquipmentCollection()
        {
            EquipentsOfSelectedCategoryCollection.Clear();
            EquipmentList.getEquipmentsByCategory(CategoryList.SelectedItem.Name).ForEach(e => EquipentsOfSelectedCategoryCollection.Add(new EquipmentVM(e)));
        }
    }
}
