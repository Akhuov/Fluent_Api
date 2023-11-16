using Fluent_Api.Dtos;
using Fluent_Api.Entities;

namespace Fluent_Api.Interfaces
{
    public interface ICompanyService
    {
        public ValueTask<string> CreateCompanyAsync(CompanyDto companyDto);
        public ValueTask<List<Company>> GetAllAsync();
        public ValueTask<Company> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateCompanyAsync(int id, CompanyDto companyDto);
    }
}
