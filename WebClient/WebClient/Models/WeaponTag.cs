namespace WebClient.Models;

public class WeaponTag
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public ICollection<WeaponTagWeapon> WeaponTagWeapons { get; set; } = new List<WeaponTagWeapon>();
}