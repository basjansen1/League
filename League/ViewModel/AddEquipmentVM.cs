﻿using GalaSoft.MvvmLight.Command;
using League.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace League.ViewModel
{
    public class AddEquipmentVM : AddVM<EquipmentListVM, EquipmentVM>
    {
        public string NewCategoryName { get; set; }
        public AddEquipmentVM(EquipmentListVM ViewModelList) 
            : base(ViewModelList)
        {
            NewItem = new EquipmentVM();
            VMList = ViewModelList;
        }
        public override void AddItem()
        {
            if (CanAdd())
            {
                using (var context = new LeagueNinjasDBEntities())
                {
                    NewItem.Id = context.Equipments.Max(i => i.Id) + 1; // Get the highest ID and increment this

                    VMList.ItemList.Add(NewItem);
                    context.Equipments.Add(NewItem.ToModel());

                    context.SaveChanges();
                }
                VMList.HideAddWindow();
            }
        }

        public override bool CanAdd()
        {
            if (NewItem.Name == null)
            {
                MessageBox.Show("You have to give a name to the equipment!");
                return false;
            } else if (NewItem.Strength == 0)
            {
                MessageBox.Show("You have to assign a strenght value higher than 0");
                return false;
            } else if (NewItem.Intelligence == 0)
            {
                MessageBox.Show("You have to assign an intelligence value higher than 0");
                return false;
            } else if (NewItem.Agility == 0)
            {
                MessageBox.Show("You have to assign an agility value higher than 0");
                return false;
            } else if (NewItem.Price == 0)
            {
                MessageBox.Show("You have to assign a price value higher than 0");
                return false;
            } else if (NewCategoryName != null || NewItem.SetCategory(NewCategoryName))
            {
                if(NewCategoryName != null)
                {
                    MessageBox.Show("You have to assign a category");
                    return false;
                } else
                {
                    MessageBox.Show("This category does not exists");
                    return false;
                }
            }
            else
                return true;
        }
    }
}
