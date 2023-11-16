using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fluent_Api.Entities;

namespace Fluent_Api.Новая_папка
{
    public class EmployeesTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(x => x.Staff)
                .WithMany(x => x.Employees);
        }
    }
}
