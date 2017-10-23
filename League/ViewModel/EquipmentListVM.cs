using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    public class EquipmentListVM : CrudObject<EquipmentVM>
    {
        public override void AddItem()
        {
            ItemList.Add(SelectedItem);

            using (var context = new LeagueNinjasDBEntities())
            {
            }
        }

        public override void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public override void EditItem()
        {
            throw new NotImplementedException();
        }

        public override void ShowAddWindow()
        {
            throw new NotImplementedException();
        }

        public override void ShowEditWindow()
        {
            throw new NotImplementedException();
        }
    }
}
