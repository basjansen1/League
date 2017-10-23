using GalaSoft.MvvmLight;
using League.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.ViewModel
{
    public class NinjaVM : ViewModelBase
    {
        private Ninja _ninja;

        public NinjaVM()
        {
            _ninja = new Ninja();
        }

        public NinjaVM(Ninja ninja)
        {
            _ninja = ninja;
        }

        public int Id
        {
            get { return _ninja.Id; }
            set
            {
                _ninja.Id = value;
                base.RaisePropertyChanged("Id");
            }
        }

        public int AmountOfGold
        {
            get { return _ninja.AmountGold; }
            set
            {
                _ninja.AmountGold = value;
                base.RaisePropertyChanged();
            }
        }

        public Ninja ToModel()
        {
            return _ninja;
        }
    }
}
