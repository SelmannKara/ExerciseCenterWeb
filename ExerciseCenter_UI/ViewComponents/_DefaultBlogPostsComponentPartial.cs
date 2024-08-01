using ExerciseCenter_UI.Models.BlogPostsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.ViewComponents
{
    public class _DefaultBlogPostsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBlogPostsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/BlogPosts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BlogPostsViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
