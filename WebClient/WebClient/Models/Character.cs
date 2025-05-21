namespace WebClient.Models;

public class Character
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }

    public string Name { get; set; }
    public string Appearance { get; set; }
    public string Alignment { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string Flaws { get; set; }
    public string Bonds { get; set; }
    public string Ideals { get; set; }
    public string PersonalityTraits { get; set; }
    public string Backstory { get; set; }
    public int Hp { get; set; }
    public int Level { get; set; } = 1;

    public int? ClassId { get; set; }
    public Class Class { get; set; }

    public int? RaceId { get; set; }
    public Race Race { get; set; }

    public int? SubraceId { get; set; }
    public Subrace Subrace { get; set; }

    public int? BackgroundId { get; set; }
    public Background Background { get; set; }

    public int Speed { get; set; }
    public int ArmorClass { get; set; }
    public string Image { get; set; }
    public string ArmorProficiency { get; set; }
    public string WeaponProficiency { get; set; }
    public string VehicleProficiency { get; set; }
    public string ToolProficiency { get; set; }

    public ICollection<CharacterAbilityScore> AbilityScores { get; set; } = new List<CharacterAbilityScore>();
    public ICollection<CharacterSkill> CharacterSkills { get; set; } = new List<CharacterSkill>();
    public ICollection<CharacterSavingThrow> CharacterSavingThrows { get; set; } = new List<CharacterSavingThrow>();
    public ICollection<CharacterFeature> CharacterFeatures { get; set; } = new List<CharacterFeature>();
    public ICollection<CharacterInventory> CharacterInventories { get; set; } = new List<CharacterInventory>();
    public ICollection<UserCharacter> UserCharacters { get; set; } = new List<UserCharacter>();
}