using Fluent_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fluent_Api.Configuration
{
    public class StaffsTypeConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Staffs);

            builder.HasMany(x => x.Employees)
                .WithOne(x=>x.Staff);
        }
    }
}
