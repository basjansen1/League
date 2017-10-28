﻿using GalaSoft.MvvmLight.Command;
using League.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace League.ViewModel
{
    public class AddCategoryVM : AddVM<CategoryListVM, CategoryVM>
    {
        public ICommand AddCategoryCommand { get; set; }
        public string NameText { get; set; }

        public AddCategoryVM(CategoryListVM ViewModelList)
            : base(ViewModelList)
        {
            NewItem = new CategoryVM();
            VMList = ViewModelList;

            AddCategoryCommand = new RelayCommand(AddItem);
        }

        public override void AddItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                NewItem.Name = NameText;

                if (!CanAdd())
                    return;

                VMList.ItemList.Add(NewItem);
                context.Categories.Add(NewItem.ToModel());
                context.SaveChanges();
            }
            VMList.HideAddWindow();
        }

        public override bool CanAdd()
        {
            if (NewItem.Name != null)
                return true;
            else
            {
                MessageBox.Show("You have to give a name to the category!");
                return false;
            }
        }
    }
}
