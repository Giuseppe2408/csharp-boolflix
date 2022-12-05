using csharp_boolflix.Models.Form;
using csharp_boolflix.Models.Repository.Interfacce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IFilmRepository filmRepository;

        ITvShowRepository tvShowRepository;

        public AdminController(IFilmRepository _filmRepository, ITvShowRepository _tvShowRepository)
        {
            filmRepository = _filmRepository;
            tvShowRepository = _tvShowRepository;
        }   

        public IActionResult Index()
        {
            MediaForm mediaForm = new MediaForm();
            mediaForm.Films = filmRepository.All();
            mediaForm.TvShows = tvShowRepository.All();
            return View(mediaForm);
        }
    }
}
