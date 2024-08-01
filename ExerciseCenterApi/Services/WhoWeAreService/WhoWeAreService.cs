using AutoMapper;
using ExerciseCenter_API.Dtos.WhoWeAreDtos;
using ExerciseCenter_API.Models.WhoWeAreModels;
using ExerciseCenter_API.Repositories.WhoWeAreRepository;

namespace ExerciseCenter_API.Services.WhoWeAreService
{
    public class WhoWeAreService : IWhoWeAreService
    {
        private readonly IMapper _mapper;
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreService(IMapper mapper, IWhoWeAreRepository whoWeAreRepository)
        {
            _mapper = mapper;
            _whoWeAreRepository = whoWeAreRepository;
        }

        public async Task<IEnumerable<ResultWhoWeAreDto>> GetAllWhoWeAre()
        {
            var whoWeAre = await _whoWeAreRepository.GetAllWhoWeAre();
            return _mapper.Map<IEnumerable<ResultWhoWeAreDto>>(whoWeAre);
        }

        public async Task<ResultWhoWeAreDto> GetWhoWeAreById(int id)
        {
            var whoWeAre = await _whoWeAreRepository.GetWhoWeAreById(id);
            return _mapper.Map<ResultWhoWeAreDto>(whoWeAre);
        }

        public async Task<ResultWhoWeAreDto> CreateWhoWeAre(CreateWhoWeAreDto whoWeAreCreateDto)
        {
            var whoWeAre = _mapper.Map<WhoWeAre>(whoWeAreCreateDto);
            var createdWhoWeAre = await _whoWeAreRepository.CreateWhoWeAre(whoWeAre);
            return _mapper.Map<ResultWhoWeAreDto>(createdWhoWeAre);
        }

        public async Task UpdateWhoWeAre(int id, UpdateWhoWeAreDto whoWeAreUpdateDto)
        {
            var whoWeAre = await _whoWeAreRepository.GetWhoWeAreById(id);
            _mapper.Map(whoWeAreUpdateDto, whoWeAre);
            await _whoWeAreRepository.UpdateWhoWeAre(whoWeAre);
        }

        public async Task DeleteWhoWeAre(int id)
        {
            await _whoWeAreRepository.DeleteWhoWeAre(id);
        }
    }
}
