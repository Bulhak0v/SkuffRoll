namespace WebClient.Models;

public class UserInLobby
{
    public int lobby_id { get; set; }
    public Lobby Lobby { get; set; }

    public int user_id { get; set; }
    public User User { get; set; }
}