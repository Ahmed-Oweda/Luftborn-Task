using System.ComponentModel.DataAnnotations;

namespace MyApp.WebAPI.Models.Employee
{
    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime CompanyJoinDate { get; set; }
    }
}
