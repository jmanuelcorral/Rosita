using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Mappings
{
    public class InvoiceMappingConfiguration: EntityMappingConfiguration<Invoice>
    {
        public override void Map(EntityTypeBuilder<Invoice> entity)
        {
            entity.ToTable("Invoice");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Code).HasMaxLength(50).IsRequired();

            //Relational Setup
            entity.HasMany(e => e.InvoiceRecords)
                .WithOne(e => e.Invoice)
                .HasForeignKey(x=>x.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.InvoiceLines)
               .WithOne(e => e.Invoice)
               .HasForeignKey(x => x.InvoiceId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}