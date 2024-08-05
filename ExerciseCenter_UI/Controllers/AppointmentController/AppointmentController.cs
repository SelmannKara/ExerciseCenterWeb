using ExerciseCenter_UI.Dtos.AppointmentsDtos;
using ExerciseCenter_UI.Dtos.ServicesDtos;
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

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            // API'dan verileri alıyoruz
            var response = await _httpClient.GetAsync("https://localhost:44310/api/Appointments");
            if (response.IsSuccessStatusCode)
            {
                var appointmentDates = await response.Content.ReadFromJsonAsync<List<ResultAppointmentsDto>>();

                if (appointmentDates == null || !appointmentDates.Any())
                {
                    // API'dan veri alınamadıysa veya boşsa, bir hata döndürün veya boş bir liste gönderin
                    return View(new List<ResultAppointmentsDto>());
                }

                // Gelen veriyi view'e gönderiyoruz
                return View(appointmentDates);
            }
            else
            {
                // Hata durumunda bir hata mesajı veya farklı bir işlem yapabilirsiniz
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentsDto appointment)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44310/api/Appointments", appointment);
                if (response.IsSuccessStatusCode)
                {
                    // Başarılı olduğunda bir başarı sayfasına yönlendirebilirsiniz veya başka bir işlem yapabilirsiniz
                    return RedirectToAction("Success");
                }
                else
                {
                    // Hata durumunda hata sayfasına yönlendirme yapılabilir
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
