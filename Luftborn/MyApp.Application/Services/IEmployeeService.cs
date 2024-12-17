using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeDTO employee);
        Task UpdateEmployeeAsync(EmployeeDTO employee);
        Task DeleteEmployeeAsync(int id);
    }
}
