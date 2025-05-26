using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebClient.Models;

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
        public async Task<IActionResult> CreateCharacter([FromBody] Character character, bool isFirstItemSet, List<string> selectedSkillNames)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (character.Class != null && !string.IsNullOrWhiteSpace(character.Class.Name))
            {
                var cls = await _context.Classes.FirstOrDefaultAsync(c => c.Name == character.Class.Name);
                if (cls == null) return BadRequest($"Class '{character.Class.Name}' not found.");
                character.ClassId = cls.Id;
                character.Class = null;
            }
            else
            {
                return BadRequest("Class is required.");
            }

            if (character.Race != null && !string.IsNullOrWhiteSpace(character.Race.Name))
            {
                var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == character.Race.Name);
                if (race == null) return BadRequest($"Race '{character.Race.Name}' not found.");
                character.RaceId = race.Id;
                character.Race = null;
            }
            else
            {
                return BadRequest("Race is required.");
            }

            if (character.Background != null && !string.IsNullOrWhiteSpace(character.Background.Name))
            {
                var background = await _context.Backgrounds.FirstOrDefaultAsync(b => b.Name == character.Background.Name);
                if (background == null) return BadRequest($"Background '{character.Background.Name}' not found.");
                character.BackgroundId = background.Id;
                character.Background = null;
            }
            else
            {
                return BadRequest("Race is required.");
            }

            if (character.Subrace != null && !string.IsNullOrWhiteSpace(character.Subrace.Name))
            {
                var subrace = await _context.Subraces.FirstOrDefaultAsync(s => s.Name == character.Subrace.Name);
                if (subrace == null) return BadRequest($"Subrace '{character.Subrace.Name}' not found.");
                character.SubraceId = subrace.Id;
                character.Subrace = null;
            }

            character.Hp = 0;
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var abilityScoreDto = character.AbilityScores.FirstOrDefault();
            if (abilityScoreDto == null)
                return BadRequest("Ability scores must be provided.");

            var abilityScores = new CharacterAbilityScore
            {
                CharacterId = character.Id,
                StrScore = abilityScoreDto.StrScore,
                DexScore = abilityScoreDto.DexScore,
                ConScore = abilityScoreDto.ConScore,
                IntScore = abilityScoreDto.IntScore,
                WisScore = abilityScoreDto.WisScore,
                ChaScore = abilityScoreDto.ChaScore
            };

            _context.CharacterAbilityScores.Add(abilityScores);
            await _context.SaveChangesAsync();

            var selectedClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == character.ClassId);
            if (selectedClass == null)
                return BadRequest("Invalid class selected.");

            var selectedSubrace = await _context.Subraces.FirstOrDefaultAsync(s => s.Id == character.ClassId);
            int hpSubraceBonus = 0;
            if (selectedSubrace != null && selectedSubrace.Name == "Hill Dwarf")
            {
                hpSubraceBonus = 1;
            }

            int constitutionModifier = (abilityScores.ConScore - 10) / 2;
            int calculatedHp = selectedClass.StartingHp + constitutionModifier + hpSubraceBonus;
            if (calculatedHp < 1) calculatedHp = 1;
            character.Hp = calculatedHp;

            _context.Characters.Update(character);
            await _context.SaveChangesAsync();

            var featureIds = new List<int>();

            if (character.RaceId.HasValue)
            {
                var raceFeatureIds = await _context.RaceFeatures
                    .Where(rf => rf.RaceId == character.RaceId.Value)
                    .Select(rf => rf.FeatureId)
                    .ToListAsync();
                featureIds.AddRange(raceFeatureIds);
            }

            if (character.SubraceId.HasValue)
            {
                var subraceFeatureIds = await _context.SubraceFeatures
                    .Where(sf => sf.SubraceId == character.SubraceId.Value)
                    .Select(sf => sf.FeatureId)
                    .ToListAsync();
                featureIds.AddRange(subraceFeatureIds);
            }

            if (character.ClassId.HasValue)
            {
                var classFeatureIds = await _context.LevelingTables
                    .Where(cf => cf.ClassId == character.ClassId.Value)
                    .Select(cf => cf.FirstTalentId)
                    .ToListAsync();
                featureIds.AddRange((IEnumerable<int>)classFeatureIds);
            }

            if (character.BackgroundId.HasValue)
            {
                var backgroundFeatureIds = await _context.BackgroundFeatures
                    .Where(bf => bf.BackgroundId == character.BackgroundId.Value)
                    .Select(bf => bf.FeatureId)
                    .ToListAsync();
                featureIds.AddRange(backgroundFeatureIds);
            }

            var characterFeatures = featureIds
                .Distinct()
                .Select(fid => new CharacterFeature
                {
                    CharacterId = character.Id,
                    FeatureId = fid
                }).ToList();

            _context.CharacterFeatures.AddRange(characterFeatures);
            await _context.SaveChangesAsync();

            List<int> classItemIds;

            if (isFirstItemSet == true)
            {
                classItemIds = await _context.FirstItemSets
                    .Where(f => f.ClassId == character.ClassId)
                    .Select(f => f.ItemId)
                    .ToListAsync();
            }
            else
            {
                classItemIds = await _context.SecondItemSets
                    .Where(s => s.ClassId == character.ClassId)
                    .Select(s => s.ItemId)
                    .ToListAsync();
            }

            var backgroundItemIds = await _context.BackgroundItems
                .Where(b => b.BackgroundId == character.BackgroundId)
                .Select(b => b.ItemId)
                .ToListAsync();

            var allItemIds = classItemIds.Concat(backgroundItemIds).ToList();
            var characterInventoryItems = allItemIds.Select(itemId => new CharacterInventory
            {
                CharacterId = character.Id,
                ItemId = itemId,
                Quantity = 1
            }).ToList();

            _context.CharacterInventories.AddRange(characterInventoryItems);
            await _context.SaveChangesAsync();

            var characterClass = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == character.ClassId);

            if (characterClass != null)
            {
                var savingThrow = new CharacterSavingThrow
                {
                    CharacterId = character.Id,
                    Str = characterClass.FirstSavingThrow == "Str" || characterClass.SecondSavingThrow == "Str",
                    Dex = characterClass.FirstSavingThrow == "Dex" || characterClass.SecondSavingThrow == "Dex",
                    Con = characterClass.FirstSavingThrow == "Con" || characterClass.SecondSavingThrow == "Con",
                    Int = characterClass.FirstSavingThrow == "Int" || characterClass.SecondSavingThrow == "Int",
                    Wis = characterClass.FirstSavingThrow == "Wis" || characterClass.SecondSavingThrow == "Wis",
                    Cha = characterClass.FirstSavingThrow == "Cha" || characterClass.SecondSavingThrow == "Cha"
                };

                _context.CharacterSavingThrows.Add(savingThrow);
                await _context.SaveChangesAsync();
            }

            var backgroundSkillIds = await _context.BackgroundSkills
                .Where(bs => bs.BackgroundId == character.BackgroundId)
                .Select(bs => bs.SkillId)
                .ToListAsync();

            var selectedSkillIds = await _context.Skills
                .Where(s => selectedSkillNames.Contains(s.Name))
                .Select(s => s.Id)
                .ToListAsync();

            var allSkillIds = backgroundSkillIds.Concat(selectedSkillIds).Distinct().ToList();
            var characterSkill = new CharacterSkill { CharacterId = character.Id };

            foreach (var skillId in allSkillIds)
            {
                switch (skillId)
                {
                    case 1: characterSkill.Acrobatics = true; break;
                    case 2: characterSkill.AnimalHandling = true; break;
                    case 3: characterSkill.Arcana = true; break;
                    case 4: characterSkill.Athletics = true; break;
                    case 5: characterSkill.Deception = true; break;
                    case 6: characterSkill.History = true; break;
                    case 7: characterSkill.Insight = true; break;
                    case 8: characterSkill.Intimidation = true; break;
                    case 9: characterSkill.Investigation = true; break;
                    case 10: characterSkill.Medicine = true; break;
                    case 11: characterSkill.Nature = true; break;
                    case 12: characterSkill.Perception = true; break;
                    case 13: characterSkill.Performance = true; break;
                    case 14: characterSkill.Persuasion = true; break;
                    case 15: characterSkill.Religion = true; break;
                    case 16: characterSkill.SleightOfHand = true; break;
                    case 17: characterSkill.Stealth = true; break;
                    case 18: characterSkill.Survival = true; break;
                }
            }

            _context.CharacterSkills.Add(characterSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            var character = await _context.Characters
                .Include(c => c.Class)
                .Include(c => c.Race)
                .Include(c => c.Subrace)
                .Include(c => c.Background)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
                return NotFound();

            return Ok(character);
        }
    }
}
