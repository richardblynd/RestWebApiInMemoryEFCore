using CSVLocalHelper;
using Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataGenerator
    {
        public static void Initialize(AwardsDBContext context, string csvFilePath, ILogger log)
        {
            if (context.Movies.Any())
                return;

            context.Movies.AddRange(LoadCsvFile(csvFilePath, log));

            context.SaveChanges();
        }

        private static List<Movie> LoadCsvFile(string csvFilePath, ILogger log)
        {
            var csvReader = new CSVReader();
            return csvReader.ReadMovieCSV(csvFilePath, log); 
        }
    }
}
