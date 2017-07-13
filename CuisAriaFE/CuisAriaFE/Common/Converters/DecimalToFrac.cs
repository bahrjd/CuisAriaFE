using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace CuisAriaFE.Common.Converters
{
    public sealed class DecimalToFrac : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert decimal numbers to fractions for display
            var qtyFrac = " ";
            var fracValue = (decimal)value % 1;
            if (fracValue > 0.292m && fracValue < 0.354m)
            {
                qtyFrac = "1/3";
            } else if (fracValue > 0.646m && fracValue < 0.708m)
            {
                qtyFrac = "2/3";
            }
            else
            {
                var fracListIndex = (int)(8 * fracValue - 1);
                if (fracListIndex >= 0)
                {
                    qtyFrac = Constants.FracList[fracListIndex];
                }
            }

            var qtyInt = Math.Truncate((decimal)value).ToString();
            if (qtyInt == "0")
            {
                qtyInt = " ";
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
