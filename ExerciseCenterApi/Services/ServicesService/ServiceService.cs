using AutoMapper;
using ExerciseCenter_API.Dtos.ServicesDtos;
using ExerciseCenter_API.Models.ServicesModels;
using ExerciseCenter_API.Repositories.ServicesRepository;

namespace ExerciseCenter_API.Services.ServicesService
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<ResultServiceDto>> GetAllServices()
        {
            var services = await _serviceRepository.GetAllServices();
            return _mapper.Map<IEnumerable<ResultServiceDto>>(services);
        }

        public async Task<ResultServiceDto> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetServiceById(id);
            return _mapper.Map<ResultServiceDto>(service);
        }

        public async Task<ResultServiceDto> CreateService(CreateServiceDto serviceCreateDto)
        {
            var service = _mapper.Map<Service>(serviceCreateDto);
            var createdService = await _serviceRepository.CreateService(service);
            return _mapper.Map<ResultServiceDto>(createdService);
        }

        public async Task UpdateService(int id, UpdateServiceDto serviceUpdateDto)
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
