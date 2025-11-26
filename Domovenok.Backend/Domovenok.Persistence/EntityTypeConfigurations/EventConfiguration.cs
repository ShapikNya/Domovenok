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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ItemId);

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);
            
            builder.Property(x => x.EventType)
                .HasConversion<string>()
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.EventDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.IsRecurring)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.RecurrenceFrequency)
                .HasMaxLength(16);

            builder.Property(x => x.RecurrenceInterval);

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.ReminderDaysBefore)
                .HasDefaultValue(3)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasMaxLength(200);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .HasColumnType("date")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CompletedAt);

            // Навигации
            builder.HasOne(x => x.User)
                 .WithMany(u => u.Events)
                 .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Item)
                 .WithMany(i => i.Events)
                 .HasForeignKey(x => x.ItemId)
                 .OnDelete(DeleteBehavior.SetNull);

            // Индексы
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.ItemId);
            builder.HasIndex(x => x.EventDate);
            builder.HasIndex(x => x.IsRecurring);
            builder.HasIndex(x => x.Status);
        }
    }
}
