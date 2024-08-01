using ExerciseCenter_API.Models;
using ExerciseCenter_API.Models.WhoWeAreModels;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly AppDbContext _context;

        public WhoWeAreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WhoWeAre>> GetAllWhoWeAre()
        {
            return await _context.WhoWeAre.ToListAsync();
        }

        public async Task<WhoWeAre> GetWhoWeAreById(int id)
        {
            return await _context.WhoWeAre.FindAsync(id);
        }

        public async Task<WhoWeAre> CreateWhoWeAre(WhoWeAre whoWeAre)
        {
            _context.WhoWeAre.Add(whoWeAre);
            await _context.SaveChangesAsync();
            return whoWeAre;
        }

        public async Task UpdateWhoWeAre(WhoWeAre whoWeAre)
        {
            _context.Entry(whoWeAre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWhoWeAre(int id)
        {
            var whoWeAre = await _context.WhoWeAre.FindAsync(id);
            if (whoWeAre != null)
            {
                _context.WhoWeAre.Remove(whoWeAre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
