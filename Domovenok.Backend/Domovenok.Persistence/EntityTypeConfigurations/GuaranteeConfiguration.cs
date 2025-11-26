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
    public class GuaranteeConfiguration : IEntityTypeConfiguration<Guarantee>
    {
        public void Configure(EntityTypeBuilder<Guarantee> builder)
        {
            builder.ToTable("Guarantees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ItemId)
               .IsRequired();

            builder.Property(x => x.Provider)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(16);

            builder.Property(x => x.WarrantyStart)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.WarrantyEnd)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.FileUrl)
               .HasMaxLength(256);

            builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("NOW()")
               .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt);

            // Навигации
            builder.HasOne(x => x.Item)
                   .WithOne(p => p.Guarantee)
                   .HasForeignKey<Guarantee>(p => p.ItemId);

        }
    } 
}
