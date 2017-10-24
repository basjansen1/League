using League.Model;
using League.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    // MainVM
    public class NinjaListVM : CrudObject<NinjaVM>
    {
        private AddNinjaView _addNinjaView;
        private EditNinjaView _editNinjaView;

        public NinjaListVM()
        {
            base.ItemList = new System.Collections.ObjectModel.ObservableCollection<NinjaVM>();
        }

        public override void AddItem()
        {
            ItemVM = new NinjaVM();

            using (var context = new LeagueNinjasDBEntities())
            {
                // Increment the id
                ItemVM.Id = context.Ninjas.Max(i => i.Id) + 1;
                ItemList.Add(ItemVM);

                context.Ninjas.Add(ItemVM.ToModel());
                context.SaveChanges();
            }

            HideAddWindow();
        }

        public override void DeleteItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Ninjas.Remove(SelectedItem.ToModel());
                context.SaveChanges();
            }

            ItemList.Remove(SelectedItem);
        }

        public override void EditItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                Ninja ninja = SelectedItem.ToModel();
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }

            HideEditWindow();
        }

        public override void ShowAddWindow()
        {
            _addNinjaView = new AddNinjaView();
            _addNinjaView.Show();
        }

        public override void ShowEditWindow()
        {
            _editNinjaView = new EditNinjaView();
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
    }
}
