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
    // MainVM
    public class NinjaListVM : CrudObject<NinjaVM>
    {
        private AddNinjaView _addNinjaView;
        private EditNinjaView _editNinjaView;
        private InventoryView _inventoryView;
        public ICommand ShowInventoryViewCommand { get; set; }

        public NinjaListVM()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.ToList().ForEach(n => ItemList.Add(new NinjaVM(n))); // Do by all VM Lists
            }
            ShowInventoryViewCommand = new RelayCommand(ShowInventoryWindow);
        }

        public override void DeleteItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Where(n => n.Id == SelectedItem.Id).ToList().ForEach(s => context.Ninjas.Remove(s));
                context.SaveChanges();
            }

            ItemList.Remove(SelectedItem);
        }

        public override void ShowAddWindow()
        {
            _addNinjaView = new AddNinjaView();
            _addNinjaView.Show();
        }

        public override void ShowEditWindow()
        {
            _editNinjaView = new EditNinjaView();
            new EditNinjaVM(SelectedItem);
            _editNinjaView.Show();
        }

        public override void HideAddWindow()
        {
            _addNinjaView.Hide();
        }

        public override void HideEditWindow()
        {
            _editNinjaView.Hide();
        }

        public void ShowInventoryWindow()
        {
            _inventoryView = new InventoryView();
            _inventoryView.Show();
        }

        public void HideInventoryWindow()
        {
            _inventoryView.Hide();
        }
    }
}
