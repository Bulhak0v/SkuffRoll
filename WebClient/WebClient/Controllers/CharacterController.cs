using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using WebClient.Models;
using WebClient.Models.CharData;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly SkuffrollDbContext _context;

        public CharacterController(SkuffrollDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCharacter([FromBody] JsonElement input)
        {
            Character newCharacter = new Character();
            var jsonString = input.GetRawText();
            CharDataWithLogin charDataWithLogin = input.Deserialize<CharDataWithLogin>();
            CharData charData = charDataWithLogin.@char;
            string userLogin = charDataWithLogin.login;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            Class charClass;
            if (!string.IsNullOrWhiteSpace(charData.className))
            {
                charClass = await _context.Classes.FirstOrDefaultAsync(c => c.name == charData.className);
                if (charClass == null) return BadRequest($"Class '{charData.className}' not found.");
                newCharacter.class_id = charClass.id;
                newCharacter.Class = null;
            }
            else
            {
                return BadRequest("Class is required.");
            }

            if (!string.IsNullOrWhiteSpace(charData.race))
            {
                string raceName = "";

                switch (charData.race)
                {
                    case "dwarf":
                        raceName = "Dwarf";
                        break;

                    case "elf":
                        raceName = "Elf";
                        break;

                    case "halfling":
                        raceName = "Halfling";
                        break;

                    case "human":
                        raceName = "Human";
                        break;

                    case "dragonborn":
                        raceName = "Dragonborn";
                        break;

                    case "gnome":
                        raceName = "Gnome";
                        break;

                    case "half-elf":
                        raceName = "Half-Elf";
                        break;

                    case "half-orc":
                        raceName = "Half-Orc";
                        break;

                    case "tiefling":
                        raceName = "Tiefling";
                        break;
                }

                Race race = await _context.Races.FirstOrDefaultAsync(r => r.name == raceName);
                if (race == null) return BadRequest($"Race '{raceName}' not found.");
                newCharacter.race_id = race.id;
                newCharacter.Race = null;
            }
            else
            {
                return BadRequest("Race is required.");
            }

            if (!string.IsNullOrWhiteSpace(charData.backgroundName))
            {
                Background background = await _context.Backgrounds.FirstOrDefaultAsync(b => b.name == charData.backgroundName);
                if (background == null) return BadRequest($"Background '{charData.backgroundName}' not found.");
                newCharacter.background_id = background.id;
                newCharacter.Background = null;
            }
            else
            {
                return BadRequest("Race is required.");
            }

            if (!string.IsNullOrWhiteSpace(charData.subrace))
            {
                string subraceName = "";
                switch (charData.subrace)
                {
                    case "hill-dwarf":
                        subraceName = "Hill Dwarf";
                        break;

                    case "mountain-dwarf":
                        subraceName = "Mountain Dwarf";
                        break;

                    case "high-elf":
                        subraceName = "High Elf";
                        break;

                    case "wood-elf":
                        subraceName = "Wood Elf";
                        break;

                    case "drow":
                        subraceName = "Drow (Dark Elf)";
                        break;

                    case "lightfoot-halfling":
                        subraceName = "Lightfoot Halfling";
                        break;

                    case "stout-halfling":
                        subraceName = "Stout Halfling";
                        break;

                    case "forest-gnome":
                        subraceName = "Forest Gnome";
                        break;

                    case "rock-gnome":
                        subraceName = "Rock Gnome";
                        break;
                }

                Subrace subrace = await _context.Subraces.FirstOrDefaultAsync(s => s.name == subraceName);
                if (subrace == null) return BadRequest($"Subrace '{subraceName}' not found.");
                newCharacter.subrace_id = subrace.id;
                newCharacter.Subrace = null;
            }

            newCharacter.hp = 0;
            newCharacter.image = charData.avatar;
            newCharacter.name = charData.name;
            newCharacter.alignment = charData.alignment;
            newCharacter.gender = charData.gender;
            newCharacter.age = charData.age;
            newCharacter.appearance = charData.appearance;
            newCharacter.level = 1;
            newCharacter.flaws = charData.story.flaws;
            newCharacter.bonds = charData.story.bonds;
            newCharacter.ideals = charData.story.ideals;
            newCharacter.armor_class = 16;
            newCharacter.armor_proficiency = charClass.armor_proficiency;
            newCharacter.tool_proficiency = charClass.tool_proficiency;
            newCharacter.weapon_proficiency = charClass.weapon_proficiency;
            newCharacter.vehicle_proficiency = "-";
            newCharacter.backstory = "-";
            newCharacter.personality_traits = "-";
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            var abilityScores = new CharacterAbilityScore
            {
                character_id = newCharacter.id,
                str_score = charData.abilityScores.total.str,
                dex_score = charData.abilityScores.total.dex,
                con_score = charData.abilityScores.total.con,
                int_score = charData.abilityScores.total.@int,
                wis_score = charData.abilityScores.total.wis,
                cha_score = charData.abilityScores.total.cha
            };

            _context.CharacterAbilityScores.Add(abilityScores);
            await _context.SaveChangesAsync();

            Class selectedClass = await _context.FindAsync<Class>(newCharacter.class_id);
            if (selectedClass == null)
            {
                return BadRequest("Class not found during HP calculation");
            }
            
            Subrace selectedSubrace = await _context.FindAsync<Subrace>(newCharacter.subrace_id);
            int hpSubraceBonus = 0;
            if (selectedSubrace != null && selectedSubrace.name == "Hill Dwarf")
            {
                hpSubraceBonus = 1;
            }

            int constitutionModifier = (abilityScores.con_score - 10) / 2;
            int calculatedHp = selectedClass.starting_hp + constitutionModifier + hpSubraceBonus;
            if (calculatedHp < 1)
            {
                calculatedHp = 1;
            }
            newCharacter.hp = calculatedHp;

            Race selectedRace = await _context.FindAsync<Race>(newCharacter.race_id);
            if (selectedRace == null)
            {
                return BadRequest("Race not found during Speed asignment");
            }
            newCharacter.speed = selectedRace.speed;

            int userId = _context.Users.FirstOrDefault(u => u.login == userLogin).id;
            if (userId == null || userId == 0)
            {
                return BadRequest("UserID not found during user asignment");
            }
            newCharacter.user_id = userId;

            _context.Characters.Update(newCharacter);
            await _context.SaveChangesAsync();

            List<int> featureIds = new List<int>();
            List<int> raceFeatureIds = await _context.RaceFeatures
                .Where(rf => rf.race_id == selectedRace.id)
                .Select(rf => rf.feature_id)
                .ToListAsync();
            featureIds.AddRange(raceFeatureIds);

            if (selectedSubrace != null)
            {
                List<int> subraceFeatureIds = await _context.SubraceFeatures
                    .Where(sf => sf.subrace_id == selectedSubrace.id)
                    .Select(sf => sf.feature_id)
                    .ToListAsync();
                featureIds.AddRange(subraceFeatureIds);
            }

            List<int?> classFeatureIds = await _context.LevelingTables
                .Where(cf => cf.class_id == selectedClass.id)
                .Select(cf => cf.first_talent_id)
                .ToListAsync();
            foreach (int? featureId in classFeatureIds)
            {
                if (featureId != null)
                {
                    int featId = (int)featureId;
                    featureIds.Add(featId);
                }
            }

            List<int> backgroundFeatureIds = await _context.BackgroundFeatures
                .Where(bf => bf.background_id == newCharacter.background_id)
                .Select(bf => bf.feature_id)
                .ToListAsync();
            featureIds.AddRange(backgroundFeatureIds);

            List<CharacterFeature> characterFeatures = featureIds
                .Distinct()
                .Select(fid => new CharacterFeature
                {
                    character_id = newCharacter.id,
                    feature_id = fid
                }).ToList();

            _context.CharacterFeatures.AddRange(characterFeatures);
            await _context.SaveChangesAsync();

            List<int> classItemIds;
            if (charData.equipmentSetChoice == "a")
            {
                classItemIds = await _context.FirstItemSets
                    .Where(f => f.class_id == selectedClass.id)
                    .Select(f => f.item_id)
                    .ToListAsync();
            }
            else
            {
                classItemIds = await _context.SecondItemSets
                    .Where(s => s.class_id == selectedClass.id)
                    .Select(s => s.item_id)
                    .ToListAsync();
            }

            List<int> backgroundItemIds = await _context.BackgroundItems
                .Where(b => b.background_id == newCharacter.background_id)
                .Select(b => b.item_id)
                .ToListAsync();

            List<int> allItemIds = classItemIds.Concat(backgroundItemIds).ToList();
            List<CharacterInventory> characterInventoryItems = allItemIds.Select(itemId => new CharacterInventory
            {
                character_id = newCharacter.id,
                item_id = itemId,
                quantity = 1
            }).ToList();

            _context.CharacterInventories.AddRange(characterInventoryItems);
            await _context.SaveChangesAsync();


            CharacterSavingThrow savingThrow = new CharacterSavingThrow
            {
                character_id = newCharacter.id,
                str = selectedClass.first_saving_throw == "Strength" || selectedClass.second_saving_throw == "Strength",
                dex = selectedClass.first_saving_throw == "Dexterity" || selectedClass.second_saving_throw == "Dexterity",
                con = selectedClass.first_saving_throw == "Constitution" || selectedClass.second_saving_throw == "Constitution",
                @int = selectedClass.first_saving_throw == "Intelligence" || selectedClass.second_saving_throw == "Intelligence",
                wis = selectedClass.first_saving_throw == "Wisdom" || selectedClass.second_saving_throw == "Wisdom",
                cha = selectedClass.first_saving_throw == "Charisma" || selectedClass.second_saving_throw == "Charisma"
            };

            _context.CharacterSavingThrows.Add(savingThrow);
            await _context.SaveChangesAsync();

            List<int> backgroundSkillIds = await _context.BackgroundSkills
                .Where(bs => bs.background_id == newCharacter.background_id)
                .Select(bs => bs.skill_id)
                .ToListAsync();

            List<int> selectedSkillIds = await _context.Skills
                .Where(s => charData.finalSkillProficiencies.Contains(s.name))
                .Select(s => s.id)
                .ToListAsync();

            List<int> allSkillIds = backgroundSkillIds.Concat(selectedSkillIds).Distinct().ToList();
            CharacterSkill characterSkill = new CharacterSkill { character_id = newCharacter.id };

            foreach (int skillId in allSkillIds)
            {
                switch (skillId)
                {
                    case 1: characterSkill.athletics = true; break;
                    case 2: characterSkill.animal_handling = true; break;
                    case 3: characterSkill.arcana = true; break;
                    case 4: characterSkill.athletics = true; break;
                    case 5: characterSkill.deception = true; break;
                    case 6: characterSkill.history = true; break;
                    case 7: characterSkill.insight = true; break;
                    case 8: characterSkill.intimidation = true; break;
                    case 9: characterSkill.intimidation = true; break;
                    case 10: characterSkill.medicine = true; break;
                    case 11: characterSkill.nature = true; break;
                    case 12: characterSkill.perception = true; break;
                    case 13: characterSkill.performance = true; break;
                    case 14: characterSkill.persuasion = true; break;
                    case 15: characterSkill.religion = true; break;
                    case 16: characterSkill.sleight_of_hand = true; break;
                    case 17: characterSkill.stealth = true; break;
                    case 18: characterSkill.survival = true; break;
                }
            }

            _context.CharacterSkills.Add(characterSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.id });
        }

        [HttpPost("get-visible-character-names")]
        public async Task<IActionResult> GetVisibleCharacterNames([FromBody] JsonElement input)
        {
            LoginData loginData = input.Deserialize<LoginData>();

            int userId = _context.Users.FirstOrDefault(u => u.login == loginData.login).id;
            if (userId == null || userId == 0)
            {
                return BadRequest("UserID not found during character search");
            }

            List<string> characters = await _context.Characters
                .Where(c => c.user_id == userId)
                .Select(c => c.name)
                .ToListAsync();

            return Ok(characters);
        }

        [HttpDelete("delete/{name}")]
        public async Task<IActionResult> DeleteCharacter(string name)
        {
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.name == name);
            if (character == null)
            {
                return NotFound("Character not found.");
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            var character = await _context.Characters
                .Include(c => c.Class)
                .Include(c => c.Race)
                .Include(c => c.Subrace)
                .Include(c => c.Background)
                .FirstOrDefaultAsync(c => c.id == id);

            if (character == null)
                return NotFound();

            return Ok(character);
        }
    }
}