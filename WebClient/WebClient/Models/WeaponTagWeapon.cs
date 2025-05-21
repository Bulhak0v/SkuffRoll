namespace WebClient.Models;

public class WeaponTagWeapon
{
    public int WeaponId { get; set; }
    public Weapon Weapon { get; set; }

    public int WeaponTagId { get; set; }
    public WeaponTag WeaponTag { get; set; }
}