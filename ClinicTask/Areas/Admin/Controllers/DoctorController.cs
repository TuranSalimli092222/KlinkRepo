using ClinicTask.DAL;
using ClinicTask.Models;
using ClinicTask.Utilities.File;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicTask.Areas.Admin.Controllers;

[Area("Admin")]
public class DoctorController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public DoctorController(AppDbContext context , IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Index()
    {
        List<Doctor> doctors = _context.Doctors.Include("Department").ToList();
		return View(doctors);

	}
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Doctor doctor)
    {
     /*   if (!ModelState.IsValid)
        {
            return BadRequest("Samething went wrong!");
        }*/

        if (doctor.ImageUpload.CheckTypeImage())
        {
			ModelState.AddModelError("image", "File must be Image form!");
			return View(doctor);
		}
        string filename = doctor.ImageUpload.DownloadImage( _webHostEnvironment , @"\UploadImages\doctors\" );
        doctor.ImgUrl = filename;
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int id)
    {
        Doctor? doctor = _context.Doctors.Find(id);
        if (doctor == null) { return NotFound("Doctor could not found"); }
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Update(int id)
    {
        Doctor? doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor == null)
        {
            return NotFound();
        }

        return View(doctor);
    }

    [HttpPost]
    public IActionResult Update(Doctor doctor)
    {
        Doctor? existingdoctor = _context.Doctors.AsNoTracking().FirstOrDefault(d => d.Id == doctor.Id);
        if (!ModelState.IsValid)
        {
            BadRequest("Samething wnet wrong!");
        }
        existingdoctor.FullName = doctor.FullName;
        existingdoctor.DepartmentId = doctor.DepartmentId;

        if (doctor.ImageUpload is not null)
        {
			string fileName = doctor.ImageUpload.FileName;
			string path = @"C:\Users\Turan Salimli\source\repos\ClinicTask\ClinicTask\wwwroot\UploadImages\doctors\";

			using (FileStream fileStream = new FileStream(path + fileName, FileMode.Create))
			{
				doctor.ImageUpload.CopyTo(fileStream);
			}
			existingdoctor.ImgUrl = fileName;
		}

        _context.Doctors.Update(existingdoctor);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
   /* public IActionResult Register()*/
   
}
