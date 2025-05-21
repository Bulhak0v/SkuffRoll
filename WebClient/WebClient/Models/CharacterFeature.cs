namespace WebClient.Models;

public class CharacterFeature
{
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
}