using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Areas.Identity.Data;
using csharp_boolflix.Models.Repository.Interfacce;
using csharp_boolflix.Models.Repository.DbRepo;


var builder = WebApplication.CreateBuilder(args);
//connessione db
var connectionString = builder.Configuration.GetConnectionString("NetflixDbContextConnection");
builder.Services.AddDbContext<NetflixDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NetflixDbContext>();

//varie injection
builder.Services.AddScoped<IFilmRepository, DbFilmRepository>();
builder.Services.AddScoped<ITvShowRepository, DbTvShowRepository>();
builder.Services.AddScoped<ICategoryRepository, DbCategoryRepository>();
builder.Services.AddScoped<IActorRepository, DbActorRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
