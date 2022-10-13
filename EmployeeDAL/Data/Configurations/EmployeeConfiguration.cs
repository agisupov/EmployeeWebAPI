using EmployeeDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeDAL.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Fio).IsRequired();
            builder.Property(p => p.JobTitle).IsRequired();

            builder.HasIndex(x => x.Fio).IsUnique();
        }
    }
}
