using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rosita.Infrastructure.Database.Entities;
using Rosita.XCutting.EntityFramework;

namespace Rosita.Infrastructure.Database.Mappings
{
    public class AddressMappingConfiguration: EntityMappingConfiguration<Address>
    {
        public override void Map(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Addresses");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Description).HasMaxLength(50);
            entity.Property(x => x.Address1).HasMaxLength(200);
            entity.Property(x => x.Address2).HasMaxLength(200);
            entity.Property(x => x.Address3).HasMaxLength(200);
            entity.Property(x => x.City).HasMaxLength(120);
            entity.Property(x => x.State).HasMaxLength(50);
            entity.Property(x => x.PostalCode).HasMaxLength(50);


        }
    }
}