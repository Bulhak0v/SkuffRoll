namespace WebClient.Models;

public class BackgroundItem
{
    public int background_id { get; set; }
    public Background Background { get; set; }

    public int item_id { get; set; }
    public Item Item { get; set; }
}