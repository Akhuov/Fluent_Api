using Fluent_Api.Data;
using Fluent_Api.Dtos;
using Fluent_Api.Entities;
using Fluent_Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Services
{
    public class StaffService : IStaffService
    {

        private readonly AppDbContext _appDbContext;
        public StaffService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async ValueTask<string> CreateStaffAsync(StaffDto staffDto)
        {
            try
            {
                var emp = new Staff()
                {
                    Name = staffDto.Name,
                    CompanyId = staffDto.CompanyId,
                };
                await _appDbContext.Staffs.AddAsync(emp);
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
                var res = await _appDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _appDbContext.Staffs.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "Staff Deleted";
                }
                else { return "Staff not Found!"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Staff>> GetAllAsync()
        {
            try
            {
                var res = await _appDbContext.Staffs.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Staff> GetByIdAsync(int id)
        {
            try
            {
                var res = await _appDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateStaffAsync(int id, StaffDto staffDto)
        {
            try
            {
                var stf = await _appDbContext.Staffs.FirstOrDefaultAsync(x => x.Id == id);
                if (stf != null)
                {
                    stf.Name = staffDto.Name;
                    stf.CompanyId = staffDto.CompanyId;
                    await _appDbContext.SaveChangesAsync();
                    return "Staff Updated";
                }
                else
                {
                    return "Staff not found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
