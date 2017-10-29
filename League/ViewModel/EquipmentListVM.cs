﻿using League.Model;
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
        AddEquipmentView _addEquipmentView;
        EditEquipmentView _editEquipmentView;

        public EquipmentListVM()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Equipments.ToList().ForEach(e => ItemList.Add(new EquipmentVM(e))); // Do by all VM Lists
            }
        }
        public override void DeleteItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                context.Equipments.Where(e => e.Id == SelectedItem.Id).ToList().ForEach(s => context.Equipments.Remove(s));
                context.SaveChanges();
            }
            ItemList.Remove(SelectedItem);
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
               // list.ForEach(e => new EquipmentVM(e)); 
            }

            return returnList;
        }
    }
}
