using ClinicTask.Areas.Admin.ViewModels.Doctors;
using ClinicTask.DAL;
using ClinicTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
	private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
	{
		List<Department> departments;
		departments = _context.Departments.Include(d=>d.Doctors).ToList();
		return View(departments);
	}
	public IActionResult Create()
	{ 
	return View();
	}

	[HttpPost]
	public IActionResult Create(Department department)
	{
        if (!ModelState.IsValid)
        {
            return BadRequest("Samething went wrong!");
        }
        _context.Departments.Add(department);

		_context.SaveChanges();

		return RedirectToAction(nameof(Index));
	}

	public IActionResult Delete(int id)
	{ 
		Department? department = _context.Departments.Find(id);
		if (department == null) {return NotFound("Department could not found");}
		_context.Departments.Remove(department);
		_context.SaveChanges();
		return RedirectToAction(nameof(Index));
	}
    public IActionResult Update(int id)
    {
        Department? department = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost]
    public IActionResult Update(Department department)
    {
		/*department = _context.Departments.FirstOrDefault(d => d.Id == department.Id);*/
		if (!ModelState.IsValid)
        {
            BadRequest("Samething wnet wrong!");
        }

        _context.Departments.Update(department);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    public IActionResult AssignDepartments(int id)
    {
        Department department = _context.Departments.Find(id);
        if (department == null) { return NotFound("Department could not found"); }
        BathAssignVM bathAssignVM = new BathAssignVM()
        {
            DepartmentId = id,
            AllDoctors = _context.Doctors.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.FullName }).ToList(),
            DoctorIds = new List<int>()
        };

        return View(bathAssignVM);
    }
    [HttpPost]
    public IActionResult AssignDepartments(BathAssignVM model)
    {
       List<Doctor> doctors =  _context.Doctors.Where(d=>model.DoctorIds.Contains(d.Id)).ToList();
        foreach (var doctor in doctors)       
        {
            doctor.DepartmentId = model.DepartmentId;
        }
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}

