using ExerciseCenter_API.Dtos.LoginDtos;
using ExerciseCenter_API.Models;
using ExerciseCenter_API.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseCenter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            // Kullanıcıyı AppUsers tablosundan doğrula
            var user = await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password 
                /*&& u.UserId == loginDto.UserID*/);

            if (user != null)
            {
                // Kullanıcı doğrulandıysa token oluştur veya diğer işlemleri yap
                var model = new GetChecktAppUserViewModel
                {
                    Username = user.Username,
                    Id = user.UserId,
                    Role=user.Role
                };

                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return BadRequest("Başarısız giriş.");
            }
        }
    }
}
