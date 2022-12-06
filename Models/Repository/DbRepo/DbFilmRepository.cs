using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Form;
using csharp_boolflix.Models.Repository.Interfacce;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.Repository.DbRepo
{
    public class DbFilmRepository : IFilmRepository
    {
        NetflixDbContext db;

        public DbFilmRepository(NetflixDbContext _db)
        {
            db = _db;
        }

        public List<Film> All()
        {
            List<Film> films = db.Films.ToList();
            
            return films;
        }

        public void Create(Film film, List<int> selectedCategories, List<int> selectedActors)
        {
            film.Categories = new List<Category>();

            foreach (int categoryId in selectedCategories)
            {
                Category category = db.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
                film.Categories.Add(category);
            }

            film.Actors = new List<Actor>();

            foreach (int actorId in selectedActors)
            {
                Actor actor = db.Actors.Where(a => a.Id == actorId).FirstOrDefault();
                film.Actors.Add(actor);
            }

            db.Add(film);

            db.SaveChanges();
        }

        

        public void Delete(Film film)
        {
            db.Remove(film);
            db.SaveChanges();
        }

        public Film GetById(int id)
        {
            //film con tutti i dati
            Film film = db.Films.Where(f => f.Id == id).Include(f => f.Categories).Include(f => f.Actors).FirstOrDefault();

            return film;
        }

        public void AddFilmRelations(MediaForm formData)
        {
            List<Category> categories = db.Categories.ToList();

            foreach (Category category in categories)
            {
                formData.Categories.Add(new SelectListItem(category.Title, category.Id.ToString()));
            }

            List<Actor> actors = db.Actors.ToList();

            foreach (Actor actor in actors)
            {
                string fullName = actor.Name + " " + actor.Surname;
                formData.Actors.Add(new SelectListItem(fullName, actor.Id.ToString()));
            }
        }

        public void AddFilmRelations(MediaForm formData, Film film)
        {
            List<Category> categories = db.Categories.ToList();

            foreach (Category category in categories)
            {
                formData.Categories.Add(new SelectListItem(category.Title, category.Id.ToString(), film.Categories.Any(c => c.Id == category.Id)));
            }

            List<Actor> actors = db.Actors.ToList();

            foreach (Actor actor in actors)
            {
                string fullName = actor.Name + " " + actor.Surname;
                formData.Actors.Add(new SelectListItem(
                    fullName,
                    actor.Id.ToString(),
                    film.Actors.Any(f => f.Id == actor.Id)
                    ));
            }
        }

        public void Update(Film film, Film formData, List<int> selectedCategories, List<int> selectedActors)
        {
            //film = film specifico con id
            film.Title = formData.Title;
            film.Description = formData.Description;
            film.ReleaseDate = formData.ReleaseDate;
            film.Duration = formData.Duration;
            //pulisco i dati vecchi inseriti dall'utente
            film.Categories.Clear();
            film.Actors.Clear();

            if (selectedActors == null)
            {
                selectedActors = new List<int>();
            }

            if (selectedCategories == null)
            {
                selectedCategories = new List<int>();
            }


            //modifica categorie nel db
            foreach (int categoryId in selectedCategories)
            {
                Category category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
                db.Categories.Add(category);
            }
            //modifica attori nel db
            foreach (int actorId in selectedActors)
            {
                Actor actor = db.Actors.FirstOrDefault(a => a.Id == actorId);
                db.Actors.Add(actor);
            }

            db.SaveChanges();
        }
    }
}
