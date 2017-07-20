using Fasetto.Word.Core;
using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
    class MenuItemTypeToVisibilityConverter : BaseValueConverter<MenuItemTypeToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if no param return invisible
            if (parameter == null)
                return Visibility.Collapsed;

            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
