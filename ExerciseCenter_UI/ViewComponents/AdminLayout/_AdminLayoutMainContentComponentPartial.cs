using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutMainContentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
