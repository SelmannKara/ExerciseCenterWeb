using AutoMapper;
using ExerciseCenter_API.Dtos.TestimonialsDtos;
using ExerciseCenter_API.Models.TestimonialsModels;
using ExerciseCenter_API.Repositories.TestimonialsRepository;

namespace ExerciseCenter_API.Services.TestimonialsService
{
    public class TestimonialsService:ITestimonialsService
    {
        private readonly IMapper _mapper;
        private readonly ITestimonialsRepository _testimonialsRepository;

        public TestimonialsService(IMapper mapper, ITestimonialsRepository testimonialsRepository)
        {
            _mapper = mapper;
            _testimonialsRepository = testimonialsRepository;
        }

        public async Task<IEnumerable<ResultTestimonialsDto>> GetAllTestimonials()
        {
            var testimonials = await _testimonialsRepository.GetAllTestimonials();
            return _mapper.Map<IEnumerable<ResultTestimonialsDto>>(testimonials);
        }

        public async Task<ResultTestimonialsDto> GetTestimonialsById(int id)
        {
            var testimonials = await _testimonialsRepository.GetTestimonialsById(id);
            return _mapper.Map<ResultTestimonialsDto>(testimonials);
        }

        public async Task<ResultTestimonialsDto> CreateTestimonials(CreateTestimonialsDto testimonialsCreateDto)
        {
            var testimonials = _mapper.Map<Testimonials>(testimonialsCreateDto);
            var createdTestimonials = await _testimonialsRepository.CreateTestimonials(testimonials);
            return _mapper.Map<ResultTestimonialsDto>(createdTestimonials);
        }

        public async Task UpdateTestimonials(int id, UpdateTestimonialsDto testimonialsUpdateDto)
        {
            var testimonials = await _testimonialsRepository.GetTestimonialsById(id);
            _mapper.Map(testimonialsUpdateDto, testimonials);
            await _testimonialsRepository.UpdateTestimonials(testimonials);
        }

        public async Task DeleteTestimonials(int id)
        {
            await _testimonialsRepository.DeleteTestimonials(id);
        }
    }
}
