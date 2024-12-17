using System.ComponentModel.DataAnnotations;

namespace MyApp.WebAPI.Models.Employee
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public DateTime CompanyJoinDate { get; set; }
    }
}
