using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto.Word
{
    /// <summary>
    /// Base calue converter that allow direct xaml access
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /// <summary>
        /// single static instance of this value converter
        /// </summary>
        private static T Converter = null;

        #region Markup Extension Methods
        /// <summary>
        /// provides a static instance of the balue converter
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //check if mconverter is null if it is return new mConverter
            return Converter ?? (Converter = new T());
        }

        #endregion
        #region VC methods
        /// <summary>
        /// Base convert to method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// base convert back method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
