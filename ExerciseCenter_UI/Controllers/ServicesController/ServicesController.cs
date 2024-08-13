using ExerciseCenter_UI.Dtos.ServicesDtos;
using ExerciseCenter_UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExerciseCenter_UI.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public ServicesController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IActionResult> Index()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;
            var token = User.Claims.FirstOrDefault(x => x.Type == "exercisecentertoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44310/api/Services");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateServices()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServiceDto createServicesDto)
        {
           
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createServicesDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:44310/api/Services", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    // API yanıtının içeriğini kontrol edelim
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent); // Bu satır hata ayıklamak için
                    return RedirectToAction("Index");
                }

            return View();
        }

        public async Task<IActionResult> DeleteServices(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44310/api/Services/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateServices(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44310/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(service);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServices(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44310/api/Services/{updateServiceDto.ID}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateServiceDto);
        }


    }
}
