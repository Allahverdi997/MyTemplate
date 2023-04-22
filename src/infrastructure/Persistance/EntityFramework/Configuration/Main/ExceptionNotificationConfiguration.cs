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
    public class ExceptionNotificationConfiguration : BaseEntityConfiguration<ExceptionNotification>
    {
        public override void Configure(EntityTypeBuilder<ExceptionNotification> builder)
        {
            base.Configure(builder);

            builder.ToTable("ExceptionNotifications");

            builder.Property(x => x.Key).HasColumnName("Key").HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(500)").IsUnicode(true).UseCollation("Cyrillic_General_CI_AS");

            builder.HasOne(x=>x.Lang)
                .WithMany(x=>x.ExceptionNotifications)
                .HasForeignKey(x=>x.LangId);
        }
    }
}
