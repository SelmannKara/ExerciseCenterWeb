using ExerciseCenter_API.Dtos.TestimonialsDtos;
using ExerciseCenter_API.Services.TestimonialsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_API.Controllers.TestimonialsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultTestimonialsDto>>> GetTestimonials()
        {
            var testimonials = await _testimonialsService.GetAllTestimonials();
            return Ok(testimonials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultTestimonialsDto>> GetTestimonials(int id)
        {
            var testimonials = await _testimonialsService.GetTestimonialsById(id);
            if (testimonials == null)
            {
                return NotFound();
            }
            return Ok(testimonials);
        }

        [HttpPost]
        public async Task<ActionResult<ResultTestimonialsDto>> CreateTestimonials(CreateTestimonialsDto testimonialsCreateDto)
        {
            var testimonials = await _testimonialsService.CreateTestimonials(testimonialsCreateDto);
            return CreatedAtAction(nameof(GetTestimonials), new { id = testimonials.ID }, testimonials);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonials(int id, UpdateTestimonialsDto testimonialsUpdateDto)
        {
            await _testimonialsService.UpdateTestimonials(id, testimonialsUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonials(int id)
        {
            await _testimonialsService.DeleteTestimonials(id);
            return NoContent();
        }
    }
}
