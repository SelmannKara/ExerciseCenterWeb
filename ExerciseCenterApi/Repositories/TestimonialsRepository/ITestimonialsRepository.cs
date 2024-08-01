using ExerciseCenter_API.Models.TestimonialsModels;

namespace ExerciseCenter_API.Repositories.TestimonialsRepository
{
    public interface ITestimonialsRepository
    {
        Task<IEnumerable<Testimonials>> GetAllTestimonials();
        Task<Testimonials> GetTestimonialsById(int id);
        Task<Testimonials> CreateTestimonials(Testimonials testimonials);
        Task UpdateTestimonials(Testimonials testimonials);
        Task DeleteTestimonials(int id);
    }
}
