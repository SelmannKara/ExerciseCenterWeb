using ExerciseCenter_UI.Dtos.AppointmentsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ExerciseCenter_UI.Controllers.AppointmentController
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _httpClient;

        public AppointmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Randevu oluşturma sayfası
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44310/api/Appointments");
            if (response.IsSuccessStatusCode)
            {
                var appointmentDates = await response.Content.ReadFromJsonAsync<List<ResultAppointmentsDto>>();
                return View(appointmentDates);
            }
            else
            {
                // Hata durumunda boş bir liste döndürüyoruz
                return View(new List<ResultAppointmentsDto>());
            }
        }

        // Randevu oluşturma işlemi
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentsDto appointment)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44310/api/Appointments", appointment);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    return View("Error");
                }
            }
            return View(appointment);
        }

        // Başarılı randevu ekleme sonrası yönlendirme için bir Success action metodu
        public IActionResult Success()
        {
            return View();
        }
    }
}
