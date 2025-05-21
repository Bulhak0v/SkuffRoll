namespace WebClient.Models;

public class SubraceFeature
{
	public int SubraceId { get; set; }
	public Subrace Subrace { get; set; }

	public int FeatureId { get; set; }
	public Feature Feature { get; set; }
}