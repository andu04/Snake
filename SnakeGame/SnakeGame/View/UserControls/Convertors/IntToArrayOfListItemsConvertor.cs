using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SnakeGame.View.UserControls.Convertors
{
    public class IntToArrayOfListItemsConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int count = (int) value;
            string[] items = new string[count];
            for (int i = 0; i < count; i++)
                items[i] = "O";
            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
