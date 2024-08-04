using AutoMapper;
using ExerciseCenter_API.Dtos.AppointmentsDtos;
using ExerciseCenter_API.Repositories.AppointmentsRepository;

namespace ExerciseCenter_API.Services.AppointmentsService
{
    public class AppointmentsService:IAppointmentsService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentsRepository _testimonialsRepository;

        public AppointmentsService(IMapper mapper, IAppointmentsRepository testimonialsRepository)
        {
            _mapper = mapper;
            _testimonialsRepository = testimonialsRepository;
        }

        public async Task<IEnumerable<ResultAppointmentsDto>> GetAllAppointments()
        {
            var testimonials = await _testimonialsRepository.GetAllAppointments();
            return _mapper.Map<IEnumerable<ResultAppointmentsDto>>(testimonials);
        }

        public async Task<ResultAppointmentsDto> GetAppointmentsById(int id)
        {
            var testimonials = await _testimonialsRepository.GetAppointmentsById(id);
            return _mapper.Map<ResultAppointmentsDto>(testimonials);
        }
    }
}
