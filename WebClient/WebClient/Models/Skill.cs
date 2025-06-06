namespace WebClient.Models;

public class Skill
{
    public int id { get; set; }
    public string name { get; set; }

    public ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();
    public ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();
}