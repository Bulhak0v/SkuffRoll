namespace WebClient.Models;

public class CharacterSkill
{
	public int id { get; set; }
	public int character_id { get; set; }
	public Character Character { get; set; }

	public bool acrobatics { get; set; } = false;
	public bool animal_handling { get; set; } = false;
	public bool arcana { get; set; } = false;
	public bool athletics { get; set; } = false;
	public bool deception { get; set; } = false;
	public bool history { get; set; } = false;
	public bool insight { get; set; } = false;
	public bool intimidation { get; set; } = false;
	public bool investigation { get; set; } = false;
	public bool medicine { get; set; } = false;
	public bool nature { get; set; } = false;
	public bool perception { get; set; } = false;
	public bool performance { get; set; } = false;
	public bool persuasion { get; set; } = false;
	public bool religion { get; set; } = false;
	public bool sleight_of_hand { get; set; } = false;
	public bool stealth { get; set; } = false;
	public bool survival { get; set; } = false;
}