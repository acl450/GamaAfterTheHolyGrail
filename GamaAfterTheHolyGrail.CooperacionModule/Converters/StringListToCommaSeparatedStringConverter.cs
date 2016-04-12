using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Text.RegularExpressions;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using GamaAfterTheHolyGrail.Business;

namespace GamaAfterTheHolyGrail.CooperacionModule.Converters
{
    public class StringListToCommaSeparatedStringConverter : IValueConverter
    {
        public StringListToCommaSeparatedStringConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringList = (List<Tag>)value ?? new List<Tag>();

            var commaSeparatedString = "";

            foreach (var item in stringList)
            {
                commaSeparatedString += item.Value + ", ";
            }

            // Eliminamos la última coma y el último espacio
            if (stringList.Count > 0)
            {
                commaSeparatedString = commaSeparatedString.Substring(0, commaSeparatedString.Length - ", ".Length );
            }

            return commaSeparatedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var commaSeparatedList = (string)value ?? string.Empty;
            var stringList = new List<Tag>();

            var pattern = "([a-zA-Z.0-9áéíóúÁÉÍÓÚ¡!¿?* ])+";
            MatchCollection matches = Regex.Matches(commaSeparatedList, pattern);

            foreach (Match match in matches)
            {
                if (match.Value.Trim() != string.Empty)
                {
                    stringList.Add(new Tag() { Value = match.Value.Trim() });
                }
            }

            return stringList;
        }
    }
}
