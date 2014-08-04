using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CodeInvaders.Catan.App
{
    public class ActivePlayerToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var player = value as PlayerViewModel;

            if (player != null)
            {
                if (player.IsActive)
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
