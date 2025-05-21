namespace WebClient.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string ArmorProficiency { get; set; }
    public string WeaponProficiency { get; set; }
    public string ToolProficiency { get; set; }
    public int AmountOfProficientSkills { get; set; }
    public string FirstSavingThrow { get; set; }
    public string SecondSavingThrow { get; set; }
    public int StartingHp { get; set; }
    public bool IsOriginalContent { get; set; } = false;
    public bool IsHomebrew { get; set; } = false;

    public ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();
    public ICollection<LevelingTable> LevelingTables { get; set; } = new List<LevelingTable>();
    public ICollection<FirstItemSet> FirstItemSets { get; set; } = new List<FirstItemSet>();
    public ICollection<SecondItemSet> SecondItemSets { get; set; } = new List<SecondItemSet>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}