namespace WebClient.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<UserCampaign> UserCampaigns { get; set; } = new List<UserCampaign>();
    public ICollection<LoreEntry> LoreEntries { get; set; } = new List<LoreEntry>();
    public ICollection<Event> Events { get; set; } = new List<Event>();
    public ICollection<Quest> Quests { get; set; } = new List<Quest>();
    public ICollection<Lobby> Lobbies { get; set; } = new List<Lobby>();
    public ICollection<LobbyChat> LobbyChats { get; set; } = new List<LobbyChat>();
}