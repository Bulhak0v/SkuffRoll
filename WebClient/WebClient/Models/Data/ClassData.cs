using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebClient.Models.ClassDataNamespace;

public class ClassData
{
    public string name { get; set; }
    public string? image { get; set; }
    public string description { get; set; }
    public StartingEquipment startingEquipment { get; set; }
    public Proficiences proficiencies { get; set; }
    public SkillChoices skillChoices { get; set; }
    public HitPoints hitPoints { get; set; }

    public List<FeatureData> FeaturesTable { get; set; }

    public Class ConvertToClass(DbContext _context)
    {
        var result = new Class
        {
            name = this.name,
            description = this.description,
            picture = this.image ?? "",
            armor_proficiency = this.proficiencies.armor,
            weapon_proficiency = this.proficiencies.weapons,
            tool_proficiency = this.proficiencies.tools,
            is_homebrew = true,
            is_original_content = false,
            starting_hp = int.TryParse(this.hitPoints.hpAt1stLevel, out int hp) ? hp : 0,
            amount_of_proficient_skills = int.TryParse(this.skillChoices.count, out int count) ? count : 0,

            first_saving_throw = this.proficiencies.savingThrows.Split(',').ElementAtOrDefault(0)?.Trim() ?? "",
            second_saving_throw = this.proficiencies.savingThrows.Split(',').ElementAtOrDefault(1)?.Trim() ?? ""
        };
        return result;
    }

}

public class StartingEquipment
{
    public List<OptionSets> optionSets { get; set; }
    public List<string> @fixed { get; set; }
}

public class OptionSets
{
    public string setA { get; set; }
    public string setB { get; set; }
}

public class Proficiences
{
    public string armor { get; set; }
    public string weapons { get; set; }
    public string tools { get; set; }
    public string savingThrows { get; set; }
}

public class SkillChoices
{
    public string count { get; set; }
    public List<string> options { get; set; }
}

public class HitPoints
{
    public string hpAt1stLevel { get; set; }
}

public class FeatureData
{
    public string level { get; set; }
    public string feature { get; set; }
}