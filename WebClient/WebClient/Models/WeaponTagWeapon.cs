namespace WebClient.Models;

public class WeaponTagWeapon
{
    public int weapon_id { get; set; }
    public Weapon Weapon { get; set; }

    public int weapon_tag_id { get; set; }
    public WeaponTag WeaponTag { get; set; }
}