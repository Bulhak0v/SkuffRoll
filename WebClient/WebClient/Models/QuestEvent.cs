namespace WebClient.Models;

public class QuestEvent
{
    public int event_id { get; set; }
    public Event Event { get; set; }

    public int quest_id { get; set; }
    public Quest Quest { get; set; }

    public int? location_id { get; set; }
    public Location Location { get; set; }
}