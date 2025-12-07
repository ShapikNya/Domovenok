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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.PasswordHash)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasConversion<string>()
                .HasMaxLength(16)
                 .HasDefaultValue(RoleType.User)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(30);

            builder.Property(x => x.BirthDate)
                .HasColumnType("date");

            builder.Property(x => x.Phone)
                .HasMaxLength(20);

            builder.Property(x => x.AvatarUrl)
                .HasMaxLength(256)
                .IsRequired()
                .HasDefaultValue("/defaultAvatar.png");

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .HasColumnType("date")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt);

            // Навигации
            builder.HasOne(x => x.UserPreferences)
                   .WithOne(p => p.User)
                   .HasForeignKey<UserPreferences>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Items)
                   .WithOne(i => i.User)
                   .HasForeignKey(i => i.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Documents)
                   .WithOne(i => i.User)
                   .HasForeignKey(i => i.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
