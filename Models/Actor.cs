namespace csharp_boolflix.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        //relazione molti a molti con i vari contenuti
        public List<Media> Medias { get; set; }
    }
}
