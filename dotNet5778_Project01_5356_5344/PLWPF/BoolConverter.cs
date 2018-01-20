using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PLWPF
{
    /// <summary>
    /// convert the 'bool?' type from the checkbox to regular 'bool'
    /// </summary>
    public class BoolConverter : IValueConverter
    {
        /// <summary>
        /// convert the 'bool?' type from the checkbox to regular 'bool'
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool checkBoxValue = (bool)value;
            return checkBoxValue;
        }

        /// <summary>
        /// convert the 'bool' type back to 'bool?'
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool strValue = (bool)value;
            return strValue;
        }
    }
}
