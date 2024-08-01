using ExerciseCenter_API.Dtos.ServicesDtos;
using ExerciseCenter_API.Services.ServicesService;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseCenter_API.Controllers.ServicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultServiceDto>>> GetServices()
        {
            var services = await _serviceService.GetAllServices();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultServiceDto>> GetService(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<ResultServiceDto>> CreateService(CreateServiceDto serviceCreateDto)
        {
            var service = await _serviceService.CreateService(serviceCreateDto);
            return CreatedAtAction(nameof(GetService), new { id = service.ServiceID }, service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, UpdateServiceDto serviceUpdateDto)
        {
            await _serviceService.UpdateService(id, serviceUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteService(id);
            return NoContent();
        }
    }
}
