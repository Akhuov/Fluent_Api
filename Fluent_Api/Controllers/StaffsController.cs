using Fluent_Api.Dtos;
using Fluent_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
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
    }
}
