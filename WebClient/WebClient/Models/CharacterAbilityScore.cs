namespace WebClient.Models;

public class CharacterAbilityScore
{
    public int id { get; set; }
    public int character_id { get; set; }
    public Character Character { get; set; }

    public int str_score { get; set; }
    public int dex_score { get; set; }
    public int con_score { get; set; }
    public int int_score { get; set; }
    public int wis_score { get; set; }
    public int cha_score { get; set; }
}