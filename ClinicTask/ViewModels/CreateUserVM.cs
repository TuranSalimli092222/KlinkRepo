using System.ComponentModel.DataAnnotations;

namespace ClinicTask.ViewModels
{
	public class CreateUserVM
	{
		[Required]
		[MaxLength(25)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(25)]
		public string LastName { get;set; }
		[Required]
		[MaxLength(30)]
		public string Username { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password) , Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}
