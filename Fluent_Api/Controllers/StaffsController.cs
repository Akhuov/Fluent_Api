using Fluent_Api.Data;
using Fluent_Api.Dtos;
using Fluent_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly IStaffService _staffService;
        public StaffsController(IStaffService staffService, AppDbContext appDbContext)
        {
            _staffService = staffService;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStaffAsync(StaffDto staffDto)
        {
            var res = _staffService.CreateStaffAsync(staffDto);
            return Ok(res);
        }

        [HttpGet("GetAll")]

        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _staffService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("ById")]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _staffService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpDelete("ById")]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _staffService.DeleteByIdAsync(id);
            return Ok(res);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateStaffById(int id, StaffDto staffDto)
        {
            var res = await _staffService.UpdateStaffAsync(id, staffDto);
            return Ok(res);
        }

        [HttpGet("Ex")]
        public async ValueTask<IActionResult> GetExStaffs(int id)
        {
            try
            {
                var res = await _appDbContext.Staffs.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
