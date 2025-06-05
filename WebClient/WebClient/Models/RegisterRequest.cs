using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
	public class RegisterRequest
	{
		public string email { get; set; }
		public string login { get; set; }
		public string password { get; set; }
	}
}