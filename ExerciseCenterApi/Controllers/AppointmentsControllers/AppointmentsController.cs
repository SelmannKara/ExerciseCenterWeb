using ExerciseCenter_API.Dtos.AppointmentsDtos;
using ExerciseCenter_API.Services.AppointmentsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_API.Controllers.AppointmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        // Tüm randevuları alır
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultAppointmentsDto>>> GetAppointments()
        {
            var appointments = await _appointmentsService.GetAllAppointments();
            return Ok(appointments);
        }

        // Belirli bir ID'ye göre randevu alır
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAppointmentsDto>> GetAppointmentById(int id)
        {
            var appointment = await _appointmentsService.GetAppointmentsById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<ResultAppointmentsDto>> CreateAppointments(CreateAppointmentsDto appointmentsCreateDto)
        {
            var appointments = await _appointmentsService.CreateAppointments(appointmentsCreateDto);
            return CreatedAtAction(nameof(GetAppointments), new { id = appointments.AppointmentID }, appointments);
        }

    }
}
