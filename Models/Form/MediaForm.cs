using csharp_boolflix.Models.Repository.Interfacce;

namespace csharp_boolflix.Models.Form
{
    public class MediaForm
    {
        
        public List<Media> Medias { get; set; }
       
        public List<Film> Films { get; set; }

        public List<TvShow> TvShows { get; set; }
    }
}
