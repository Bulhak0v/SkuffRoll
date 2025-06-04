using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
	public class RegisterRequest
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(3)]
		public string Login { get; set; }

		[Required]
		[MinLength(6)]
		public string Password { get; set; }
	}
}