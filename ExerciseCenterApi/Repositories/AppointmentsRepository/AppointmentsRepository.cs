using ExerciseCenter_API.Models.AppointmentsModels;
using ExerciseCenter_API.Models;
using Microsoft.EntityFrameworkCore;
using ExerciseCenter_API.Models.AppointmentsModels;

namespace ExerciseCenter_API.Repositories.AppointmentsRepository
{
    public class AppointmentsRepository:IAppointmentsRepository
    {
        private readonly AppDbContext _context;

        public AppointmentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointments>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointments> GetAppointmentsById(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Appointments> CreateAppointments(Appointments appointments)
        {
            _context.Appointments.Add(appointments);
            await _context.SaveChangesAsync();
            return appointments;
        }
    }
}
