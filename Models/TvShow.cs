using System.Collections.Generic;

namespace csharp_boolflix.Models
{
    public class TvShow : Media
    {
        

        //eredita titolo e descrizione da media 

        //relazione con episodi
        public List<Season> Seasons { get; set; }

      
    }
}
