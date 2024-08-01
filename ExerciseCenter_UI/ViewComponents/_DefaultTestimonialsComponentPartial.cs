using ExerciseCenter_UI.Models.TestimonialsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.ViewComponents
{
    public class _DefaultTestimonialsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialsViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
