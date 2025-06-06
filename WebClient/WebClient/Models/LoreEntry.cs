namespace WebClient.Models;

public class LoreEntry
{
    public int id { get; set; }
    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    public string type { get; set; }
}