namespace WebClient.Models;

public class Feature
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public ICollection<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
    public ICollection<SubraceFeature> SubraceFeatures { get; set; } = new List<SubraceFeature>();
    public ICollection<BackgroundFeature> BackgroundFeatures { get; set; } = new List<BackgroundFeature>();
    public ICollection<CharacterFeature> CharacterFeatures { get; set; } = new List<CharacterFeature>();
}