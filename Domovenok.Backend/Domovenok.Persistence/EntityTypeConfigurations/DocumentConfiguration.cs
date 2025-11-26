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
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Type)
               .HasMaxLength(30);

            builder.Property(x => x.Title)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.Description)
              .HasMaxLength(150);

            builder.Property(x => x.Category)
              .HasMaxLength(30);

            builder.Property(x => x.FileUrl)
               .HasMaxLength(256);

            builder.Property(x => x.FileName)
               .HasMaxLength(150);

            builder.Property(x => x.FileSize)
                .HasColumnType("INT");

            builder.Property(x => x.FileType)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(x => x.ExpiryDate)
                .HasColumnType("date");

            builder.Property(x => x.IsFavorite)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt);

            // Навигации
            builder.HasOne(x => x.User)
                   .WithMany(p => p.Documents)
                   .HasForeignKey(p => p.UserId);

            builder.HasMany(x => x.Links)
                   .WithOne(i => i.Document)
                   .HasForeignKey(i => i.DocumentId);

            //Индексы
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.IsFavorite);
            builder.HasIndex(x => x.ExpiryDate);
        }
    }
}