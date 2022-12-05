using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Repository.Interfacce;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Models.Repository.DbRepo
{
    public class DbMediaRepository : IFilmRepository
    {
        NetflixDbContext db;

        public DbMediaRepository(NetflixDbContext _db)
        {
            db = _db;
        }

        public List<Media> All()
        {
            return db.Films.ToList();
        }

        public void Create(Film film)
        {
            db.Add(film);
            db.SaveChanges();
        }

        public void Update(Film film)
        {
            db.Update(film);
            db.SaveChanges();
        }

        public void Delete(Film film)
        {
            db.Remove(film);
            db.SaveChanges();
        }
    }
}
