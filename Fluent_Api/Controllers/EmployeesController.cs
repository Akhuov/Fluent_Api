using Fluent_Api.Data;
using Fluent_Api.Dtos;
using Fluent_Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService, AppDbContext appDbContext)
        {
            _employeeService = employeeService;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var res = _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(res);
        }

        [HttpGet("GetAll")]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _employeeService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("ById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _employeeService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpDelete("ById")]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _employeeService.DeleteByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateEmployeeById(int id, EmployeeDto employeeDto)
        {
            var res = await _employeeService.UpdateEmployeeAsync (id, employeeDto);
            return Ok(res);
        }
    }
}
