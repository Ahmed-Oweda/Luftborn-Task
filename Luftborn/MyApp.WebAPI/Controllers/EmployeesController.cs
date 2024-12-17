using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Services;
using MyApp.WebAPI.Models.Employee;

namespace MyApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllEmployeesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            var employeeDto = new EmployeeDTO
            {
                FirstName = request.FirstName,
                Department = request.Department,
                LastName = request.LastName,
                Email = request.Email,
                CompanyJoinDate = request.CompanyJoinDate
            };
            await _service.AddEmployeeAsync(employeeDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest request)
        {
            await _service.UpdateEmployeeAsync(new EmployeeDTO() { Id = request.Id ,  FirstName = request.FirstName , LastName = request.LastName , Email = request.Email , Department = request.Department , CompanyJoinDate = request.CompanyJoinDate});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
