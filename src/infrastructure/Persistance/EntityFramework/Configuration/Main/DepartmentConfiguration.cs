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
    public class DepartmentConfiguration : BaseEntityConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.ToTable("Departments");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");

            //Relations
            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}
