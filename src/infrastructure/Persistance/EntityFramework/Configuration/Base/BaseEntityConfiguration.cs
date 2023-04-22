using Application.Abstraction.Marker;
using Domain.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Base
{
    public class BaseEntityConfiguration<T> : IEntityConfig,IEntityTypeConfiguration<T> where T : BaseSqlEntityWithCreate
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.CreatorId).HasColumnName("CreatorId");
            builder.Property(x => x.EditorId).HasColumnName("EditorId");
            builder.Property(x => x.EditDate).HasColumnName("EditDate");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");

            //builder.HasQueryFilter(x => x.IsActive == true);
        }

    }
}
