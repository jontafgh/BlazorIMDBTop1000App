namespace BlazorIMDBTop1000App
{
    public class ImdbTop1000Filter
    {
        public FilterValue<int> ReleasedYear { get; private set; }
        public FilterValue<int> Runtime { get; private set; }
        public FilterValue<int> Gross { get; private set; }
        public FilterValue<double> ImdbRating { get; private set; }
        public FilterValue<int> NoOfVotes { get; private set; }
        public FilterValue<int> MetaScore { get; private set; }
        public ImdbTop1000Filter(List<Movie> movies)
        {
            ReleasedYear = new FilterValue<int>(
                int.Parse(movies.OrderBy(x => x.ReleasedYear).ToList()[0].ReleasedYear.ToString("yyyy")),
                int.Parse(movies.OrderByDescending(x => x.ReleasedYear).ToList()[0].ReleasedYear.ToString("yyyy"))
                );
            Runtime = new FilterValue<int>(
                (int)movies.OrderBy(x => x.Runtime).ToList()[0].Runtime.TotalMinutes,
                (int)movies.OrderByDescending(x => x.Runtime).ToList()[0].Runtime.TotalMinutes
                );
            Gross = new FilterValue<int>(
                movies.OrderBy(x => x.Gross).ToList()[0].Gross,
                movies.OrderByDescending(x => x.Gross).ToList()[0].Gross
                );
            Gross = new FilterValue<int>(
                movies.OrderBy(x => x.Gross).ToList()[0].Gross,
                movies.OrderByDescending(x => x.Gross).ToList()[0].Gross
                );
            ImdbRating = new FilterValue<double>(
                movies.OrderBy(x => x.IMDBRating).ToList()[0].IMDBRating,
                movies.OrderByDescending(x => x.IMDBRating).ToList()[0].IMDBRating
                );
            NoOfVotes = new FilterValue<int>(
                movies.OrderBy(x => x.NoofVotes).ToList()[0].NoofVotes,
                movies.OrderByDescending(x => x.NoofVotes).ToList()[0].NoofVotes
                );
            MetaScore = new FilterValue<int>(
                movies.OrderBy(x => x.Metascore).ToList()[0].Metascore,
                movies.OrderByDescending(x => x.Metascore).ToList()[0].Metascore
                );
        }
    }
    public class FilterValue<T>
    {
        public FilterValue(T from, T to)
        {
            From = from;
            To = to;
        }
        public T From { get; set; }
        public T To { get; set; }
    }
}

