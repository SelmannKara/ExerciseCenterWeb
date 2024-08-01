using ExerciseCenter_API.Dtos.BlogPostsDtos;
using ExerciseCenter_API.Services.BlogPostsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_API.Controllers.BlogPostsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostsService _blogPostsService;

        public BlogPostsController(IBlogPostsService blogPostsService)
        {
            _blogPostsService = blogPostsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultBlogPostsDto>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostsService.GetAllBlogPosts();
            return Ok(blogPosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultBlogPostsDto>> GetBlogPosts(int id)
        {
            var blogPosts = await _blogPostsService.GetBlogPostsById(id);
            if (blogPosts == null)
            {
                return NotFound();
            }
            return Ok(blogPosts);
        }

        [HttpPost]
        public async Task<ActionResult<ResultBlogPostsDto>> CreateBlogPosts(CreateBlogPostsDto blogPostsCreateDto)
        {
            var blogPosts = await _blogPostsService.CreateBlogPosts(blogPostsCreateDto);
            return CreatedAtAction(nameof(GetBlogPosts), new { id = blogPosts.ID }, blogPosts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPosts(int id, UpdateBlogPostsDto blogPostsUpdateDto)
        {
            await _blogPostsService.UpdateBlogPosts(id, blogPostsUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPosts(int id)
        {
            await _blogPostsService.DeleteBlogPosts(id);
            return NoContent();
        }
    }
}
