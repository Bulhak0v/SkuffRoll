namespace WebClient.Models;

public class Class
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string picture { get; set; }
    public string armor_proficiency { get; set; }
    public string weapon_proficiency { get; set; }
    public string tool_proficiency { get; set; }
    public int amount_of_proficient_skills { get; set; }
    public string first_saving_throw { get; set; }
    public string second_saving_throw { get; set; }
    public int starting_hp { get; set; }
    public bool is_original_content { get; set; } = false;
    public bool is_homebrew { get; set; } = false;

    public ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();
    public ICollection<LevelingTable> LevelingTables { get; set; } = new List<LevelingTable>();
    public ICollection<FirstItemSet> FirstItemSets { get; set; } = new List<FirstItemSet>();
    public ICollection<SecondItemSet> SecondItemSets { get; set; } = new List<SecondItemSet>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}