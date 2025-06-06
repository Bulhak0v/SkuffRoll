namespace WebClient.Models;

public class CharacterSavingThrow
{
    public int id { get; set; }
    public int character_id { get; set; }
    public Character Character { get; set; }

    public bool str { get; set; } = false;
    public bool dex { get; set; } = false;
    public bool con { get; set; } = false;
    public bool @int { get; set; } = false;
    public bool wis { get; set; } = false;
    public bool cha { get; set; } = false;
}