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

    public class DocumentLinkConfiguration : IEntityTypeConfiguration<DocumentLink>
    {
        public void Configure(EntityTypeBuilder<DocumentLink> builder)
        {
            builder.ToTable("Document_Links");

            builder.HasKey(x => new { x.DocumentId, x.ItemId });

            builder.Property(x => x.DocumentId)
                .IsRequired();

            builder.Property(x => x.ItemId)
                .IsRequired();

            // Навигация 
            builder.HasOne(x => x.Document)
                .WithMany(d => d.Links)
                .HasForeignKey(x => x.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
                .WithMany(i => i.Links)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
