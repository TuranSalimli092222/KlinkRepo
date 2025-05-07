using ClinicTask.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicTask.Areas.Admin.ViewModels.Doctors
{
	public class BathAssignVM
	{
		public int DepartmentId { get; set; }
		public List<SelectListItem>? AllDoctors { get; set; }
		public List<int>? DoctorIds { get; set; }
	}
}
