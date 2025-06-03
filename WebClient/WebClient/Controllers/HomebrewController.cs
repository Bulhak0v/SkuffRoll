using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Models.ClassDataNamespace;
namespace WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomebrewController : ControllerBase
    {
        private readonly SkuffrollDbContext _context;

        public HomebrewController(SkuffrollDbContext context)
        {
            _context = context;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateClass([FromBody] JsonElement input)
        {
            Class newClass = new Class();
            ClassData classData = null;
            try
            {
                string temp = input.GetRawText();
                classData = input.Deserialize<ClassData>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (classData == null)
                {
                    Console.WriteLine("Deserialization resulted in a null ClassData object.");
                    return BadRequest("Invalid input format or empty data provided.");
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

            if (!TryValidateModel(classData))
            {
                Console.WriteLine("ClassData object failed validation.");
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(classData.name) && await _context.Classes.AnyAsync(c => c.name == classData.name))
            {
                Console.WriteLine($"Conflict: Class with name '{classData.name}' already exists.");
                return Conflict($"Homebrew Class with name '{classData.name}' already exists.");
            }

            newClass = classData.ConvertToClass(_context);

            foreach (string skillName in classData.skillChoices.options)
            {
                var skill = _context.Skills.FirstOrDefault(s => s.name == skillName);
                if (skill != null)
                {
                    ClassSkill ck = new ClassSkill
                    {
                        class_id = newClass.id,
                        skill_id = skill.id
                    };
                    _context.ClassSkills.Add(ck);
                }
            }


            foreach (OptionSets name in classData.startingEquipment.optionSets)
            {
                var item1 = _context.Items.FirstOrDefault(i => i.name == name.setA);
                var item2 = _context.Items.FirstOrDefault(i => i.name == name.setB);

                if (item1 != null)
                {
                    var new1Item = new FirstItemSet
                    {
                        item_id = item1.id,
                        class_id = newClass.id
                    };
                    _context.FirstItemSets.Add(new1Item);
                }

                if (item2 != null)
                {
                    var new2Item = new SecondItemSet
                    {
                        item_id = item2.id,
                        class_id = newClass.id
                    };
                    _context.SecondItemSets.Add(new2Item);
                }
            }


            _context.Classes.Add(newClass);

            try
            {
                await _context.SaveChangesAsync();
                var dict = new Dictionary<int, int>();
                int count = 1;
                foreach (FeatureData level in classData.FeaturesTable)
                {
                    if (!string.IsNullOrEmpty(level.feature))
                    {
                        Feature newFeature = new Feature();
                        newFeature.name = level.feature;
                        _context.Features.Add(newFeature);
                        dict.Add(count, newFeature.id);
                    }
                    count++;
                }
                var newLeveling = new LevelingTable();
                foreach (var x in dict.Keys)
                {
                    switch (x)
                    {
                        case 1:
                            newLeveling.first_talent_id = dict[x];
                            break;
                        case 2:
                            newLeveling.second_talent_id = dict[x];
                            break;
                        case 3:
                            newLeveling.third_talent_id = dict[x];
                            break;
                        case 4:
                            newLeveling.fourth_talent_id= dict[x];
                            break;
                        case 5:
                            newLeveling.fifth_talent_id = dict[x];
                            break;
                        case 6:
                            newLeveling.sixth_talent_id = dict[x];
                            break;
                        case 7:
                            newLeveling.seventh_talent_id = dict[x];
                            break;
                        case 8:
                            newLeveling.eighth_talent_id = dict[x];
                            break;
                        case 9:
                            newLeveling.ninth_talent_id = dict[x];
                            break;
                        case 10:
                            newLeveling.tenth_talent_id = dict[x];
                            break;
                        case 11:
                            newLeveling.eleventh_talent_id = dict[x];
                            break;
                        case 12:
                            newLeveling.twelfth_talent_id = dict[x];
                            break;
                        case 13:
                            newLeveling.thirteenth_talent_id = dict[x];
                            break;
                        case 14:
                            newLeveling.fourteenth_talent_id = dict[x];
                            break;
                        case 15:
                            newLeveling.fifteenth_talent_id= dict[x];
                            break;
                        case 16:
                            newLeveling.sixteenth_talent_id = dict[x];
                            break;
                        case 17:
                            newLeveling.seventeenth_talent_id= dict[x];
                            break;
                        case 18:
                            newLeveling.eighteenth_talent_id = dict[x];
                            break;
                        case 19:
                            newLeveling.nineteenth_talent_id = dict[x];
                            break;
                        case 20:
                            newLeveling.twentieth_talent_id = dict[x];
                            break;
                        
                    }
                }
                newLeveling.class_id = newClass.id;
                _context.LevelingTables.Add(newLeveling);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Successfully saved class '{classData.name}' to the database.");
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine($"Database Update Error creating homebrew class: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, "An error occurred while saving the new homebrew class to the database. Please check server logs for details.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An unexpected error occurred during save: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred. Please try again or contact support.");
            }

            return CreatedAtAction(
                nameof(GetClassByName),
                new { name = classData.name },
                classData
            );
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ClassData>> GetClassByName(string name)
        {
            var foundClassData = await _context.Classes.FirstOrDefaultAsync(c => c.name == name);
            if (foundClassData == null)
            {
                return NotFound($"Class with Name '{name}' not found.");
            }
            return Ok(foundClassData);
        }

        private bool HomebrewClassExists(string name)
        {
            return _context.Classes.Any(e => e.name == name);
        }
    }
}