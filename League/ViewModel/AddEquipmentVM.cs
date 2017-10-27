using GalaSoft.MvvmLight.Command;
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
        public string TextName { get; set; }
        public string TextStrength { get; set; }
        public string TextIntelligence { get; set; }
        public string TextAgility { get; set; }
        public string TextPrice { get; set; }
        public string TextCategory { get; set; }

        public ICommand AddEquipment { get; set; }

        public AddEquipmentVM(EquipmentListVM ViewModelList) : base(ViewModelList)
        {
            NewItem = new EquipmentVM();
            VMList = ViewModelList;

            AddEquipment = new RelayCommand(AddItem);
        }
        public override void AddItem()
        {
            using (var context = new LeagueNinjasDBEntities())
            {
                NewItem.Id = context.Equipments.Max(i => i.Id) + 1; // Get the highest ID and increment this
                NewItem.Name = TextName;
                NewItem.Strength = Int32.Parse(TextStrength);
                NewItem.Intelligence = Int32.Parse(TextIntelligence);
                NewItem.Agility = Int32.Parse(TextAgility);
                NewItem.Price = Int32.Parse(TextPrice);
                NewItem.SetCategory(TextCategory);

                VMList.ItemList.Add(NewItem);
                context.Equipments.Add(NewItem.ToModel());
                context.SaveChanges();
            }
            VMList.HideAddWindow();
        }

        public override bool CanAdd()
        {
            if (NewItem.Name == null)
            {
                MessageBox.Show("You have to give a name to the equipment!");
                return false;
            }

            if (TextCategory != null)
            {
                MessageBox.Show("You have to assign a category!");
                return false;
            }
            else if (!NewItem.SetCategory(TextCategory))
            {
                MessageBox.Show("The chosen category does not excists!");
                return false;
            }
            else
                return true;
        }
    }
}
