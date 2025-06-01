namespace WebClient.Models;

public class ClassSkill
{
    public int class_id { get; set; }
    public Class Class { get; set; }

    public int skill_id { get; set; }
    public Skill Skill { get; set; }
}