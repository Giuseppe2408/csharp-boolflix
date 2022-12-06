using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Repository.Interfacce;

namespace csharp_boolflix.Models.Repository.DbRepo
{
    public class DbCategoryRepository : ICategoryRepository
    {
        NetflixDbContext db;

        public DbCategoryRepository(NetflixDbContext _db)
        {
            db = _db;
        }

        public List<Category> All()
        {
            List<Category> category = db.Categories.ToList();

            return category;
        }

        public void Create(Category category)
        {
            db.Add(category);
            db.SaveChanges();
        }
    }
}
