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
            return  await _employeeDbContext.Employees.FindAsync(employeeId);
                   
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _employeeDbContext.Entry(employee).State = EntityState.Modified;
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
