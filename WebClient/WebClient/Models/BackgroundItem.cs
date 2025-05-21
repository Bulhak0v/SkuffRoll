namespace WebClient.Models;

public class BackgroundItem
{
    public int BackgroundId { get; set; }
    public Background Background { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }
}