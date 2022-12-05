using csharp_boolflix.Models;
using csharp_boolflix.Models.Repository.Interfacce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        IFilmRepository filmRepository;

        public FilmController(IFilmRepository _filmRepository)
        {
            filmRepository = _filmRepository;
        }

        public IActionResult Index()
        {
            List<Film> filmList = filmRepository.All();
            return View(filmList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Film film)
        {
            if (!ModelState.IsValid)
                return View();

            filmRepository.Create(film);
            return RedirectToAction("Index");
        }
    }
}
