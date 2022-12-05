using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Repository.Interfacce;

namespace csharp_boolflix.Models.Repository.DbRepo
{
    public class DbTvShowRepository : ITvShowRepository
    {
        NetflixDbContext db;

        public DbTvShowRepository(NetflixDbContext _db)
        {
            db = _db;
        }

        public List<TvShow> All()
        {
            List<TvShow> tvShows = db.TvShows.ToList();

            return tvShows;
        }

        public void Create(TvShow tvShow)
        {
            db.TvShows.Add(tvShow);
            db.SaveChanges();
        }

        public void Update(TvShow tvShow)
        {
            db.Update(tvShow);
            db.SaveChanges();
        }

        public void Delete(TvShow tvShow)
        {
            db.Remove(tvShow);
            db.SaveChanges();
        }
    }
}
