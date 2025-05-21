namespace WebClient.Models;

public class Race
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Speed { get; set; }
    public string Size { get; set; }
    public int StrIncrease { get; set; } = 0;
    public int DexIncrease { get; set; } = 0;
    public int ConIncrease { get; set; } = 0;
    public int WisIncrease { get; set; } = 0;
    public int IntIncrease { get; set; } = 0;
    public int ChaIncrease { get; set; } = 0;
    public bool IsOriginalContent { get; set; } = false;
    public bool IsHomebrew { get; set; } = false;

    public ICollection<RaceFeature> RaceFeatures { get; set; } = new List<RaceFeature>();
    public ICollection<Subrace> Subraces { get; set; } = new List<Subrace>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}