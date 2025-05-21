namespace WebClient.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public decimal Weight { get; set; }
    public decimal Price { get; set; }

    public ICollection<FirstItemSet> FirstItemSets { get; set; } = new List<FirstItemSet>();
    public ICollection<SecondItemSet> SecondItemSets { get; set; } = new List<SecondItemSet>();
    public ICollection<BackgroundItem> BackgroundItems { get; set; } = new List<BackgroundItem>();
    public ICollection<CharacterInventory> CharacterInventories { get; set; } = new List<CharacterInventory>();
}