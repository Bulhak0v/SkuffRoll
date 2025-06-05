namespace WebClient.Models;

public class Subrace
{
    public int id { get; set; }
    public int race_id { get; set; }
    public Race Race { get; set; }

    public string name { get; set; }
    public string description { get; set; }
    public int str_increase { get; set; } = 0;
    public int dex_increase { get; set; } = 0;
    public int con_increase { get; set; } = 0;
    public int wis_increase { get; set; } = 0;
    public int int_increase { get; set; } = 0;
    public int cha_increase { get; set; } = 0;
    public bool is_original_content { get; set; } = false;

    public ICollection<SubraceFeature> SubraceFeatures { get; set; } = new List<SubraceFeature>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}