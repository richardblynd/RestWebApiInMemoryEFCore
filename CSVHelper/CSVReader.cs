using CsvHelper;
using CsvHelper.Configuration;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSVLocalHelper
{
    public class CSVReader
    {
        public List<Movie> ReadMovieCSV(string csvFilePath, ILogger log)
        {
            var result = new List<Movie>();
            try
            {
                var config = new CsvConfiguration(CultureInfo.CreateSpecificCulture("pt-br"))
                {
                    HasHeaderRecord = true,
                };

                if (!File.Exists(csvFilePath))
                    throw new Exception($"File not found. File: {csvFilePath}");

                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<MovieCsvMap>();
                    result = csv.GetRecords<Movie>().ToList();
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Cannot parse CSV file. Error: {ex}");
            }

            return result;
        }
    }
}