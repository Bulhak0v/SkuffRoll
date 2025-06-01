namespace WebClient.Models;

public class Weapon : Item
{
    public bool is_ranged { get; set; }
    public string damage { get; set; }
    public string damage_type { get; set; }
    public bool is_martial { get; set; }

    public ICollection<WeaponTagWeapon> WeaponTagWeapons { get; set; } = new List<WeaponTagWeapon>();
}