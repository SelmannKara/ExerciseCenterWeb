using ExerciseCenter_UI.Models.WhoWeAreModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.Controllers.WhoWeAreController
{
    public class WhoWeAreController : Controller
    {
        private readonly HttpClient _httpClient;

        public WhoWeAreController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7078/api/WhoWeAre");
            var whoWeAre = JsonConvert.DeserializeObject<List<WhoWeAreViewModel>>(response);
            return View(whoWeAre);
        }
    }
}
