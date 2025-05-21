namespace WebClient.Models;

public class LoreEntry
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}