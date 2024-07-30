using ExerciseCenter_API.Models.ServicesModels;

namespace ExerciseCenter_API.Repositories.ServicesRepository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServices();
        Task<Service> GetServiceById(int id);
        Task<Service> CreateService(Service service);
        Task UpdateService(Service service);
        Task DeleteService(int id);
    }
}
