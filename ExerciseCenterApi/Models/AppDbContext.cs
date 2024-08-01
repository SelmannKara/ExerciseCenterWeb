using ExerciseCenter_API.Models.BlogPostsModels;
using ExerciseCenter_API.Models.ServicesModels;
using ExerciseCenter_API.Models.TestimonialsModels;
using ExerciseCenter_API.Models.WhoWeAreModels;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<WhoWeAre> WhoWeAre { get; set; }
        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
    }
}
