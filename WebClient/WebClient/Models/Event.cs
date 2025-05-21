namespace WebClient.Models;

public class Event
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }

    public Squad Squad { get; set; }
    public Location Location { get; set; }
    public ICollection<QuestEvent> QuestEvents { get; set; } = new List<QuestEvent>();
}