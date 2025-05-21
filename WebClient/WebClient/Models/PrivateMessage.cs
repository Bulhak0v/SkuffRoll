namespace WebClient.Models;

public class PrivateMessage
{
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }

    public int MessageId { get; set; }
    public Message Message { get; set; }
}