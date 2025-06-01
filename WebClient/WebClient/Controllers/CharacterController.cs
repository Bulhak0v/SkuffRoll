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
            string jsonString = input.GetRawText();
            CharData charData = input.Deserialize<CharData>();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!string.IsNullOrWhiteSpace(charData.className))
            {
                Class charClass = await _context.Classes.FirstOrDefaultAsync(c => c.name == charData.className);
                if (charClass == null) return BadRequest($"Class '{charData.className}' not found.");
                newCharacter.class_id = charClass.id;
                newCharacter.Class = null;
            }
            else
            {
                return BadRequest("Class is required.");
            }

            if (!string.IsNullOrWhiteSpace(charData.raceName))
            {
                Race race = await _context.Races.FirstOrDefaultAsync(r => r.name == charData.raceName);
                if (race == null) return BadRequest($"Race '{charData.raceName}' not found.");
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

            //if (!string.IsNullOrWhiteSpace(charData.subrace))
            //{
            //    var subrace = await _context.Subraces.FirstOrDefaultAsync(s => s.Name == charData.subrace);
            //    if (subrace == null) return BadRequest($"Subrace '{charData.subrace}' not found.");
            //    newCharacter.SubraceId = subrace.Id;
            //    newCharacter.Subrace = null;
            //}

            newCharacter.hp = 0;
            newCharacter.image = charData.avatar;
            newCharacter.name = charData.name;
            newCharacter.alignment = charData.alignment;
            newCharacter.gender = charData.gender;
            newCharacter.age = charData.age;
            newCharacter.appearance = charData.appearance;
            newCharacter.level = 1;
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            //var abilityScoreDto = characterCreationRequest.Character.AbilityScores.FirstOrDefault();
            //if (abilityScoreDto == null)
            //    return BadRequest("Ability scores must be provided.");

            //var abilityScores = new CharacterAbilityScore
            //{
            //    CharacterId = characterCreationRequest.Character.Id,
            //    StrScore = abilityScoreDto.StrScore,
            //    DexScore = abilityScoreDto.DexScore,
            //    ConScore = abilityScoreDto.ConScore,
            //    IntScore = abilityScoreDto.IntScore,
            //    WisScore = abilityScoreDto.WisScore,
            //    ChaScore = abilityScoreDto.ChaScore
            //};

            //_context.CharacterAbilityScores.Add(abilityScores);
            //await _context.SaveChangesAsync();

            //var selectedClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == characterCreationRequest.Character.ClassId);
            //if (selectedClass == null)
            //    return BadRequest("Invalid class selected.");

            //var selectedSubrace = await _context.Subraces.FirstOrDefaultAsync(s => s.Id == characterCreationRequest.Character.ClassId);
            //int hpSubraceBonus = 0;
            //if (selectedSubrace != null && selectedSubrace.Name == "Hill Dwarf")
            //{
            //    hpSubraceBonus = 1;
            //}

            //int constitutionModifier = (abilityScores.ConScore - 10) / 2;
            //int calculatedHp = selectedClass.StartingHp + constitutionModifier + hpSubraceBonus;
            //if (calculatedHp < 1) calculatedHp = 1;
            //characterCreationRequest.Character.Hp = calculatedHp;

            //_context.Characters.Update(characterCreationRequest.Character);
            //await _context.SaveChangesAsync();

            //var featureIds = new List<int>();

            //if (characterCreationRequest.Character.RaceId.HasValue)
            //{
            //    var raceFeatureIds = await _context.RaceFeatures
            //        .Where(rf => rf.RaceId == characterCreationRequest.Character.RaceId.Value)
            //        .Select(rf => rf.FeatureId)
            //        .ToListAsync();
            //    featureIds.AddRange(raceFeatureIds);
            //}

            //if (characterCreationRequest.Character.SubraceId.HasValue)
            //{
            //    var subraceFeatureIds = await _context.SubraceFeatures
            //        .Where(sf => sf.SubraceId == characterCreationRequest.Character.SubraceId.Value)
            //        .Select(sf => sf.FeatureId)
            //        .ToListAsync();
            //    featureIds.AddRange(subraceFeatureIds);
            //}

            //if (characterCreationRequest.Character.ClassId.HasValue)
            //{
            //    var classFeatureIds = await _context.LevelingTables
            //        .Where(cf => cf.ClassId == characterCreationRequest.Character.ClassId.Value)
            //        .Select(cf => cf.FirstTalentId)
            //        .ToListAsync();
            //    featureIds.AddRange((IEnumerable<int>)classFeatureIds);
            //}

            //if (characterCreationRequest.Character.BackgroundId.HasValue)
            //{
            //    var backgroundFeatureIds = await _context.BackgroundFeatures
            //        .Where(bf => bf.BackgroundId == characterCreationRequest.Character.BackgroundId.Value)
            //        .Select(bf => bf.FeatureId)
            //        .ToListAsync();
            //    featureIds.AddRange(backgroundFeatureIds);
            //}

            //var characterFeatures = featureIds
            //    .Distinct()
            //    .Select(fid => new CharacterFeature
            //    {
            //        CharacterId = characterCreationRequest.Character.Id,
            //        FeatureId = fid
            //    }).ToList();

            //_context.CharacterFeatures.AddRange(characterFeatures);
            //await _context.SaveChangesAsync();

            //List<int> classItemIds;

            //if (characterCreationRequest.IsFirstItemSet == true)
            //{
            //    classItemIds = await _context.FirstItemSets
            //        .Where(f => f.ClassId == characterCreationRequest.Character.ClassId)
            //        .Select(f => f.ItemId)
            //        .ToListAsync();
            //}
            //else
            //{
            //    classItemIds = await _context.SecondItemSets
            //        .Where(s => s.ClassId == characterCreationRequest.Character.ClassId)
            //        .Select(s => s.ItemId)
            //        .ToListAsync();
            //}

            //var backgroundItemIds = await _context.BackgroundItems
            //    .Where(b => b.BackgroundId == characterCreationRequest.Character.BackgroundId)
            //    .Select(b => b.ItemId)
            //    .ToListAsync();

            //var allItemIds = classItemIds.Concat(backgroundItemIds).ToList();
            //var characterInventoryItems = allItemIds.Select(itemId => new CharacterInventory
            //{
            //    CharacterId = characterCreationRequest.Character.Id,
            //    ItemId = itemId,
            //    Quantity = 1
            //}).ToList();

            //_context.CharacterInventories.AddRange(characterInventoryItems);
            //await _context.SaveChangesAsync();

            //var characterClass = await _context.Classes
            //    .FirstOrDefaultAsync(c => c.Id == characterCreationRequest.Character.ClassId);

            //if (characterClass != null)
            //{
            //    var savingThrow = new CharacterSavingThrow
            //    {
            //        CharacterId = characterCreationRequest.Character.Id,
            //        Str = characterClass.FirstSavingThrow == "Str" || characterClass.SecondSavingThrow == "Str",
            //        Dex = characterClass.FirstSavingThrow == "Dex" || characterClass.SecondSavingThrow == "Dex",
            //        Con = characterClass.FirstSavingThrow == "Con" || characterClass.SecondSavingThrow == "Con",
            //        int = characterClass.FirstSavingThrow == "int" || characterClass.SecondSavingThrow == "int",
            //        Wis = characterClass.FirstSavingThrow == "Wis" || characterClass.SecondSavingThrow == "Wis",
            //        Cha = characterClass.FirstSavingThrow == "Cha" || characterClass.SecondSavingThrow == "Cha"
            //    };

            //    _context.CharacterSavingThrows.Add(savingThrow);
            //    await _context.SaveChangesAsync();
            //}

            //var backgroundSkillIds = await _context.BackgroundSkills
            //    .Where(bs => bs.BackgroundId == characterCreationRequest.Character.BackgroundId)
            //    .Select(bs => bs.SkillId)
            //    .ToListAsync();

            //var selectedSkillIds = await _context.Skills
            //    .Where(s => characterCreationRequest.SelectedSkillNames.Contains(s.Name))
            //    .Select(s => s.Id)
            //    .ToListAsync();

            //var allSkillIds = backgroundSkillIds.Concat(selectedSkillIds).Distinct().ToList();
            //var characterSkill = new CharacterSkill { CharacterId = characterCreationRequest.Character.Id };

            //foreach (var skillId in allSkillIds)
            //{
            //    switch (skillId)
            //    {
            //        case 1: characterSkill.Acrobatics = true; break;
            //        case 2: characterSkill.AnimalHandling = true; break;
            //        case 3: characterSkill.Arcana = true; break;
            //        case 4: characterSkill.Athletics = true; break;
            //        case 5: characterSkill.Deception = true; break;
            //        case 6: characterSkill.History = true; break;
            //        case 7: characterSkill.Insight = true; break;
            //        case 8: characterSkill.Intimidation = true; break;
            //        case 9: characterSkill.Investigation = true; break;
            //        case 10: characterSkill.Medicine = true; break;
            //        case 11: characterSkill.Nature = true; break;
            //        case 12: characterSkill.Perception = true; break;
            //        case 13: characterSkill.Performance = true; break;
            //        case 14: characterSkill.Persuasion = true; break;
            //        case 15: characterSkill.Religion = true; break;
            //        case 16: characterSkill.SleightOfHand = true; break;
            //        case 17: characterSkill.Stealth = true; break;
            //        case 18: characterSkill.Survival = true; break;
            //    }
            //}

            //_context.CharacterSkills.Add(characterSkill);
            //await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = newCharacter.id }, newCharacter);
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