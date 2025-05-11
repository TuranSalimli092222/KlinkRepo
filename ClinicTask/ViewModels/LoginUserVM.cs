using System.ComponentModel.DataAnnotations;

namespace ClinicTask.ViewModels
{
	public class LoginUserVM
	{
		[Required]
		public string UserNameOrEmailAddress { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		public bool RememberMe { get; set; }
	}
}
