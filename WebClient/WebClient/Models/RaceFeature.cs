namespace WebClient.Models;

public class RaceFeature
{
    public int race_id { get; set; }
    public Race Race { get; set; }

    public int feature_id { get; set; }
    public Feature Feature { get; set; }
}