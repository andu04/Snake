using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SnakeGame.View.UserControls.Convertors
{
    class IntToElementsInStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int count = (int)value;
            StringBuilder stringElements = new StringBuilder();
            for (int i = 0 ; i < count ; i++)
            {
                stringElements.Append(" -O- ");
            }
            return stringElements.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
