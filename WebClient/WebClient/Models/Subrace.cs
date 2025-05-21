namespace WebClient.Models;

public class Subrace
{
    public int Id { get; set; }
    public int RaceId { get; set; }
    public Race Race { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int StrIncrease { get; set; } = 0;
    public int DexIncrease { get; set; } = 0;
    public int ConIncrease { get; set; } = 0;
    public int WisIncrease { get; set; } = 0;
    public int IntIncrease { get; set; } = 0;
    public int ChaIncrease { get; set; } = 0;
    public bool IsOriginalContent { get; set; } = false;

    public ICollection<SubraceFeature> SubraceFeatures { get; set; } = new List<SubraceFeature>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}