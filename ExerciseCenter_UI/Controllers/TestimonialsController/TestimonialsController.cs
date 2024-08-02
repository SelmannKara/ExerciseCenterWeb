using ExerciseCenter_UI.Models.TestimonialsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.Controllers.TestimonialsController
{
    public class TestimonialsController : Controller
    {
        private readonly HttpClient _httpClient;

        public TestimonialsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7078/api/Testimonials");
            var testimonials = JsonConvert.DeserializeObject<List<TestimonialsViewModel>>(response);
            return View(testimonials);
        }
    }
}
