using ExerciseCenter_API.Models.TestimonialsModels;
using ExerciseCenter_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Repositories.TestimonialsRepository
{
    public class TestimonialsRepository:ITestimonialsRepository
    {
        private readonly AppDbContext _context;

        public TestimonialsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Testimonials>> GetAllTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        public async Task<Testimonials> GetTestimonialsById(int id)
        {
            return await _context.Testimonials.FindAsync(id);
        }

        public async Task<Testimonials> CreateTestimonials(Testimonials testimonials)
        {
            _context.Testimonials.Add(testimonials);
            await _context.SaveChangesAsync();
            return testimonials;
        }

        public async Task UpdateTestimonials(Testimonials testimonials)
        {
            _context.Entry(testimonials).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTestimonials(int id)
        {
            var testimonials = await _context.Testimonials.FindAsync(id);
            if (testimonials != null)
            {
                _context.Testimonials.Remove(testimonials);
                await _context.SaveChangesAsync();
            }
        }
    }
}
