using ExerciseCenter_UI.Dtos.AppointmentsDtos;
using ExerciseCenter_UI.Dtos.ServicesDtos;
using ExerciseCenter_UI.Models.AppointmentModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace ExerciseCenter_UI.Controllers.AppointmentController
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;

        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var appointmentResponse = await _httpClient.GetAsync("https://localhost:44310/api/Appointments");
            var serviceResponse = await _httpClient.GetAsync("https://localhost:44310/api/Services");

            if (appointmentResponse.IsSuccessStatusCode && serviceResponse.IsSuccessStatusCode)
            {
                var appointments = await appointmentResponse.Content.ReadFromJsonAsync<List<ResultAppointmentsDto>>();
                var services = await serviceResponse.Content.ReadFromJsonAsync<List<ResultServiceDto>>();

                var viewModel = new AppointmentsViewModel
                {
                    ResultAppointments = appointments ?? new List<ResultAppointmentsDto>(),
                    Services = services ?? new List<ResultServiceDto>(),
                    CreateAppointment = new CreateAppointmentsDto()
                };

                return View(viewModel);
            }
            else
            {
                // Hata durumunda bir hata mesajı veya farklı bir işlem yapabilirsiniz
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointments(AppointmentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // ModelState hatalarını toplayın
                var errorList = new List<string>();
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    var errors = value.Errors;
                    foreach (var error in errors)
                    {
                        errorList.Add($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                // Hataları View'e iletin
                ViewBag.ErrorMessages = errorList;

                // Hatalı durumunda mevcut sayfayı geri döndür
                return View("Index", model);
            }

            var jsonData = JsonConvert.SerializeObject(model.CreateAppointment);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:44310/api/Appointments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Başarılı olursa sayfayı yeniden yükleyin veya bir mesaj gösterin
                return RedirectToAction("Index");
            }

            // Başarısız olursa hata mesajlarını göster
            ModelState.AddModelError(string.Empty, "Randevu oluşturulurken bir hata oluştu.");
            return View("Index", model);
        }
    }
}
