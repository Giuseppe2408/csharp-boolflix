using System.ComponentModel.DataAnnotations;

namespace csharp_boolflix.Models
{
    public abstract class Media
    {
        public int Id { get; set; }

        public string Title { get; set; }

        
        public string Description { get; set; }


        // relazione con attori
        public List<Actor>? Actors { get; set; }


        //rel category
        public List<Category>? Categories { get; set; }

      
        
    }
}
