using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BlazorIMDBTop1000App
{
    public class MovieCsvDataAccess
    {
        public List<Movie> GetImdbTop1000Movies()
        {
            CsvUtilities<Movie> csvUtilities = new CsvUtilities<Movie>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = header => Regex.Replace(header.Header, @"_", string.Empty)
                
            };

            return csvUtilities.ReadCsv("Data/imdb_top_1000.csv", config).ToList();
        }
    }
}
