using DeadlineCountdown.Model;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DeadlineCountdown.ViewModel
{
    class DayColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int daysToDeadline)
            {
                if (daysToDeadline <= DeadlineCountdownModel.ALERT_DAYS_TO_DEADLINE)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if (daysToDeadline <= DeadlineCountdownModel.WARNING_DAYS_TO_DEADLINE)
                {
                    return new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
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
                                            nameof(DayStringConverter));
        }
    }
}
