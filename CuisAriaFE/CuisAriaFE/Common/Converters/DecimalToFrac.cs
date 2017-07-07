using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace CuisAriaFE.Common.Converters
{
    public class Decimal2Frac : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert decimal numbers to fractions for display
            var fracListIndex = (int)((8 * ((decimal)value % 1)) - 1);
            var qtyInt = Math.Truncate((decimal)value).ToString();
            var qtyFrac = " ";
            if (qtyInt == "0")
            {
                qtyInt = " ";
            }
            if (fracListIndex >= 0)
            {
                qtyFrac = Constants.FracList[fracListIndex];
            }

            return qtyInt + " " + qtyFrac;

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert fractions to decimal numbers for storage



            return 0m;

        }
    }
}
