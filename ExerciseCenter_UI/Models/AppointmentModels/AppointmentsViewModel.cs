using ExerciseCenter_UI.Dtos.AppointmentsDtos;
using ExerciseCenter_UI.Dtos.ServicesDtos;

namespace ExerciseCenter_UI.Models.AppointmentModels
{
    public class AppointmentsViewModel
    {
        public List<ResultAppointmentsDto> ResultAppointments { get; set; } = new List<ResultAppointmentsDto>();
        public List<ResultServiceDto> Services { get; set; } = new List<ResultServiceDto>();
        public CreateAppointmentsDto CreateAppointment { get; set; } = new CreateAppointmentsDto();
    }
}
