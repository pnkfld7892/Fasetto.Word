
using Fasetto.Word.Core;
using Ninject;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.Word
{
    /// <summary>
    /// Converts a string name to a service called from the IoC Container
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the Approprate page
            switch((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
