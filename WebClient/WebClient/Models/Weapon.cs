namespace WebClient.Models;

public class Weapon : Item
{
    public bool IsRanged { get; set; }
    public string Damage { get; set; }
    public string DamageType { get; set; }
    public bool IsMartial { get; set; }

    public ICollection<WeaponTagWeapon> WeaponTagWeapons { get; set; } = new List<WeaponTagWeapon>();
}