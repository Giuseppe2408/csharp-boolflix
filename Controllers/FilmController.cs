using csharp_boolflix.Models;
using csharp_boolflix.Models.Form;
using csharp_boolflix.Models.Repository.Interfacce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        IFilmRepository filmRepository;

        ICategoryRepository categoryRepository;

        IActorRepository actorRepository;

        public FilmController(IFilmRepository _filmRepository, ICategoryRepository _categoryRepository, IActorRepository _actorRepository)
        {
            filmRepository = _filmRepository;
            categoryRepository = _categoryRepository;
            actorRepository = _actorRepository;
        }

        public IActionResult Index()
        {
            List<Film> filmList = filmRepository.All();
            return View(filmList);
        }

        public IActionResult Create()
        {
            MediaForm formData = new MediaForm();
            formData.Categories = new List<SelectListItem>();
            formData.Actors = new List<SelectListItem>();

            filmRepository.AddFilmRelations(formData);

            return View(formData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MediaForm formData)
        {
            if (!ModelState.IsValid)
            {
                    formData.Categories = new List<SelectListItem>();

                    filmRepository.AddFilmRelations(formData);



                return View();
            }

            filmRepository.Create(formData.Film, formData.SelectedCategories, formData.SelectedActors);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Detail(int id)
        {
            Film film = filmRepository.GetById(id);
            return View(film);
        }

        public IActionResult Update(int id)
        {
            Film film = filmRepository.GetById(id);

            MediaForm formData = new MediaForm();
            formData.Film = film;
            formData.Categories = new List<SelectListItem>();
            formData.Actors = new List<SelectListItem>();

            filmRepository.AddFilmRelations(formData, film);

            
            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MediaForm formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Film.Id = id;
                formData.Categories = new List<SelectListItem>();
                formData.Actors = new List<SelectListItem>();

                filmRepository.AddFilmRelations(formData);

                return View(formData);
            }

            Film filmItem = filmRepository.GetById(id);

            filmRepository.Update(filmItem, formData.Film, formData.SelectedCategories, formData.SelectedActors);


            return RedirectToAction("Index", "Admin");
        }
    }


   
}
