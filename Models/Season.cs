namespace csharp_boolflix.Models
{
    public class Season
    {
        public int Id { get; set; }

        public int NumberSeason { get; set; }

        public int TvShowId { get; set; }

        public TvShow TvShow { get; set; }
    }
}
