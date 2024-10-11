using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace BlazorIMDBTop1000App
{
    public class MovieCsvDataAccess
    {
        private static List<Movie> GetImdbTop1000()
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
        public Dictionary<Movie, bool> GetImdbTop1000Movies()
        {
            Dictionary<Movie, bool> imdbTop1000 = new Dictionary<Movie, bool>();

            foreach (var movie in GetImdbTop1000())
            {
                imdbTop1000.Add(movie, false);
            }
            return imdbTop1000;
        }
    }

}
