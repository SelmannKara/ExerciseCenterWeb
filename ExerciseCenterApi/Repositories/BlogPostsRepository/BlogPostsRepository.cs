using ExerciseCenter_API.Models.BlogPostsModels;
using ExerciseCenter_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Repositories.BlogPostsRepository
{
    public class BlogPostsRepository:IBlogPostsRepository
    {
        private readonly AppDbContext _context;

        public BlogPostsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPosts>> GetAllBlogPosts()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<BlogPosts> GetBlogPostsById(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPosts> CreateBlogPosts(BlogPosts blogPosts)
        {
            _context.BlogPosts.Add(blogPosts);
            await _context.SaveChangesAsync();
            return blogPosts;
        }

        public async Task UpdateBlogPosts(BlogPosts blogPosts)
        {
            _context.Entry(blogPosts).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogPosts(int id)
        {
            var blogPosts = await _context.BlogPosts.FindAsync(id);
            if (blogPosts != null)
            {
                _context.BlogPosts.Remove(blogPosts);
                await _context.SaveChangesAsync();
            }
        }
    }
}
