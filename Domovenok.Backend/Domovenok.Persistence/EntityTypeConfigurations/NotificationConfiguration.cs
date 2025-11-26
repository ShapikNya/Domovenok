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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();
            //EventType
            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.IsRead)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.RelatedEntityId);

            //EntityType
            builder.Property(x => x.RelatedEntityType)
                .HasConversion<string>()
                .HasMaxLength(32);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .HasColumnType("date")
                .ValueGeneratedOnAdd();

            //Навигации
            builder.HasOne(x => x.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(x => x.UserId);

            // Индексы
            builder.HasIndex(x => x.IsRead);
            builder.HasIndex(x => new { x.UserId, x.IsRead });
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.UserId);
        }
    }
}
