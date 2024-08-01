using AutoMapper;
using ExerciseCenter_API.Dtos.BlogPostsDtos;
using ExerciseCenter_API.Models.BlogPostsModels;
using ExerciseCenter_API.Repositories.BlogPostsRepository;

namespace ExerciseCenter_API.Services.BlogPostsService
{
    public class BlogPostsService:IBlogPostsService
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostsRepository _blogPostsRepository;

        public BlogPostsService(IMapper mapper, IBlogPostsRepository blogPostsRepository)
        {
            _mapper = mapper;
            _blogPostsRepository = blogPostsRepository;
        }

        public async Task<IEnumerable<ResultBlogPostsDto>> GetAllBlogPosts()
        {
            var blogPosts = await _blogPostsRepository.GetAllBlogPosts();
            return _mapper.Map<IEnumerable<ResultBlogPostsDto>>(blogPosts);
        }

        public async Task<ResultBlogPostsDto> GetBlogPostsById(int id)
        {
            var blogPosts = await _blogPostsRepository.GetBlogPostsById(id);
            return _mapper.Map<ResultBlogPostsDto>(blogPosts);
        }

        public async Task<ResultBlogPostsDto> CreateBlogPosts(CreateBlogPostsDto blogPostsCreateDto)
        {
            var blogPosts = _mapper.Map<BlogPosts>(blogPostsCreateDto);
            var createdBlogPosts = await _blogPostsRepository.CreateBlogPosts(blogPosts);
            return _mapper.Map<ResultBlogPostsDto>(createdBlogPosts);
        }

        public async Task UpdateBlogPosts(int id, UpdateBlogPostsDto blogPostsUpdateDto)
        {
            var blogPosts = await _blogPostsRepository.GetBlogPostsById(id);
            _mapper.Map(blogPostsUpdateDto, blogPosts);
            await _blogPostsRepository.UpdateBlogPosts(blogPosts);
        }

        public async Task DeleteBlogPosts(int id)
        {
            await _blogPostsRepository.DeleteBlogPosts(id);
        }
    }
}
