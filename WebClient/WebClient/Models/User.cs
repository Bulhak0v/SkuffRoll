namespace WebClient.Models;

public class User
{
    public int id { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public DateTime registration_date { get; set; } = DateTime.UtcNow;

    public ICollection<UserFriend> UserFriends { get; set; } = new List<UserFriend>();
    public ICollection<UserFriend> FriendOfUsers { get; set; } = new List<UserFriend>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();
    public ICollection<UserCharacter> UserCharacters { get; set; } = new List<UserCharacter>();
    public ICollection<UserCampaign> UserCampaigns { get; set; } = new List<UserCampaign>();
    public ICollection<Lobby> HostedLobbies { get; set; } = new List<Lobby>();
    public ICollection<UserInLobby> UsersInLobby { get; set; } = new List<UserInLobby>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<PrivateMessage> PrivateMessagesReceived { get; set; } = new List<PrivateMessage>();
}