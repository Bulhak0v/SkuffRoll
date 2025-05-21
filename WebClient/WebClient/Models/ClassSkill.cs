namespace WebClient.Models;

public class ClassSkill
{
    public int ClassId { get; set; }
    public Class Class { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}