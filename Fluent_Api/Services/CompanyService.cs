using Fluent_Api.Data;
using Fluent_Api.Dtos;
using Fluent_Api.Entities;
using Fluent_Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fluent_Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _appDbContext;
        public CompanyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async ValueTask<string> CreateCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                var com = new Company()
                {
                    Name = companyDto.Name,
                };
                await _appDbContext.Company.AddAsync(com);
                await _appDbContext.SaveChangesAsync();
                return "New Company Created";
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
                var res = await _appDbContext.Company.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _appDbContext.Company.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "Company Deleted";
                }
                else { return "Company not Found!"; }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Company>> GetAllAsync()
        {
            try
            {
                var res = await _appDbContext.Company.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Company> GetByIdAsync(int id)
        {
            try
            {
                var res = await _appDbContext.Company.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateCompanyAsync(int id, CompanyDto companyDto)
        {
            try
            {
                var com = await _appDbContext.Company.FirstOrDefaultAsync(x => x.Id == id);
                if (com != null)
                {
                    com.Name = companyDto.Name;
                    await _appDbContext.SaveChangesAsync();
                    return "Company Updated";
                }
                else
                {
                    return "Company not found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
