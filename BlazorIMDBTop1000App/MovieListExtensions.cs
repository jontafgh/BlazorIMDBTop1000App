﻿namespace BlazorIMDBTop1000App
{
    public static class MovieListExtensions
    {
        public static List<Movie> Filter(this List<Movie> movies, int min, int max, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.Metascore => FilterByMetascore(movies, min, max),
            MovieProperty.NoOfVotes => FilterByNoofVotes(movies, min, max),
            MovieProperty.Gross => FilterByGross(movies, min, max),
            _ => FilterByGross(movies, min, max)
        };
        public static List<Movie> Filter(this List<Movie> movies, DateOnly min, DateOnly max, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.ReleasedYear => FilterByReleasedYear(movies, min, max),
            _ => FilterByReleasedYear(movies, min, max)
        };
        public static List<Movie> Filter(this List<Movie> movies, TimeSpan min, TimeSpan max, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.Runtime => FilterByRuntime(movies, min, max),
            _ => FilterByRuntime(movies, min, max)
        };
        public static List<Movie> Filter(this List<Movie> movies, double min, double max, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.IMDBRating => FilterByIMDBRating(movies, min, max),
            _ => FilterByIMDBRating(movies, min, max)
        };
        public static List<Movie> Search(this List<Movie> movies, string searchTerm, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.SeriesTitle => SearchBySeriesTitle(movies, searchTerm),
            MovieProperty.Director => SearchByDirector(movies, searchTerm),
            MovieProperty.Overview => SearchByOverview(movies, searchTerm),
            MovieProperty.Star => SearchByStars(movies, searchTerm),
            _ => SearchBySeriesTitle(movies, searchTerm)
        };
        public static List<Movie> Sort(this List<Movie> movies, bool sortDirection, MovieProperty movieProperty) => movieProperty switch
        {
            MovieProperty.SeriesTitle => SortBySeriesTitle(movies, sortDirection),
            MovieProperty.ReleasedYear => SortByReleasedYear(movies, sortDirection),
            MovieProperty.Certificate => SortByCertificate(movies, sortDirection),
            MovieProperty.Runtime => SortByRuntime(movies, sortDirection),
            MovieProperty.Genre => SortByGenre(movies, sortDirection),
            MovieProperty.IMDBRating => SortByIMDBRating(movies, sortDirection),
            MovieProperty.Metascore => SortByMetascore(movies, sortDirection), 
            MovieProperty.Director => SortByDirector(movies, sortDirection),
            MovieProperty.NoOfVotes => SortByNoofVotes(movies, sortDirection),
            MovieProperty.Gross => SortByGross(movies, sortDirection),
            _ => SortByIMDBRating(movies, sortDirection)
        };
        public static Dictionary<string, bool> GetGeneres(this List<Movie> movies) => string.Join("\"", movies.Select(x => x.Genre)).Split(["\"", ", "], StringSplitOptions.RemoveEmptyEntries).Distinct().ToDictionary(x => x, x => false);
        private static List<Movie> FilterByReleasedYear(List<Movie> movies, DateOnly min, DateOnly max) => movies.Where(x => x.ReleasedYear >= min && x.ReleasedYear <= max).ToList();
        private static List<Movie> FilterByRuntime(List<Movie> movies, TimeSpan min, TimeSpan max) => movies.Where(x => x.Runtime >= min && x.Runtime <= max).ToList();
        private static List<Movie> FilterByIMDBRating(List<Movie> movies, double min, double max) => movies.Where(x => x.IMDBRating >= min && x.IMDBRating <= max).ToList();
        private static List<Movie> FilterByMetascore(List<Movie> movies, int min, int max) => movies.Where(x => x.Metascore >= min && x.Metascore <= max).ToList();
        private static List<Movie> FilterByNoofVotes(List<Movie> movies, int min, int max) => movies.Where(x => x.NoofVotes >= min && x.NoofVotes <= max).ToList();
        private static List<Movie> FilterByGross(List<Movie> movies, int min, int max) => movies.Where(x => x.Gross >= min && x.Gross <= max).ToList();
        public static List<Movie> FilterByGenre(this List<Movie> movies, Dictionary<string, bool> genres) => movies.Where(m => genres.Where(g => g.Value).All(g => m.Genre!.Contains(g.Key))).ToList();
        private static List<Movie> SearchBySeriesTitle(List<Movie> movies, string searchTerm) => movies.Where(x => x.SeriesTitle!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        private static List<Movie> SearchByDirector(List<Movie> movies, string searchTerm) => movies.Where(x => x.Director!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        private static List<Movie> SearchByOverview(List<Movie> movies, string searchTerm) => movies.Where(x => x.Overview!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        private static List<Movie> SearchByStars(List<Movie> movies, string searchTerm) => movies.Where(x =>
            x.Star1!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase) ||
            x.Star2!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase) ||
            x.Star3!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase) ||
            x.Star4!.Contains(searchTerm.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        private static List<Movie> SortBySeriesTitle(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.SeriesTitle).ToList() : movies.OrderByDescending(x => x.SeriesTitle).ToList();
        private static List<Movie> SortByReleasedYear(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.ReleasedYear).ToList() : movies.OrderByDescending(x => x.ReleasedYear).ToList();
        private static List<Movie> SortByCertificate(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Certificate).ToList() : movies.OrderByDescending(x => x.Certificate).ToList();
        private static List<Movie> SortByRuntime(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Runtime).ToList() : movies.OrderByDescending(x => x.Runtime).ToList();
        private static List<Movie> SortByGenre(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Genre).ToList() : movies.OrderByDescending(x => x.Genre).ToList();
        private static List<Movie> SortByIMDBRating(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.IMDBRating).ToList() : movies.OrderByDescending(x => x.IMDBRating).ToList();
        private static List<Movie> SortByMetascore(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Metascore).ToList() : movies.OrderByDescending(x => x.Metascore).ToList();
        private static List<Movie> SortByDirector(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Director).ToList() : movies.OrderByDescending(x => x.Director).ToList();
        private static List<Movie> SortByNoofVotes(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.NoofVotes).ToList() : movies.OrderByDescending(x => x.NoofVotes).ToList();
        private static List<Movie> SortByGross(List<Movie> movies, bool sortDirection) => (sortDirection) ? movies.OrderBy(x => x.Gross).ToList() : movies.OrderByDescending(x => x.Gross).ToList();
    }
    public enum MovieProperty
    {
        SeriesTitle, ReleasedYear, Certificate, Runtime, Genre, IMDBRating,
        Overview, Metascore, Director, Star, NoOfVotes, Gross
    }
}
