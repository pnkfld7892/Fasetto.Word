using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Takes a date time object and convcerts to user friendly message read time
    /// </summary>
    class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            //if it is not read
            if (time == DateTimeOffset.MinValue)
                return string.Empty;

            //if it is today...
            if (time.Date == DateTimeOffset.Now.Date)
                //return just the time
                return $"Read {time.ToLocalTime().ToString("hh:mm tt")}";
            else
                //return full date
                return $"Read {time.ToLocalTime().ToString("hh:mm tt, MMM dd yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
