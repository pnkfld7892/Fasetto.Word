using System;
using System.Globalization;
using System.Windows;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// A converter that takes in a <see cref="BaseViewModel"/>
    /// and return the specific UI Control that should be bound to that type of view model
    /// </summary>
    class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChatAttachmentPopupMenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup.Content };
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
