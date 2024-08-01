using ExerciseCenter_API.Dtos.WhoWeAreDtos;

namespace ExerciseCenter_API.Services.WhoWeAreService
{
    public interface IWhoWeAreService
    {
        Task<IEnumerable<ResultWhoWeAreDto>> GetAllWhoWeAre();
        Task<ResultWhoWeAreDto> GetWhoWeAreById(int id);
        Task<ResultWhoWeAreDto> CreateWhoWeAre(CreateWhoWeAreDto whoWeAreCreateDto);
        Task UpdateWhoWeAre(int id, UpdateWhoWeAreDto whoWeAreUpdate);
        Task DeleteWhoWeAre(int id);
    }
}
