using Domovenok.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Persistence.EntityTypeConfigurations
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.Action)
                   .HasMaxLength(32)
                   .IsRequired();

            builder.Property(x => x.Data)
                   .HasColumnType("text");

            builder.Property(x => x.IpAddress)
                   .HasMaxLength(64)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("NOW()")
                   .HasColumnType("date")
                   .ValueGeneratedOnAdd();

            // Навигации
            builder.HasOne(x => x.User)
                 .WithMany(u => u.ActivityLogs)
                 .HasForeignKey(x => x.UserId);

            // Индексы
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.Action);
        }
    }
}
