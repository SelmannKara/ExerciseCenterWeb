using ExerciseCenter_API.Dtos.BlogPostsDtos;

namespace ExerciseCenter_API.Services.BlogPostsService
{
    public interface IBlogPostsService
    {
        Task<IEnumerable<ResultBlogPostsDto>> GetAllBlogPosts();
        Task<ResultBlogPostsDto> GetBlogPostsById(int id);
        Task<ResultBlogPostsDto> CreateBlogPosts(CreateBlogPostsDto createBlogPostsDto);
        Task UpdateBlogPosts(int id, UpdateBlogPostsDto updateBlogPostsDto);
        Task DeleteBlogPosts(int id);
    }
}
