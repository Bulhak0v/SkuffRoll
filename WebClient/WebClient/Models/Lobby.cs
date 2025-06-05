namespace WebClient.Models;

public class Lobby
{
    public int id { get; set; }
    public int? host_id { get; set; }
    public User Host { get; set; }

    public string name { get; set; }
    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }

    public ICollection<UserInLobby> UsersInLobby { get; set; } = new List<UserInLobby>();
}