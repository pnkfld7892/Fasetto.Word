using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Takes a date time object and convcerts to user friendly time
    /// </summary>
    class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;
            //if it is today...
            if (time.Date == DateTimeOffset.Now.Date)
                //return just the time
                return time.ToLocalTime().ToString("hh:mm tt");
            else
                //return full date
                return time.ToLocalTime().ToString("hh:mm tt, MMM yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
