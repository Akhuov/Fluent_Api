using Fluent_Api.Data;
using Fluent_Api.Dtos;
using Fluent_Api.Entities;
using Fluent_Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask<string> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                var emp = new Employee()
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    StaffId = employeeDto.StaffId,
                };
                await _appDbContext.Employees.AddAsync(emp);
                await _appDbContext.SaveChangesAsync();
                return "New Employee Created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<string> DeleteByIdAsync(int id)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id );
                if(res!= null)
                {
                    _appDbContext.Employees.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "Employee Deleted";
                }
                else { return "Employee not Found!"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Employee>> GetAllAsync()
        {
            try
            {
                var res = await _appDbContext.Employees.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Employee> GetByIdAsync(int id)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
                return res;
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateEmployeeAsync(int id,EmployeeDto employeeDto)
        {
            try
            {
                var emp = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id ==id);
                if(emp != null)
                {
                    emp.StaffId = employeeDto.StaffId;
                    emp.FirstName = employeeDto.FirstName;
                    emp.LastName = employeeDto.LastName;
                    await _appDbContext.SaveChangesAsync();
                    return "Employee Updated";
                }
                else
                {
                    return "Employee not found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
