using API.Model;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterdEmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        public FilterdEmployeeController(IEmployeeRepository employeeRepository = null)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees(DateTime fromDate, DateTime toDate)
        {
            var employeesInDateRange = await _employeeRepository.GetAllEmployeesAsyncByJoinAndEndingTime(fromDate, toDate);

            if (employeesInDateRange.Count == 0)
            {
                return NotFound("No employees found in the specified date range.");
            }

            return Ok(employeesInDateRange);
        }
    }
}
