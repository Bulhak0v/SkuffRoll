namespace WebClient.Models;

public class Background
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string tool_proficiencies { get; set; }
    public string vehicle_proficiencies { get; set; }
    public bool is_original_content { get; set; } = false;

    public ICollection<BackgroundItem> BackgroundItems { get; set; } = new List<BackgroundItem>();
    public ICollection<BackgroundFeature> BackgroundFeatures { get; set; } = new List<BackgroundFeature>();
    public ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}