namespace WebClient.Models;

public class Race
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public int speed { get; set; }
    public string size { get; set; }
    public int str_increase { get; set; } = 0;
    public int dex_increase { get; set; } = 0;
    public int con_increase { get; set; } = 0;
    public int wis_increase { get; set; } = 0;
    public int int_increase { get; set; } = 0;
    public int cha_increase { get; set; } = 0;
    public bool is_original_content { get; set; } = false;
    public bool is_homebrew { get; set; } = false;

    public ICollection<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
    public ICollection<Subrace> Subraces { get; set; } = new List<Subrace>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}