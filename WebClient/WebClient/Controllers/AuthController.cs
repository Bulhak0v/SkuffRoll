// WebClient/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebClient.Models;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

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
        public async Task<IActionResult> Register([FromBody] JsonElement input)
        {
            string jsonInputString = input.GetRawText();
            RegisterRequest registerRequest = input.Deserialize<RegisterRequest>();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if user with this email or login already exists
            if (await _context.Users.AnyAsync(u => u.email == registerRequest.email))
            {
                return Conflict(new { message = "User with this email already exists." });
            }

            if (await _context.Users.AnyAsync(u => u.login == registerRequest.login))
            {
                return Conflict(new { message = "User with this username already exists." });
            }

            // Hash the password before saving
            string hashedPassword = HashPassword(registerRequest.password);

            var newUser = new User
            {
                email = registerRequest.email,
                login = registerRequest.login,
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Identifier) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Username/email and password are required." });
            }

            // Try to find the user by login or email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.login == request.Identifier || u.email == request.Identifier);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username/email or password." });
            }

            // Hash the provided password to compare
            string hashedInputPassword = HashPassword(request.Password);

            if (user.password != hashedInputPassword)
            {
                return Unauthorized(new { message = "Invalid username/email or password." });
            }

            // Successful login, return essential user info
            return Ok(new
            {
                login = user.login,
                email = user.email,
                registrationDate = user.registration_date
                // Optionally add: id, roles, or a JWT if needed later
            });
        }
    }
}