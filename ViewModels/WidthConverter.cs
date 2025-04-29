using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyWpfApp.Utilities
{
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState state)
            {
                // Установите разные ширины для разных режимов
                return state == WindowState.Maximized ? 400 : 200;
            }
            return 200; // Значение по умолчанию
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}