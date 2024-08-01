
using ExerciseCenter_UI.Models.WhoWeAreModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.ViewComponents
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/WhoWeAre");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WhoWeAreViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
