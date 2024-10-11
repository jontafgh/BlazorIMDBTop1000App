using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace BlazorIMDBTop1000App
{
    public class Movie
    {
        public string? PosterLink { get; set; }
        public string? SeriesTitle { get; set; }
        public DateOnly ReleasedYear { get; set; }
        public string? Certificate { get; set; }
        public TimeSpan Runtime { get; set; }
        public string? Genre { get; set; }
        public float IMDBRating { get; set; }
        public string? Overview { get; set; }
        public int Metascore { get; set; }
        public string? Director { get; set; }
        public string? Star1 { get; set; }
        public string? Star2 { get; set; }
        public string? Star3 { get; set; }
        public string? Star4 { get; set; }
        public int NoofVotes { get; set; }
        public int Gross { get; set; }
    }
    public sealed class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.PosterLink).Name("Poster_Link");
            Map(m => m.SeriesTitle).Name("Series_Title");
            Map(m => m.ReleasedYear).TypeConverter<DateOnlyFromYear>().Name("Released_Year");
            Map(m => m.Certificate);
            Map(m => m.Runtime).TypeConverter<MinutesToTimeSpanConverter>();
            Map(m => m.Genre);
            Map(m => m.IMDBRating).Name("IMDB_Rating");
            Map(m => m.Overview);
            Map(m => m.Metascore).TypeConverter<EmptyValueConverter>().Name("Meta_score");
            Map(m => m.Director);
            Map(m => m.Star1);
            Map(m => m.Star2);
            Map(m => m.Star3);
            Map(m => m.Star4);
            Map(m => m.NoofVotes).Name("No_of_Votes");
            Map(m => m.Gross).TypeConverter<IntWithCommasConverter>();
        }
    }
    public class DateOnlyFromYear : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (DateOnly.TryParseExact(text, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dt))
            {
                return dt;
            }
            throw new TypeConverterException(this, memberMapData, text, row.Context, "Invalid number format");
        }
    }
    public class IntWithCommasConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (int.TryParse(text?.Replace(",", ""), out int result))
            {
                return result;
            }
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            throw new TypeConverterException(this, memberMapData, text, row.Context, "Invalid number format");
        }
    }
    public class EmptyValueConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (int.TryParse(text, out int result))
            {
                return result;
            }
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }
            throw new TypeConverterException(this, memberMapData, text, row.Context, "Invalid number format");
        }
    }
    public class MinutesToTimeSpanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (int.TryParse(text?.Split(' ')[0], out int result))
            {
                return TimeSpan.FromMinutes(result);
            }
            if (string.IsNullOrEmpty(text))
            {
                return TimeSpan.FromMinutes(0);
            }
            throw new TypeConverterException(this, memberMapData, text, row.Context, "Invalid number format");
        }
    }
}

