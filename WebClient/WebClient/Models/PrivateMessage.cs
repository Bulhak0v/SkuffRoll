namespace WebClient.Models;

public class PrivateMessage
{
    public int receiver_id { get; set; }
    public User Receiver { get; set; }

    public int message_id { get; set; }
    public Message Message { get; set; }
}