namespace WebClient.Models;

public class RaceFeature
{
    public int RaceId { get; set; }
    public Race Race { get; set; }

    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
}