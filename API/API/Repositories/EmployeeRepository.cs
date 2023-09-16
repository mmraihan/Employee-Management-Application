using API.Data;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _employeeDbContext;

        public EmployeeRepository(DataContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            await _employeeDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeAsyn(int employeeId)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _employeeDbContext.Employees.Remove(employee);
                await _employeeDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _employeeDbContext.Employees.FindAsync(employeeId);

        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeFromDb = _employeeDbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employeeFromDb != null)
            {
                employeeFromDb.FirstName = employee.FirstName;
                employeeFromDb.LastName = employee.LastName;
                employeeFromDb.Gender = employeeFromDb.Gender;
                employeeFromDb.Address = employee.Address;
                employeeFromDb.DateOfBirth = employee.DateOfBirth;
                employeeFromDb.Age = employee.Age;
                employeeFromDb.Email = employee.Email;
                employeeFromDb.JoiningDate = employee.JoiningDate;
                employeeFromDb.Education = employee.Education;
                employeeFromDb.Designation = employee.Designation;
                employeeFromDb.Experience = employee.Experience;
            }

            await _employeeDbContext.SaveChangesAsync();
        }


        public async Task<List<Employee>> GetAllEmployeesAsyncByJoinAndEndingTime(DateTime? fromDate = null, DateTime? toDate = null)
        {

            //var query = _employeeDbContext.Employees.AsQueryable();

            //if (fromDate.HasValue)
            //{
            //    query = query.Where(e => e.JoiningDate >= fromDate.Value);
            //}

            //if (toDate.HasValue)
            //{
            //    query = query.Where(e => e.EndingDate <= toDate.Value || e.EndingDate == null);
            //}

            //var employees = query.ToList();

            //var employeesInDateRange = await _employeeDbContext.Employees
            //    .Where(e => e.DateOfBirth >= fromDate && e.DateOfBirth <= toDate && e.JoiningDate >= fromDate && e.JoiningDate <= toDate)
            //    .ToListAsync();

            var employeesInDateRange = await _employeeDbContext.Employees
                .Where(e => e.JoiningDate >= fromDate && (e.EndingDate == null || e.EndingDate <= toDate))
                .ToListAsync();


            return employeesInDateRange;
        }
    }
}
