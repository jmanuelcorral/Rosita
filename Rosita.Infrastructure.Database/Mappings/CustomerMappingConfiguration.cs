using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Mappings
{
    public class CustomerMappingConfiguration : EntityMappingConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Client");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Subject).HasMaxLength(500).IsRequired();
            entity.Property(x=> x.LegalDocument).HasMaxLength(50).IsRequired();
            entity.Property(x => x.email).HasMaxLength(500);
            
            //Relational Setup
            entity.HasMany(e => e.Addresses).WithOne(e => e.Client);
            entity.HasMany(e => e.Invoices).WithOne(e => e.Client);
            

        }
    }
}