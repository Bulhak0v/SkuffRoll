namespace WebClient.Models;

public class Quest
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Reward { get; set; }

    public ICollection<QuestEvent> QuestEvents { get; set; } = new List<QuestEvent>();
}