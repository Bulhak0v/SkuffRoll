namespace WebClient.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ClassSkill> ClassSkills { get; set; } = new List<ClassSkill>();
    public ICollection<BackgroundSkill> BackgroundSkills { get; set; } = new List<BackgroundSkill>();
}