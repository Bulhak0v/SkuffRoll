namespace WebClient.Models;

public class Message
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public string MessageContent { get; set; }

    public ICollection<LobbyChat> LobbyChats { get; set; } = new List<LobbyChat>();
    public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
}