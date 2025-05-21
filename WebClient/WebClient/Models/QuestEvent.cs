namespace WebClient.Models;

public class QuestEvent
{
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int QuestId { get; set; }
    public Quest Quest { get; set; }

    public int? LocationId { get; set; }
    public Location Location { get; set; }
}