using csharp_boolflix.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            MediaForm mediaForm = new MediaForm();
            return View(mediaForm);
        }
    }
}
