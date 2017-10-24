using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League.Utils
{
    public abstract class GoldConverter
    {
        /// <summary>
        /// Converts the given gold to real money. 
        /// Euros in this case.
        /// </summary>
        /// <param name="amountOfGold"></param>
        /// <returns>x euros that the gold is worth</returns>
        public static int Convert(int amountOfGold)
        {
            return amountOfGold * 276;
        }

        /// <summary>
        /// Converts the given euros back to gold
        /// </summary>
        /// <param name="amountOfGold"></param>
        /// <returns>an x amount of gold worth of the given amount of euros</returns>
        public static int ConvertBack(int amountOfEuros)
        {
            return amountOfEuros / 276;
        }
    }
}
