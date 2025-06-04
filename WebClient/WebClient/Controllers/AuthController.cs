// WebClient/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebClient.Models;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This makes the route for this controller /api/auth
    public class AuthController : ControllerBase
    {
        private readonly SkuffrollDbContext _context;

        public AuthController(SkuffrollDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")] // This makes the route for this action /api/auth/register
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if user with this email or login already exists
            if (await _context.Users.AnyAsync(u => u.email == request.Email))
            {
                return Conflict(new { message = "User with this email already exists." });
            }

            if (await _context.Users.AnyAsync(u => u.login == request.Login))
            {
                return Conflict(new { message = "User with this username already exists." });
            }

            // Hash the password before saving
            string hashedPassword = HashPassword(request.Password);

            var newUser = new User
            {
                email = request.Email,
                login = request.Login,
                password = hashedPassword, // Store the hashed password
                registration_date = DateTime.UtcNow // Set registration date
            };

            _context.Users.Add(newUser);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception for debugging
                Console.Error.WriteLine($"Database error during user registration: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, new { message = "An error occurred while saving the user to the database." });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred during registration: {ex.Message}");
                return StatusCode(500, new { message = "An unexpected error occurred during registration." });
            }


            // For a real application, you might return a JWT token here or a simplified user object
            return Ok(new { message = "Registration successful!" });
        }

        // Simple password hashing function (for demonstration - consider more robust libraries like Argon2 or BCrypt)
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" for hexadecimal
                }
                return builder.ToString();
            }
        }
    }
}