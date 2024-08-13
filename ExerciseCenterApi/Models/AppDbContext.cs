using ExerciseCenter_API.Models.AppointmentsModels;
using ExerciseCenter_API.Models.AppRoleModels;
using ExerciseCenter_API.Models.AppUsersModels;
using ExerciseCenter_API.Models.BlogPostsModels;
using ExerciseCenter_API.Models.LoginModels;
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
        public DbSet<Login> Logins { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appointments tablosu için birincil anahtar tanımlaması
            modelBuilder.Entity<Appointments>().HasKey(a => a.AppointmentID);

            modelBuilder.Entity<AppUsers>().HasKey(u => u.UserId);
            modelBuilder.Entity<AppRole>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Login>().HasKey(r => r.UserID);
          

            // Diğer varlıklar için yapılandırma (eğer varsa)...
        }
    }
}
