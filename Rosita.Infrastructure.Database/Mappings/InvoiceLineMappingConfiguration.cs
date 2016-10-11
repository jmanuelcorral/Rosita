using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Mappings
{
    public class InvoiceLineMappingConfiguration : EntityMappingConfiguration<InvoiceLine>
    {
        public override void Map(EntityTypeBuilder<InvoiceLine> entity)
        {
            entity.ToTable("InvoiceLine");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Description).HasColumnType("text").IsRequired();
        }
    }
}