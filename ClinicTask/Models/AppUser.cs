using Microsoft.AspNetCore.Identity;

namespace ClinicTask.Models
{
	public class AppUser:IdentityUser
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }

	}
}
