namespace WebClient.Models;

public class BackgroundSkill
{
    public int BackgroundId { get; set; }
    public Background Background { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}