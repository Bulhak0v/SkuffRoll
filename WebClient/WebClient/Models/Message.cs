namespace WebClient.Models;

public class Message
{
    public int id { get; set; }
    public int? user_id { get; set; }
    public User User { get; set; }

    public DateTime creation_date { get; set; } = DateTime.UtcNow;
    public string message_content { get; set; }

    public ICollection<LobbyChat> LobbyChats { get; set; } = new List<LobbyChat>();
    public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
}