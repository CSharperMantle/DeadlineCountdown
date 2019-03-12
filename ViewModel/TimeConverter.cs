using System;
using System.Globalization;
using System.Windows.Data;

namespace DeadlineCountdown.ViewModel
{
    public sealed class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan.ToString(@"hh\:mm\:ss");
            }
            else
            {
                throw new ArgumentException(nameof(value) + " is not a TimeSpan");
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Two-way binding is not supported on " +
                                            nameof(TimeConverter));
        }
    }
}
