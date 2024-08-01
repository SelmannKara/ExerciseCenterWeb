using ExerciseCenter_API.Models.WhoWeAreModels;

namespace ExerciseCenter_API.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<IEnumerable<WhoWeAre>> GetAllWhoWeAre();
        Task<WhoWeAre> GetWhoWeAreById(int id);
        Task<WhoWeAre> CreateWhoWeAre(WhoWeAre whoWeAre);
        Task UpdateWhoWeAre(WhoWeAre whoWeAre);
        Task DeleteWhoWeAre(int id);
    }
}
