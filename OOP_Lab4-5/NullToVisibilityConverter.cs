using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace OOP_Lab4_5
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isInverse = parameter as string == "Inverse";
            bool isVisible = value != null;

            if (isInverse) isVisible = !isVisible;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}