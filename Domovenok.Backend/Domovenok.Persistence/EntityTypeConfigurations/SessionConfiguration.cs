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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd(); 

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.TokenHash)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(x => x.IpAddress)
                   .HasMaxLength(64)
                   .IsRequired();

            builder.Property(x => x.UserAgent)
                   .HasMaxLength(512)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .HasColumnType("date")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ExpiresAt)
                .IsRequired();

            // Навигации
            builder.HasOne(x => x.User)
                   .WithMany(u => u.Sessions)
                   .HasForeignKey(x => x.UserId);

            // Индексы
            builder.HasIndex(x => x.UserId);

            builder.HasIndex(x => x.ExpiresAt);
        }
    }
}
