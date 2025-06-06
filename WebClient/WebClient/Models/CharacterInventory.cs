namespace WebClient.Models;

public class CharacterInventory
{
    public int character_id { get; set; }
    public Character Character { get; set; }

    public int item_id { get; set; }
    public Item Item { get; set; }

    public int quantity { get; set; } = 1;
}