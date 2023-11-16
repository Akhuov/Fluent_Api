using Fluent_Api.Dtos;
using Fluent_Api.Entities;

namespace Fluent_Api.Interfaces
{
    public interface  IStaffService
    {
        public ValueTask<string> CreateStaffAsync(StaffDto staffDto);
        public ValueTask<List<Staff>> GetAllAsync();
        public ValueTask<Staff> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateStaffAsync(int id, StaffDto staffDto);
    }
}
