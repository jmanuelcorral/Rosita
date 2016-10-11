using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Mappings
{
    public class InvoiceRecordMappingConfiguration: EntityMappingConfiguration<InvoiceRecord>
    {
        public override void Map(EntityTypeBuilder<InvoiceRecord> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.WhoHasModified).HasMaxLength(50).IsRequired();
        }
    }
}