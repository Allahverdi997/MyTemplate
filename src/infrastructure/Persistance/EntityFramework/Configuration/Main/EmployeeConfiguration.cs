using Domain.Concrete.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Main
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employees");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(x => x.Surname).HasColumnName("Surname").HasColumnType("nvarchar(100)");

        }
    }
}
