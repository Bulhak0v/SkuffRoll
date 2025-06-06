namespace WebClient.Models;

public class Character
{
    public int id { get; set; }
    public int? user_id { get; set; }
    public User User { get; set; }

    public string name { get; set; }
    public string appearance { get; set; }
    public string alignment { get; set; }
    public string gender { get; set; }
    public int age { get; set; }
    public decimal weight { get; set; }
    public decimal height { get; set; }
    public string flaws { get; set; }
    public string bonds { get; set; }
    public string ideals { get; set; }
    public string personality_traits { get; set; }
    public string backstory { get; set; }
    public int hp { get; set; }
    public int level { get; set; } = 1;

    public int? class_id { get; set; }
    public Class Class { get; set; }

    public int? race_id { get; set; }
    public Race Race { get; set; }

    public int? subrace_id { get; set; }
    public Subrace Subrace { get; set; }

    public int? background_id { get; set; }
    public Background Background { get; set; }

    public int speed { get; set; }
    public int armor_class { get; set; }
    public string image { get; set; }
    public string armor_proficiency { get; set; }
    public string weapon_proficiency { get; set; }
    public string vehicle_proficiency { get; set; }
    public string tool_proficiency { get; set; }

    public ICollection<CharacterAbilityScore> AbilityScores { get; set; } = new List<CharacterAbilityScore>();
    public ICollection<CharacterSkill> CharacterSkills { get; set; } = new List<CharacterSkill>();
    public ICollection<CharacterSavingThrow> CharacterSavingThrows { get; set; } = new List<CharacterSavingThrow>();
    public ICollection<CharacterFeature> CharacterFeatures { get; set; } = new List<CharacterFeature>();
    public ICollection<CharacterInventory> CharacterInventories { get; set; } = new List<CharacterInventory>();
    public ICollection<UserCharacter> UserCharacters { get; set; } = new List<UserCharacter>();
}