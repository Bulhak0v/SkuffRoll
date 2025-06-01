namespace WebClient.Models;

public class CharacterFeature
{
    public int character_id { get; set; }
    public Character Character { get; set; }

    public int feature_id { get; set; }
    public Feature Feature { get; set; }
}