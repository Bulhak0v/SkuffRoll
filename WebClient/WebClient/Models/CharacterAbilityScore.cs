namespace WebClient.Models;

public class CharacterAbilityScore
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int StrScore { get; set; }
    public int DexScore { get; set; }
    public int ConScore { get; set; }
    public int IntScore { get; set; }
    public int WisScore { get; set; }
    public int ChaScore { get; set; }
}