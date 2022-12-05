namespace csharp_boolflix.Models
{
    public class Episode
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        //relazione 1 a molti tra stagioni e ep
        public int SeasonId { get; set; }

        public Season Season { get; set; }
    }
}
