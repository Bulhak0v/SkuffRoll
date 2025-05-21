namespace WebClient.Models;

public class CharacterSkill
{
	public int Id { get; set; }
	public int CharacterId { get; set; }
	public Character Character { get; set; }

	public bool Acrobatics { get; set; } = false;
	public bool AnimalHandling { get; set; } = false;
	public bool Arcana { get; set; } = false;
	public bool Athletics { get; set; } = false;
	public bool Deception { get; set; } = false;
	public bool History { get; set; } = false;
	public bool Insight { get; set; } = false;
	public bool Intimidation { get; set; } = false;
	public bool Investigation { get; set; } = false;
	public bool Medicine { get; set; } = false;
	public bool Nature { get; set; } = false;
	public bool Perception { get; set; } = false;
	public bool Performance { get; set; } = false;
	public bool Persuasion { get; set; } = false;
	public bool Religion { get; set; } = false;
	public bool SleightOfHand { get; set; } = false;
	public bool Stealth { get; set; } = false;
	public bool Survival { get; set; } = false;
}