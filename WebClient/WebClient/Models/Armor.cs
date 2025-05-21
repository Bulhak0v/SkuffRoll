namespace WebClient.Models;

public class Armor : Item
{
    public int ArmorClass { get; set; }
    public int StrengthRequirement { get; set; }
    public bool DisadvantageOnStealth { get; set; }
    public string Type { get; set; }
}