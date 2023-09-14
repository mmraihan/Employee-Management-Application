﻿using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();

            if (employees==null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
           
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            await _employeeRepository.UpdateEmployeeAsync(id, updatedEmployee);

            return Ok();
        }
        

        [HttpPost]

        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRepository.DeleteEmployeAsyn(id);

            return NoContent();
        }

        
    }
}
