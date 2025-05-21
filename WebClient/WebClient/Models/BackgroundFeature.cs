namespace WebClient.Models;

public class BackgroundFeature
{
    public int BackgroundId { get; set; }
    public Background Background { get; set; }

    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
}