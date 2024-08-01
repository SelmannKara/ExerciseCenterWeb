using ExerciseCenter_API.Models.BlogPostsModels;

namespace ExerciseCenter_API.Repositories.BlogPostsRepository
{
    public interface IBlogPostsRepository
    {
        Task<IEnumerable<BlogPosts>> GetAllBlogPosts();
        Task<BlogPosts> GetBlogPostsById(int id);
        Task<BlogPosts> CreateBlogPosts(BlogPosts blogPosts);
        Task UpdateBlogPosts(BlogPosts blogPosts);
        Task DeleteBlogPosts(int id);
    }
}
