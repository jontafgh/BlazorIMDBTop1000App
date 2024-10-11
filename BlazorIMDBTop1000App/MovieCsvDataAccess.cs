using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace BlazorIMDBTop1000App
{
    public class MovieCsvDataAccess
    {
        public List<Movie> GetImdbTop1000Movies()
        {
            using (var reader = new StreamReader("Data/imdb_top_1000.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<Movie>();
                csv.Context.RegisterClassMap<MovieMap>();
                try
                {
                    records = csv.GetRecords<Movie>().ToList();
                }
                catch (TypeConverterException ex)
                {
                    records.Add(new Movie() { SeriesTitle = ex.Message });
                }
                return records;
            }
        }
    }

}
