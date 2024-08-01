using ExerciseCenter_API.Dtos.ServicesDtos;

namespace ExerciseCenter_API.Services.ServicesService
{
    public interface IServiceService
    {
        Task<IEnumerable<ResultServiceDto>> GetAllServices();
        Task<ResultServiceDto> GetServiceById(int id);
        Task<ResultServiceDto> CreateService(CreateServiceDto serviceCreateDto);
        Task UpdateService(int id, UpdateServiceDto serviceUpdateDto);
        Task DeleteService(int id);
    }
}
