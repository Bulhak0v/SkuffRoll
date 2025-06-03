using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for EF Core methods like .ToListAsync(), .FirstOrDefaultAsync()
using System; // Required for Guid (if you decide to generate IDs on backend)
using System.Collections.Generic;
using System.Linq; // Required for .FirstOrDefault() and .Any()
using System.Threading.Tasks; // Required for async/await
using WebClient.Models; // Your DbContext and potentially other models
using WebClient.Models.ClassDataNamespace;

namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This means the base URL for this controller will be /api/homebrew
    public class HomebrewController : ControllerBase
    {
        private readonly SkuffrollDbContext _context;

        public HomebrewController(SkuffrollDbContext context)
        {
            _context = context; // Dependency Injection: EF Core will provide an instance of your DbContext
        }

        [HttpGet] // GET: api/homebrew
        public async Task<ActionResult<IEnumerable<ClassData>>> GetAllHomebrewClasses()
        {
            // Fetch all homebrew classes from the database asynchronously
            var homebrewClasses = await _context.Classes.ToListAsync();
            return Ok(homebrewClasses);
        }


        [HttpGet("{id}")] // GET: api/homebrew/{id}
        public async Task<ActionResult<ClassData>> GetHomebrewClassById(int id)
        {
            // Find the class in the database by its ID asynchronously
            var foundClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);

            if (foundClass == null)
            {
                return NotFound($"Homebrew Class with ID '{id}' not found."); // Return 404 if not found
            }
            return Ok(foundClass); // Return 200 OK with the class data
        }


        [HttpPost("create")] // POST: api/homebrew/create
        public async Task<ActionResult<ClassData>> CreateHomebrewClass([FromBody] ClassData classData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Class temp = ClassData.ClassDataConvert(classData);
            _context.Classes.Add(temp);

            try
            {
                // Save changes to the database asynchronously
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details for debugging
                Console.Error.WriteLine($"Error creating homebrew class: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, "An error occurred while saving the new homebrew class to the database.");
            }


            // Return 201 Created status, with the newly created class data
            // and a Location header pointing to the GET endpoint for this new resource.
            return CreatedAtAction(nameof(GetHomebrewClassById), new { id = classData.id }, classData);
        }

        /// <summary>
        /// Updates an existing homebrew class in the database.
        /// </summary>
        /// <param name="id">The ID of the class to update (from the URL).</param>
        /// <param name="updatedClass">The updated ClassData object.</param>
        /// <returns>NoContent if successful, NotFound if the class doesn't exist, or BadRequest on mismatch.</returns>
        [HttpPut("{id}")] // PUT: api/homebrew/{id}
        [HttpPut("{id}")] // PUT: api/homebrew/{id}
        public async Task<IActionResult> UpdateHomebrewClass([FromBody] ClassData updatedClass) // ID should be string here too
        {
            // Validate the incoming model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Corrected: Use _context.HomebrewClasses and 'id' of type string
            var existingClass = await _context.Classes.AsNoTracking().FirstOrDefaultAsync(c => c.Name == );

            if (existingClass == null)
            {
                return NotFound($"Homebrew Class with ID '{id}' not found."); // Return 404 if not found
            }

            // Corrected: Use _context.HomebrewClasses.Update()
            _context.Classes.Update((ClassData.ClassDataConvert(updatedClass)));

            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                // This block handles cases where the entity might have been deleted by another process
                // Corrected: Use _context.HomebrewClasses
                if (!HomebrewClassExists(id))
                {
                    return NotFound($"Homebrew Class with ID '{id}' not found after concurrency check.");
                }
                else
                {
                    throw; // Something else went wrong, re-throw the exception
                }
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine($"Error updating homebrew class: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, "An error occurred while updating the homebrew class in the database.");
            }

            return NoContent(); // Return 204 No Content for a successful update
        }

        [HttpDelete("{id}")] // DELETE: api/homebrew/{id}
        public async Task<IActionResult> DeleteHomebrewClass(int id)
        {
            // Find the class to delete
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (existingClass == null)
            {
                return NotFound($"Homebrew Class with ID '{id}' not found."); // Return 404 if not found
            }

            // Remove the class from the DbContext's tracking
            _context.Classes.Remove(existingClass);

            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine($"Error deleting homebrew class: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, "An error occurred while deleting the homebrew class from the database.");
            }

            return NoContent(); 
        }

        private bool HomebrewClassExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}