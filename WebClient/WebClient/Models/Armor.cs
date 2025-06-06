namespace WebClient.Models;

public class Armor : Item
{
    public int armor_class { get; set; }
    public int strength_requirement { get; set; }
    public bool disadvantage_on_stealth { get; set; }
    public string type { get; set; }
}