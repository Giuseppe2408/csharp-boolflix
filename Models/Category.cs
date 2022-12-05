namespace csharp_boolflix.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //relazione con media 
        public List<Media> Medias { get; set; }
    }
}
