using ExerciseCenter_API.Dtos.AppointmentsDtos;

namespace ExerciseCenter_API.Services.AppointmentsService
{
    public interface IAppointmentsService
    {
        Task<IEnumerable<ResultAppointmentsDto>> GetAllAppointments();
        Task<ResultAppointmentsDto> GetAppointmentsById(int id);
        Task<ResultAppointmentsDto> CreateAppointments(CreateAppointmentsDto createAppointmentsDto);
        Task UpdateAppointments(int id, UpdateAppointmentsDto updateAppointmentsDto);
        Task DeleteAppointments(int id);
    }
}
