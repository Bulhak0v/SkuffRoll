namespace WebClient.Models;

public class BackgroundSkill
{
    public int background_id { get; set; }
    public Background Background { get; set; }

    public int skill_id { get; set; }
    public Skill Skill { get; set; }
}