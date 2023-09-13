using API.Model;
using Azure;

namespace API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int employeeId);

        Task AddEmployeeAsync(Employee employee);

        Task UpdateEmployeeAsync(int id, Employee employee);

        Task DeleteEmployeAsyn(int employeeId);
    }
}
