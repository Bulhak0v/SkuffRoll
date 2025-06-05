using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebClient.Models;
using WebClient.Models.ClassDataNamespace;
using WebClient.Models.Data;

namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomebrewRaceController : Controller
    {
        private readonly SkuffrollDbContext _context;

        public HomebrewRaceController(SkuffrollDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRace([FromBody] JsonElement input)
        {
            RaceData raceData = null;

            // --- Deserialization and Initial Validation ---
            try
            {
                raceData = input.Deserialize<RaceData>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (raceData == null)
                {
                    Console.WriteLine("Deserialization resulted in a null RaceData object.");
                    return BadRequest("Invalid input format or empty data provided.");
                }

                if (string.IsNullOrWhiteSpace(raceData.name))
                {
                    return BadRequest("Race name cannot be empty.");
                }

                if (raceData.abilityScoreIncrease == null)
                {
                    return BadRequest("Ability score increase data is missing.");
                }
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine($"JSON Deserialization Error: {ex.Message}");
                Console.Error.WriteLine($"Path: {ex.Path}, Line: {ex.LineNumber}, Byte: {ex.BytePositionInLine}");
                return BadRequest($"Invalid JSON format or data type mismatch: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred during deserialization: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while processing your request.");
            }

            // --- Database Operations ---
            using var transaction = await _context.Database.BeginTransactionAsync(); // Use a transaction for atomicity

            try
            {
                // 1. Check for existing Race with the same name
                var existingRace = await _context.Races
                                                 .AsNoTracking()
                                                 .FirstOrDefaultAsync(r => r.name == raceData.name);

                if (existingRace != null)
                {
                    // If a race with this name already exists, return a Conflict status
                    await transaction.RollbackAsync(); // Rollback any pending operations
                    return Conflict($"Race with name '{raceData.name}' already exists.");
                }

                // 2. Create and add new Features if they don't exist, and collect them
                //    Or retrieve existing features
                var featuresToAdd = new List<Feature>();
                if (raceData.commonTraits != null && raceData.commonTraits.Any())
                {
                    foreach (var featureData in raceData.commonTraits)
                    {
                        // Check if a feature with this name already exists
                        var existingFeature = await _context.Features
                                                            .FirstOrDefaultAsync(f => f.name == featureData.name);

                        if (existingFeature == null)
                        {
                            // Feature does not exist, create a new one
                            var newFeature = new Feature
                            {
                                name = featureData.name,
                                description = featureData.text
                            };
                            _context.Features.Add(newFeature);
                            featuresToAdd.Add(newFeature); // Add to list to be saved
                        }
                        else
                        {
                            // Feature already exists, use it
                            featuresToAdd.Add(existingFeature);
                        }
                    }

                    // Save changes to get IDs for new features (if any) before creating RaceFeature entries
                    await _context.SaveChangesAsync();
                }

                // 3. Create the new Race entity
                Race newRace = new Race
                {
                    name = raceData.name,
                    description = raceData.description,
                    image = raceData.image,
                    speed = raceData.speed,
                    size = raceData.size,
                    str_increase = raceData.abilityScoreIncrease.str,
                    dex_increase = raceData.abilityScoreIncrease.dex,
                    con_increase = raceData.abilityScoreIncrease.con,
                    wis_increase = raceData.abilityScoreIncrease.wis,
                    int_increase = raceData.abilityScoreIncrease.@int,
                    cha_increase = raceData.abilityScoreIncrease.cha,
                    is_homebrew = true
                };

                // Add the new race to the DbContext
                _context.Races.Add(newRace);

                // Save changes to get the ID for the new race
                await _context.SaveChangesAsync();

                // 4. Create RaceFeature entries (join table entries)
                foreach (var feature in featuresToAdd)
                {
                    var raceFeature = new RaceFeature
                    {
                        race_id = newRace.id,    // Use the newly generated ID for Race
                        feature_id = feature.id // Use the ID (newly generated or existing) for Feature
                    };
                    _context.RaceFeatures.Add(raceFeature);
                }

                // Save changes for the RaceFeature entries
                await _context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();

                Console.WriteLine($"Successfully created race '{newRace.name}' with ID: {newRace.id} and {featuresToAdd.Count} features.");

                // Return 201 Created status, pointing to the location of the new resource
                return CreatedAtAction(
                    nameof(GetRaceByName), // Method name to generate the URL for retrieving the race
                    new { name = newRace.name }, // Route values for GetRaceByName (e.g., /api/race/{name})
                    newRace // The created Race object to return in the response body
                );
            }
            catch (DbUpdateException dbEx)
            {
                await transaction.RollbackAsync(); // Rollback transaction on database error
                Console.Error.WriteLine($"Database update error during race creation: {dbEx.Message}");
                if (dbEx.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {dbEx.InnerException.Message}");
                }
                return StatusCode(500, "A database error occurred while trying to create the race. The operation has been rolled back.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(); // Rollback transaction on any other error
                Console.Error.WriteLine($"An unexpected error occurred during race creation: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred while creating the race. The operation has been rolled back.");
            }
        }

        // You must have this action in your controller for CreatedAtAction to work
        [HttpGet("{name}")]
        public async Task<IActionResult> GetRaceByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Race name is required.");
            }

            var race = await _context.Races
                                     .Include(r => r.RaceFeatures) // Include related RaceFeatures
                                         .ThenInclude(rf => rf.Feature) // Then include the actual Feature object
                                     .FirstOrDefaultAsync(r => r.name == name);

            if (race == null)
            {
                return NotFound($"Race with name '{name}' not found.");
            }

            return Ok(race);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteRace([FromBody] JsonElement input)
        {
            RaceData raceData = new RaceData();
            raceData = input.Deserialize<RaceData>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            try
            {
                // Найти класс в базе данных по имени
                var raceToDelete = await _context.Races
                    .FirstOrDefaultAsync(c => c.name == raceData.name);
                if (raceToDelete == null)
                {
                    Console.WriteLine($"Class with name '{raceData.name}' not found.");
                    return NotFound($"Class with name '{raceData.name}' not found.");
                }
                var raceFeatures = _context.RaceFeatures.Where(rf => rf.race_id == raceToDelete.id);
                _context.RaceFeatures.RemoveRange(raceFeatures);

                _context.Races.Remove(raceToDelete);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"DeleteRace: Database update error: {dbEx.Message}");
                if (dbEx.InnerException != null)
                {
                    Console.Error.WriteLine($"DeleteRace: Inner exception: {dbEx.InnerException.Message}");
                }
                return StatusCode(500, new { message = "A database error occurred while trying to delete the race. The operation has been rolled back.", details = dbEx.Message });
            }

            Console.WriteLine("XDDDDDDDDDDD");
            return Ok(new { message = $"Race '{raceData.name}' and its associated features have been successfully deleted." });
        }

        private bool HomebrewRaceExists(string name)
        {
            return _context.Races.Any(e => e.name == name);
        }
    }
}
