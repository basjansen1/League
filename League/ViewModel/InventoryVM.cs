using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using League.Model;
using League.Utils;
using League.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.ViewModel
{
    public class InventoryVM : ViewModelBase
    {
        private MarketPlaceView _marketPlaceView;

        public NinjaVM SelectedNinja { get; set; }

        public ICommand GoToMarketCommand { get; set; }
        public ICommand SellAllItemsCommand { get; set; }
        public ICommand SellEquipmentCommand { get; set; }

        public ObservableCollection<EquipmentVM> NinjaEquipmentsCollection { get; set; }

        public InventoryVM(NinjaVM selectedNinja)
        {
            SelectedNinja = selectedNinja;
            SellAllItemsCommand = new SellAllItemsCommand(this);
            SellEquipmentCommand = new SellEquipmentCommand(this);
            GoToMarketCommand = new RelayCommand(OpenMarketView);
            NinjaEquipmentsCollection = new ObservableCollection<EquipmentVM>();
            using (var context = new LeagueNinjasDBEntities())
            {
                SelectedNinja.ToModel().Equipments.Select(e => new EquipmentVM(e)).ToList().ForEach(e => NinjaEquipmentsCollection.Add(e));
            }
        }

        public int GetTotalStrenght
        {
            get
            {
                int strength = 0;
                NinjaEquipmentsCollection.ToList().ForEach(e => strength += e.Strength);
                return strength;
            }
        }

        public int GetTotalInteligence
        {
            get
            {
                int inteligence = 0;
                NinjaEquipmentsCollection.ToList().ForEach(e => inteligence += e.Intelligence);
                return inteligence;
            }
        }

        public int GetTotalAgility
        {
            get
            {
                int agility = 0;
                NinjaEquipmentsCollection.ToList().ForEach(e => agility += e.Agility);
                return agility;
            }
        }

        public int GetTotalWorth
        {
            get
            {
                int worth = 0;
                NinjaEquipmentsCollection.ToList().ForEach(e => worth += e.Price);
                return worth;
            }
        }

        public void UpdateNinjaEquipmentsCollection()
        {
            RaisePropertyChanged(() => GetTotalStrenght);
            RaisePropertyChanged(() => GetTotalInteligence);
            RaisePropertyChanged(() => GetTotalAgility);
            RaisePropertyChanged(() => GetTotalWorth);
        }

        public void AddEquipmentToCollection(Equipment equipment)
        {
            NinjaEquipmentsCollection.Add(new EquipmentVM(equipment));
            UpdateNinjaEquipmentsCollection();
        }

        private void OpenMarketView()
        {
            _marketPlaceView = new MarketPlaceView();
            _marketPlaceView.Show();
        }
    }
}
