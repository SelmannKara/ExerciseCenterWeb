using ExerciseCenter_UI.Dtos.TestimonialsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExerciseCenter_UI.Controllers.TestimonialsController
{
    public class TestimonialsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TestimonialsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateTestimonials()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonials(CreateTestimonialsDto createTestimonialssDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialssDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44310/api/Testimonials", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // API yanıtının içeriğini kontrol edelim
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Bu satır hata ayıklamak için
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteTestimonials(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44310/api/Testimonials/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonials(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44310/api/Testimonials/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateTestimonialsDto>(jsonData);
                return View(service);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonials(UpdateTestimonialsDto updateTestimonialsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44310/api/Testimonials/{updateTestimonialsDto.ID}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateTestimonialsDto);
        }
    }
}
