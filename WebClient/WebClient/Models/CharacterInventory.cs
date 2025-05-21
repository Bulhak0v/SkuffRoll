namespace WebClient.Models;

public class CharacterInventory
{
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public int Quantity { get; set; } = 1;
}