namespace WebClient.Models;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

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