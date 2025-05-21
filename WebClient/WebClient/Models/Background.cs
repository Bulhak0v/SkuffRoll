namespace WebClient.Models;

public class Background
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ToolProficiencies { get; set; }
    public string VehicleProficiencies { get; set; }
    public bool IsOriginalContent { get; set; } = false;

    public ICollection<BackgroundItem> BackgroundItems { get; set; } = new List<BackgroundItem>();
    public ICollection<BackgroundFeature> BackgroundFeatures { get; set; } = new List<BackgroundFeature>();
    public ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}