namespace WebClient.Models;

public class BackgroundFeature
{
    public int background_id { get; set; }
    public Background Background { get; set; }

    public int feature_id { get; set; }
    public Feature Feature { get; set; }
}