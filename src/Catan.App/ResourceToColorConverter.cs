using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CodeInvaders.Catan.App
{
    public class ResourceToColorConverter : IValueConverter
    {
        public object Convert(object supposedResource, Type targetType, object parameter, CultureInfo culture)
        {
            var realResource = CheckIsTileViewModel(supposedResource);

            switch (realResource)
            {
                case Resource.Wood:
                    return new SolidColorBrush(Colors.DarkGreen);
                case Resource.Brick:
                    return new SolidColorBrush(Colors.Orange);
                case Resource.Grain:
                    return new SolidColorBrush(Colors.Yellow);
                case Resource.Ore:
                    return new SolidColorBrush(Colors.Gray);
                case Resource.Sheep:
                    return new SolidColorBrush(Colors.LightGreen);

                default:
                    return new SolidColorBrush(Colors.DarkRed);
            }
        }

        public Resource CheckIsTileViewModel(object supposedResource)
        {
            try
            {
                return (Resource) supposedResource;
            }
            catch (Exception)
            {
                throw new Exception("You're giving something that isn't a Resource to the Resource Converter, genious.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
