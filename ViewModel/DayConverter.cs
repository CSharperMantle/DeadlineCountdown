using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeadlineCountdown.ViewModel
{
    class DayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var builder = new StringBuilder();

            if (value is int intVal)
            {
                builder.Append(intVal);
                if (intVal <= 1)
                {
                    builder.Append(" DAY");
                }
                else
                {
                    builder.Append(" DAYS");
                }
                return builder.ToString();
            }
            else
            {
                throw new ArgumentException(nameof(value) + " is not an int");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Two-way binding is not supported on " +
                                            nameof(DayConverter));
        }
    }
}
