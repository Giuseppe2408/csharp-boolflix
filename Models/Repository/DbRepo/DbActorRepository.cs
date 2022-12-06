using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Repository.Interfacce;

namespace csharp_boolflix.Models.Repository.DbRepo
{
    public class DbActorRepository : IActorRepository
    {
        NetflixDbContext db;

        public DbActorRepository(NetflixDbContext _db)
        {
            db = _db;
        }

        public List<Actor> All()
        {
            List<Actor> actors = db.Actors.ToList();

            return actors;
        }

        public void Create(Actor actor)
        {
            db.Add(actor);
            db.SaveChanges();
        }
    }
}
