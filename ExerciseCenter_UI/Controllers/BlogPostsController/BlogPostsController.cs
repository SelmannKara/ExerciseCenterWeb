using ExerciseCenter_UI.Models.BlogPostsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            var response = await _httpClient.GetStringAsync("https://localhost:44310/api/BlogPosts");
            var blogPosts = JsonConvert.DeserializeObject<List<BlogPostsViewModel>>(response);
            return View(blogPosts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:44310/api/BlogPosts", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44310/api/BlogPosts/{id}");
            var model = JsonConvert.DeserializeObject<BlogPostsViewModel>(response);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BlogPostsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"https://localhost:44310/api/BlogPosts/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:44310/api/BlogPosts/{id}");
            var model = JsonConvert.DeserializeObject<BlogPostsViewModel>(response);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44310/api/BlogPosts/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete", new { id });
        }
    }
}
