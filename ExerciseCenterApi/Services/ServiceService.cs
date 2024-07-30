using AutoMapper;
using ExerciseCenter_API.Dtos;
using ExerciseCenter_API.Models.ServicesModels;
using ExerciseCenter_API.Repositories.ServicesRepository;

namespace ExerciseCenter_API.Services
{
    public class ServiceService:IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServices()
        {
            var services = await _serviceRepository.GetAllServices();
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetServiceById(id);
            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<ServiceDto> CreateService(ServiceCreateDto serviceCreateDto)
        {
            var service = _mapper.Map<Service>(serviceCreateDto);
            var createdService = await _serviceRepository.CreateService(service);
            return _mapper.Map<ServiceDto>(createdService);
        }

        public async Task UpdateService(int id, ServiceUpdateDto serviceUpdateDto)
        {
            var service = await _serviceRepository.GetServiceById(id);
            _mapper.Map(serviceUpdateDto, service);
            await _serviceRepository.UpdateService(service);
        }

        public async Task DeleteService(int id)
        {
            await _serviceRepository.DeleteService(id);
        }
    }
}
