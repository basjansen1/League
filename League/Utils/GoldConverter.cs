using League.Model;
using League.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace League.Utils
{
    public class GoldConverter : ICommand
    {
        private int goldWorth;
        private InventoryVM inventory;
        public event EventHandler CanExecuteChanged;

        public GoldConverter(InventoryVM inventory)
        {
            this.inventory = inventory;
        }

        /// <summary>
        /// Converts the given gold to real money. 
        /// Euros in this case.
        /// </summary>
        /// <param name="amountOfGold"></param>
        /// <returns>x euros that the gold is worth</returns>
        private int Convert(int amountOfGold)
        {
            return amountOfGold * 276;
        }

        /// <summary>
        /// Converts the given euros back to gold
        /// </summary>
        /// <param name="amountOfGold"></param>
        /// <returns>an x amount of gold worth of the given amount of euros</returns>
        private int ConvertBack(int amountOfEuros)
        {
            return amountOfEuros / 276;
        }

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
            Int32.TryParse(parameter.ToString(), out goldWorth);

            if (goldWorth != 0)
                this.Convert(goldWorth);
            else
                Console.WriteLine("FOUTIEVE WAARDE VOOR CONVERTEN");
        }
    }
}
