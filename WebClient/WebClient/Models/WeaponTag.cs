namespace WebClient.Models;

public class WeaponTag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<WeaponTagWeapon> WeaponTagWeapons { get; set; } = new List<WeaponTagWeapon>();
}