namespace WebClient.Models;

public class CharacterSavingThrow
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public bool Str { get; set; } = false;
    public bool Dex { get; set; } = false;
    public bool Con { get; set; } = false;
    public bool Int { get; set; } = false;
    public bool Wis { get; set; } = false;
    public bool Cha { get; set; } = false;
}