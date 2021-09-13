using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace CSVLocalHelper
{
    public class BooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return (bool)value ? "yes" : string.Empty;
        }
    }
}
