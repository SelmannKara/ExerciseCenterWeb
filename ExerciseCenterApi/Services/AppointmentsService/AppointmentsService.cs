using AutoMapper;
using ExerciseCenter_API.Dtos.AppointmentsDtos;
using ExerciseCenter_API.Dtos.AppointmentsDtos;
using ExerciseCenter_API.Models.AppointmentsModels;
using ExerciseCenter_API.Repositories.AppointmentsRepository;

namespace ExerciseCenter_API.Services.AppointmentsService
{
    public class AppointmentsService:IAppointmentsService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsService(IMapper mapper, IAppointmentsRepository appointmentsRepository)
        {
            _mapper = mapper;
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<IEnumerable<ResultAppointmentsDto>> GetAllAppointments()
        {
            var appointments = await _appointmentsRepository.GetAllAppointments();
            return _mapper.Map<IEnumerable<ResultAppointmentsDto>>(appointments);
        }

        public async Task<ResultAppointmentsDto> GetAppointmentsById(int id)
        {
            var appointments = await _appointmentsRepository.GetAppointmentsById(id);
            return _mapper.Map<ResultAppointmentsDto>(appointments);
        }
        public async Task<ResultAppointmentsDto> CreateAppointments(CreateAppointmentsDto appointmentsCreateDto)
        {
            var appointments = _mapper.Map<Appointments>(appointmentsCreateDto);
            var createdAppointments = await _appointmentsRepository.CreateAppointments(appointments);
            return _mapper.Map<ResultAppointmentsDto>(createdAppointments);
        }
    }
}
