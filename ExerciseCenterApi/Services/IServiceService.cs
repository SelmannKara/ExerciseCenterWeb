using ExerciseCenter_API.Dtos;

namespace ExerciseCenter_API.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServices();
        Task<ServiceDto> GetServiceById(int id);
        Task<ServiceDto> CreateService(ServiceCreateDto serviceCreateDto);
        Task UpdateService(int id, ServiceUpdateDto serviceUpdateDto);
        Task DeleteService(int id);
    }
}
