namespace WebClient.Models;

public class Quest
{
    public int id { get; set; }
    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public string reward { get; set; }

    public ICollection<QuestEvent> QuestEvents { get; set; } = new List<QuestEvent>();
}