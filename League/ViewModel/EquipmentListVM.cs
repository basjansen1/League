using League.Model;
using League.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace League.ViewModel
{
    public class EquipmentListVM : CrudObject<EquipmentVM>
    {
        AddEquipmentView _addEquipmentView;
        EditEquipmentView _editEquipmentView;

        public EquipmentListVM()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Equipments.Include("Ninjas").ToList().ForEach(e => ItemList.Add(new EquipmentVM(e))); // Do by all VM Lists
            }
        }
        public override void DeleteItem()
        {
            DeleteAttachedNinjas();
            using (var context = new LeagueNinjasDBEntities())
            {
                //poging 1
                Equipment equipment = context.Equipments.Find(SelectedItem.Id);
                try
                {
                    context.Equipments.Remove(equipment);
                    context.SaveChanges();

                    MessageBox.Show("Equipment is verwijderd!");
                }
                catch {}
            }
            ItemList.Remove(SelectedItem);
        }

        public void DeleteAttachedNinjas()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Database.ExecuteSqlCommand("delete from dbo.NinjaInventory where " +
                    "Equipment_Id = @id", new SqlParameter("id", SelectedItem.Id));
                context.SaveChanges();
            }
        }

        public override void HideAddWindow()
        {
            _addEquipmentView.Hide();
        }

        public override void HideEditWindow()
        {
            _editEquipmentView.Hide();
        }

        public override void ShowAddWindow()
        {
            _addEquipmentView = new AddEquipmentView();
            _addEquipmentView.Show();
        }

        public override void ShowEditWindow()
        {
            _editEquipmentView = new EditEquipmentView();
            _editEquipmentView.Show();
        }

        public List<Equipment> getEquipmentsByCategory(string category)
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
