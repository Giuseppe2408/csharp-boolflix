using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public class Film : Media
    {


        //eredita titolo e descrizione da media


        [Range(1, 1000, ErrorMessage = "il numero deve essere positivo")]
        public int? Duration { get; set; }
    }
}
