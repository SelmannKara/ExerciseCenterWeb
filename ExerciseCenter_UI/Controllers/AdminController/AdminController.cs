using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_UI.Controllers.AdminController
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
