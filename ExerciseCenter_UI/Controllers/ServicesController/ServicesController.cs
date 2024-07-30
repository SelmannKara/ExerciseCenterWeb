using ExerciseCenter_UI.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.Controllers.ServicesController
{
    public class ServicesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ServicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7078/api/services");
            var services = JsonConvert.DeserializeObject<List<ServiceViewModel>>(response);
            return View(services);
        }
    }
}
