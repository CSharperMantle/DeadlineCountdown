using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace DeadlineCountdown.ViewModel
{
    class DayStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var builder = new StringBuilder();

            if (value is int daysToDeadline)
            {
                builder.Append(daysToDeadline);
                if (daysToDeadline <= 1)
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
                                            nameof(DayStringConverter));
        }
    }
}
