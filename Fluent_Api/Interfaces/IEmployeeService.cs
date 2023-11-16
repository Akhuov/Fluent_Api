using Fluent_Api.Dtos;
using Fluent_Api.Entities;

namespace Fluent_Api.Interfaces
{
    public interface IEmployeeService
    {
        public ValueTask<string> CreateEmployeeAsync(EmployeeDto employeeDto);
        public ValueTask<List<Employee>> GetAllAsync();
        public ValueTask<Employee> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateEmployeeAsync(int id ,EmployeeDto employeeDto);
    }
}
