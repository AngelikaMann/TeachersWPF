using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TeachersWPF
{
    internal class ServiceToColorConverter : IValueConverter
    {
        private string status;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            status = value.ToString();
            if (status.Equals("Discord"))
            {
                return Brushes.DarkGray;
            }
            if (status.Equals("Zoom"))
            {
                return Brushes.AliceBlue;
            }
            if (status.Equals("WebinarUni"))
            {
                return Brushes.Orange;
            }
            return Brushes.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
