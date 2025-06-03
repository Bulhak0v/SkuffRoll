namespace WebClient.Models;

public class LobbyChat
{
    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }

    public int message_id { get; set; }
    public Message Message { get; set; }
}