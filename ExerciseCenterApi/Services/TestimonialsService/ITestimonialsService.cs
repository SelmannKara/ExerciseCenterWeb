using ExerciseCenter_API.Dtos.TestimonialsDtos;

namespace ExerciseCenter_API.Services.TestimonialsService
{
    public interface ITestimonialsService
    {
        Task<IEnumerable<ResultTestimonialsDto>> GetAllTestimonials();
        Task<ResultTestimonialsDto> GetTestimonialsById(int id);
        Task<ResultTestimonialsDto> CreateTestimonials(CreateTestimonialsDto testimonialsCreateDto);
        Task UpdateTestimonials(int id, UpdateTestimonialsDto testimonialsUpdate);
        Task DeleteTestimonials(int id);
    }
}
