using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace BlazorIMDBTop1000App
{

    public class MovieCsvDataAccess
    {
        private async Task<string> GetCsvDataAsync()
        {
            using HttpClient client = new HttpClient();
            string data = await client.GetStringAsync("https://raw.githubusercontent.com/merveser/IMDB_Data_Analysis/refs/heads/main/imdb_top_1000.csv");
            return data;
        }
        private async Task WriteToCsvFileAsync(string data)
        {
            using (StreamWriter writer = new StreamWriter("imdbtop1000.csv"))
            {
                await writer.WriteLineAsync(data);
            }
        }
        public async Task<List<Movie>> GetImdbTop1000MoviesAsync()
        {
            string data = await GetCsvDataAsync();
            await WriteToCsvFileAsync(data);

            using (var reader = new StreamReader("imdbtop1000.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<Movie> movies = new List<Movie>();
                csv.Context.RegisterClassMap<MovieMap>();
                await foreach (var record in csv.GetRecordsAsync<Movie>())
                {
                    movies.Add(record);
                }
                return movies;
            }
        }
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
