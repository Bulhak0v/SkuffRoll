namespace WebClient.Models;

public class UserCharacter
{
    public int user_id { get; set; }
    public User User { get; set; }

    public int character_id { get; set; }
    public Character Character { get; set; }
}