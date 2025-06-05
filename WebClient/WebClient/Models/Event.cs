namespace WebClient.Models;

public class Event
{
    public int id { get; set; }
    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
    public decimal x_coordinate { get; set; }
    public decimal y_coordinate { get; set; }

    public Squad Squad { get; set; }
    public Location Location { get; set; }
    public ICollection<QuestEvent> QuestEvents { get; set; } = new List<QuestEvent>();
}