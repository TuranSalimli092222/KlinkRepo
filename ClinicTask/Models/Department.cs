using System.ComponentModel.DataAnnotations;

namespace ClinicTask.Models
{
    public class Department:BaseModel
    {
        [Required(ErrorMessage = "Başlıq boş ola bilməz.")]
        [MinLength(3),MaxLength(100)]
		public string Title {  get; set; }  

        public ICollection<Doctor>? Doctors { get; set; }
	
    }
}
