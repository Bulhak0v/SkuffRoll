using System.Runtime.CompilerServices;

namespace WebClient.Models.ClassDataNamespace;

public class ClassData
{
    public string name { get; set; }
    public string? image { get; set; }
    //public string? imageFile { get; set; }
    public string description { get; set; }

    public StartingEquipment startingEquipment { get; set; }
    public Proficiencies proficiencies { get; set; }
    public SkillChoices skillChoices { get; set; }
    public HitPoints hitPoints { get; set; }
    public List<FeatureEntry> featuresTable { get; set; }

    public static Class ClassDataConvert(ClassData classData)
    {
        Class newClass = new Class();

        newClass.Name = classData.name;
        newClass.Description = classData.description;

        newClass.Picture = classData.image ?? string.Empty; // Default to empty string if image is null

        if (classData.proficiencies != null)
        {
            newClass.ArmorProficiency = classData.proficiencies.armor ?? string.Empty;
            newClass.WeaponProficiency = classData.proficiencies.weapons ?? string.Empty;
            newClass.ToolProficiency = classData.proficiencies.tools ?? string.Empty;
            newClass.AmountOfProficientSkills = classData.proficiencies.skills; // This is a direct int mapping
        }
        else
        {
            newClass.ArmorProficiency = string.Empty;
            newClass.WeaponProficiency = string.Empty;
            newClass.ToolProficiency = string.Empty;
            newClass.AmountOfProficientSkills = 0;
        }

        if (classData.proficiencies != null && !string.IsNullOrWhiteSpace(classData.proficiencies.savingThrows))
        {
            var savingThrowsArray = classData.proficiencies.savingThrows
                                    .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(s => s.Trim())
                                    .ToList();

            newClass.FirstSavingThrow = savingThrowsArray.FirstOrDefault() ?? string.Empty;
            newClass.SecondSavingThrow = savingThrowsArray.Skip(1).FirstOrDefault() ?? string.Empty;
        }
        else
        {
            newClass.FirstSavingThrow = string.Empty;
            newClass.SecondSavingThrow = string.Empty;
        }


        if (classData.hitPoints != null && !string.IsNullOrWhiteSpace(classData.hitPoints.hpAt1stLevel))
        {
            int parsedHp;
            if (int.TryParse(classData.hitPoints.hpAt1stLevel, out parsedHp))
            {
                newClass.StartingHp = parsedHp;
            }
            else
            {
                newClass.StartingHp = 0; // Default or log error if parsing fails
            }
        }
        else
        {
            newClass.StartingHp = 0; // Default if hitPoints or hpAt1stLevel is null/empty
        }

        newClass.IsOriginalContent = false;
        newClass.IsHomebrew = true;

        return newClass;
    }

}

public class StartingEquipment
{
    public List<OptionSet> optionSets { get; set; }
    public List<string> @fixed { get; set; }
}

public class OptionSet
{
    public string setA { get; set; }
    public string setB { get; set; }
}

public class Proficiencies
{
    public string armor { get; set; }
    public string weapons { get; set; }
    public string tools { get; set; }
    public string savingThrows { get; set; }
    public int skills { get; set; }
}

public class SkillChoices
{
    public int count { get; set; }
    public List<string> options { get; set; }
}

public class HitPoints
{
    public string hitDice { get; set; }
    public string hpAt1stLevel { get; set; }
    public string hpAtHigherLevels { get; set; }
}

public class FeatureEntry
{
    public string level { get; set; }
    public string feature { get; set; }
}