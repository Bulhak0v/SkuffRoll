namespace WebClient.Models;

public class Lobby
{
    public int Id { get; set; }
    public int? HostId { get; set; }
    public User Host { get; set; }

    public string Name { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public ICollection<UserInLobby> UsersInLobby { get; set; } = new List<UserInLobby>();
}