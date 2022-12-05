using csharp_boolflix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Areas.Identity.Data;

public class NetflixDbContext : IdentityDbContext<IdentityUser>
{

    public DbSet<Film> Films { get; set; }

    public DbSet<TvShow> TvShows { get; set; }

    public DbSet<Actor> Actors { get; set; }

    public DbSet<Season> Season { get; set; }

    public DbSet<Episode> Episodes { get; set; }

    public DbSet<Category> Categories { get; set; }

    

    public NetflixDbContext(DbContextOptions<NetflixDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
