using ClinicTask.Models;
using System.Numerics;

namespace ClinicTask.Utilities.File
{
	public static class FileExtension
	{
		public static string DownloadImage(this IFormFile formFile,IWebHostEnvironment webHostEnvironment , string imageUploadPath)
		{
			string filename = Guid.NewGuid() + formFile.FileName;
			string path = webHostEnvironment.WebRootPath + imageUploadPath;
			using (FileStream fileStream = new FileStream(path + filename, FileMode.Create))
			{
				formFile.CopyTo(fileStream);
			}
			return filename;
		}
		public static bool CheckTypeImage(this IFormFile formFile)
		{
			if (!formFile.ContentType.Contains("image"))
			{
				return false;
			}
			return true;
		}
	}

}
