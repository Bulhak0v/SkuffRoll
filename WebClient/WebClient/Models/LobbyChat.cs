namespace WebClient.Models;

public class LobbyChat
{
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }

    public int MessageId { get; set; }
    public Message Message { get; set; }
}