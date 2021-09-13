using CsvHelper.Configuration;
using Entities;

namespace CSVLocalHelper
{
    public class MovieCsvMap : ClassMap<Movie>
    {
        public MovieCsvMap()
        {
            Map(x => x.Year).Index(0);
            Map(x => x.Title).Index(1);
            Map(x => x.Studios).Index(2);
            Map(x => x.Producers).Index(3);
            Map(x => x.Winner).Index(4).TypeConverter<BooleanConverter>();
        }
    }
}
