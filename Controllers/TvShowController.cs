using csharp_boolflix.Models.Repository.Interfacce;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class TvShowController : Controller
    {
        ITvShowRepository tvShowRepository;

        public TvShowController(ITvShowRepository _tvShowRepository)
        {
            tvShowRepository = _tvShowRepository;
        }

        public IActionResult Index()
        {
            List<Film> tvShowList = tvShowRepository.All();
            return View(tvShowList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvShow tvShow)
        {
            if (!ModelState.IsValid)
                return View();

            tvShowRepository.Create(tvShow);
            return RedirectToAction("Index");
        }
    }
}
