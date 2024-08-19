using ExerciseCenter_UI.Dtos.AppointmentsDtos;
using ExerciseCenter_UI.Dtos.ServicesDtos;
using ExerciseCenter_UI.Models.AppointmentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace ExerciseCenter_UI.Controllers.AppointmentController
{
    public class AdminAppointmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44310/api/Appointments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppointmentsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAppointments()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointments(CreateAppointmentsDto createAppointmentsDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAppointmentsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44310/api/Appointments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // API yanıtının içeriğini kontrol edelim
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Bu satır hata ayıklamak için
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteAppointments(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync($"https://localhost:44310/api/Appointments/{id}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAppointments(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44310/api/Appointments/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateAppointmentsDto>(jsonData);
                return View(service);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAppointments(UpdateAppointmentsDto updateAppointmentsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAppointmentsDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44310/api/Appointments/{updateAppointmentsDto.AppointmentID}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateAppointmentsDto);
        }
    }
}
