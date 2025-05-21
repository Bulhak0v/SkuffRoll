namespace WebClient.Models;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
    public ICollection<SubraceFeature> SubraceFeatures { get; set; } = new List<SubraceFeature>();
    public ICollection<BackgroundFeature> BackgroundFeatures { get; set; } = new List<BackgroundFeature>();
    public ICollection<CharacterFeature> CharacterFeatures { get; set; } = new List<CharacterFeature>();
}