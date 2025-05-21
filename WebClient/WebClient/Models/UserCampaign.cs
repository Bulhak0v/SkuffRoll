namespace WebClient.Models;

public class UserCampaign
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; }
}