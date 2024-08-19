using ExerciseCenter_API.Models.AppointmentsModels;
using ExerciseCenter_API.Models.AppointmentsModels;
using ExerciseCenter_API.Models.BlogPostsModels;

namespace ExerciseCenter_API.Repositories.AppointmentsRepository
{
    public interface IAppointmentsRepository
    {
        Task<IEnumerable<Appointments>> GetAllAppointments();
        Task<Appointments> GetAppointmentsById(int id);
        Task<Appointments> CreateAppointments(Appointments appointments);

        Task UpdateAppointments(Appointments appointments);
        Task DeleteAppointments(int id);
    }
}
