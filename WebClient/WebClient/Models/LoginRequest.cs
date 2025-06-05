namespace WebClient.Models
{
    public class LoginRequest
    {
        public string Identifier { get; set; } // can be login or email
        public string Password { get; set; }
    }
}
