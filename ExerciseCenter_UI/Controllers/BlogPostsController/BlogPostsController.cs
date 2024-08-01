using ExerciseCenter_UI.Models.BlogPostsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseCenter_UI.Controllers.BlogPostsController
{
    public class BlogPostsController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogPostsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7078/api/BlogPosts");
            var blogPosts = JsonConvert.DeserializeObject<List<BlogPostsViewModel>>(response);
            return View(blogPosts);
        }
    }
}
