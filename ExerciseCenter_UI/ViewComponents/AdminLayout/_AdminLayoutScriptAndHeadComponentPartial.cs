using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_UI.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptAndHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
