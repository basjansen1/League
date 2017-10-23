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
    public class EquipmentListVM : CrudObject<EquipmentVM>
    {
        public override void AddItem()
        {
            // ToDo: Bind selected category to ItemVM
            ItemVM = new EquipmentVM();
            this.ShowAddWindow();

            using (var context = new LeagueNinjasDBEntities())
            {
                ItemVM.Id = context.Equipments.Max(i => i.Id) + 1; // Get the highest ID and increment this
                ItemList.Add(ItemVM);
                context.Equipments.Add(ItemVM.ToModel());
                context.SaveChanges();
            }
            HideAddWindow();
        }

        public override void DeleteItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Equipments.Remove(SelectedItem.ToModel());
                context.SaveChanges();
            }
            ItemList.Remove(SelectedItem);
        }

        public override void EditItem()
        {
            ShowEditWindow();

            using (var context = new LeagueNinjasDBEntities())
            {
                Equipment equipment = SelectedItem.ToModel();
                context.Entry(equipment).State = EntityState.Modified;
                context.SaveChanges();
            }
            HideEditWindow();
        }

        public void HideAddWindow()
        {
            throw new NotImplementedException();
        }

        public void HideEditWindow()
        {
            throw new NotImplementedException();
        }

        public override void ShowAddWindow()
        {
            AddEquipmentView equipmentView = new AddEquipmentView();
            equipmentView.Show();
        }

        public override void ShowEditWindow()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> getEquipmentsByCategory(Category category)
        {
            List<Equipment> returnList;

            using (var context = new LeagueNinjasDBEntities())
            {
                returnList = context.Equipments.Where(i => i.Category.Equals(category)).ToList();
            }

            return returnList;
        }
    }
}
