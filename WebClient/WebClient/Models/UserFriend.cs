namespace WebClient.Models;

public class UserFriend
{
    public int user_id { get; set; }
    public User User { get; set; }

    public int friend_id { get; set; }
    public User Friend { get; set; }
}