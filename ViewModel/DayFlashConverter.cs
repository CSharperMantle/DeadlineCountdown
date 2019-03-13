using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DeadlineCountdown.ViewModel
{
    class DayFlashConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int daysToDeadline)
            {
                if (daysToDeadline <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException(nameof(value) + " is not an int");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Two-way binding is not supported on " +
                                            nameof(DayFlashConverter));
        }
    }
}
