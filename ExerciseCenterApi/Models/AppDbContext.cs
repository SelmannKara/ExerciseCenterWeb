using ExerciseCenter_API.Models.ServicesModels;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
    }
}
