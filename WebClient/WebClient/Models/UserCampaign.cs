namespace WebClient.Models;

public class UserCampaign
{
    public int user_id { get; set; }
    public User User { get; set; }

    public int campaign_id { get; set; }
    public Campaign Campaign { get; set; }
}