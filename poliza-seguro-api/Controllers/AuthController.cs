using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.EFcontexts;
using Entities;
using Entities.Services;

namespace poliza_seguro_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtServices _jwtServices;

        public AuthController(AppDbContext context, JwtServices jwtServices)
        {
            _context = context;
            _jwtServices = jwtServices;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> GetUserLogin([FromBody] Login login)
        {
            try
            {
                string password = GetHasPassword(login.Password);
                var existingUser = await _context.Users.Include(u => u.Rol)
                    .FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == password);
                if (existingUser == null)
                {
                    return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
                }
                var token = _jwtServices.GenerateToken(existingUser.Email, existingUser.Rol.NameRol);
                return Ok(new Token { token = token, userId = existingUser.Id });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = "Error al iniciar sesion", error = ex.Message });
            }
            
        }

        private string GetHasPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                byte[] bytesHash = sha.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
