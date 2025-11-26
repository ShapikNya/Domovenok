using Domovenok.Domain.Entities;
using Domovenok.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Persistence.EntityTypeConfigurations
{
    public class UserPreferencesConfiguration : IEntityTypeConfiguration<UserPreferences>
    {
        public void Configure(EntityTypeBuilder<UserPreferences> builder)
        {
            builder.ToTable("UserPreferences");

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserId)
              .ValueGeneratedNever();

            builder.Property(x => x.Theme)
                .HasConversion<string>()
                .HasMaxLength(16)
                .HasDefaultValue(ThemeType.Light)
                .IsRequired();

            builder.Property(x => x.Language)
                .HasConversion<string>()
                .HasMaxLength(16)
                .HasDefaultValue(LanguageType.Russia)
                .IsRequired();

            builder.Property(x => x.NotificationsEnabled)
               .HasDefaultValue(true)
               .IsRequired();

            builder.Property(x => x.EmailNotifications)
               .HasDefaultValue(false)
               .IsRequired();

            builder.Property(x => x.PushNotifications)
               .HasDefaultValue(false)
               .IsRequired();

            builder.Property(x => x.ReminderDaysDefault)
               .HasDefaultValue(7)
               .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne(u => u.UserPreferences)
                .HasForeignKey<UserPreferences>(p => p.UserId);

        }
    }
}
