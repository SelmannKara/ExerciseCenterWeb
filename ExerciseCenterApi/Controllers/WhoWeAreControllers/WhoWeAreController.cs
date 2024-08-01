using ExerciseCenter_API.Dtos.WhoWeAreDtos;
using ExerciseCenter_API.Services.WhoWeAreService;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_API.Controllers.WhoWeAreControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreService _whoWeAreService;

        public WhoWeAreController(IWhoWeAreService whoWeAreService)
        {
            _whoWeAreService = whoWeAreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultWhoWeAreDto>>> GetWhoWeAre()
        {
            var whoWeAre = await _whoWeAreService.GetAllWhoWeAre();
            return Ok(whoWeAre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultWhoWeAreDto>> GetWhoWeAre(int id)
        {
            var whoWeAre = await _whoWeAreService.GetWhoWeAreById(id);
            if (whoWeAre == null)
            {
                return NotFound();
            }
            return Ok(whoWeAre);
        }

        [HttpPost]
        public async Task<ActionResult<ResultWhoWeAreDto>> CreateWhoWeAre(CreateWhoWeAreDto whoWeAreCreateDto)
        {
            var whoWeAre = await _whoWeAreService.CreateWhoWeAre(whoWeAreCreateDto);
            return CreatedAtAction(nameof(GetWhoWeAre), new { id = whoWeAre.ID }, whoWeAre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWhoWeAre(int id, UpdateWhoWeAreDto whoWeAreUpdateDto)
        {
            await _whoWeAreService.UpdateWhoWeAre(id, whoWeAreUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAre(int id)
        {
            await _whoWeAreService.DeleteWhoWeAre(id);
            return NoContent();
        }
    }
}
