using ExerciseCenter_UI.Dtos.BlogPostsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExerciseCenter_UI.Controllers.BlogPostsController
{
    public class BlogPostsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogPostsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/BlogPosts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogPostsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBlogPosts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPosts(CreateBlogPostsDto createBlogPostsDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBlogPostsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44310/api/BlogPosts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // API yanıtının içeriğini kontrol edelim
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Bu satır hata ayıklamak için
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteBlogPosts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44310/api/BlogPosts/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlogPosts(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44310/api/BlogPosts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateBlogPostsDto>(jsonData);
                return View(service);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogPosts(UpdateBlogPostsDto updateBlogPostsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogPostsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44310/api/BlogPosts/{updateBlogPostsDto.ID}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateBlogPostsDto);
        }
    }
}
