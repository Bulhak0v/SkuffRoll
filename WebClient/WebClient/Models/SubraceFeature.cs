namespace WebClient.Models;

public class SubraceFeature
{
	public int subrace_id { get; set; }
	public Subrace Subrace { get; set; }

	public int feature_id { get; set; }
	public Feature Feature { get; set; }
}