using ExerciseCenter_API.Models.AppointmentsModels;
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
        public DbSet<Appointments> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appointments tablosu için birincil anahtar tanımlaması
            modelBuilder.Entity<Appointments>()
                .HasKey(a => a.AppointmentID);

            // Diğer varlıklar için yapılandırma (eğer varsa)...
        }
    }
}
