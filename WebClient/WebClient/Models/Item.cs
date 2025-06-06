namespace WebClient.Models;

public class Item
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string picture { get; set; }
    public decimal weight { get; set; }
    public decimal price { get; set; }

    public ICollection<FirstItemSet> FirstItemSets { get; set; } = new List<FirstItemSet>();
    public ICollection<SecondItemSet> SecondItemSets { get; set; } = new List<SecondItemSet>();
    public ICollection<BackgroundItem> BackgroundItems { get; set; } = new List<BackgroundItem>();
    public ICollection<CharacterInventory> CharacterInventories { get; set; } = new List<CharacterInventory>();
}