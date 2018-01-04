using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace League.Utils
{
    public class GoldToEuroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int goldWorth = (int) value;
            return (int) (goldWorth * 276);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int goldWorth = (int) value;
            return (int) (goldWorth / 276);
        }
    }
}
