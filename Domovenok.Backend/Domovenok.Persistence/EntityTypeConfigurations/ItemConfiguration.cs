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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Category)
                .HasMaxLength(50);

            builder.Property(x => x.Brand)
                .HasMaxLength(50);

            builder.Property(x => x.Model)
                .HasMaxLength(50);

            builder.Property(x => x.SerialNumber)
                .HasMaxLength(200);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt);

            // Навигации
            builder.HasOne(x => x.User)
                   .WithMany(p => p.Items)
                   .HasForeignKey(p => p.UserId);

            builder.HasOne(x => x.Guarantee)
                   .WithOne(i => i.Item)
                   .HasForeignKey<Guarantee>(i => i.ItemId);

            builder.HasMany(x => x.Links)
                 .WithOne(i => i.Item)
                 .HasForeignKey(i => i.ItemId);
        }
    }
}
