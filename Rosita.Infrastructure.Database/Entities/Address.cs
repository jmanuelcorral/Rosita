using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rosita.Infrastructure.Database.Entities
{
    public class Address:BaseDao<Guid>
    {
       
        public Guid ClientId { get; set; }

        public string Description { get; set; }

        
        public byte AddressType { get; set; }

       
        public string Address1 { get; set; }

        
        public string Address2 { get; set; }

       
        public string Address3 { get; set; }

        
        public string City { get; set; }

        
        public string State { get; set; }

        
        public string Country { get; set; }

       
        public string PostalCode { get; set; }

        public virtual Customer Client { get; set; }
    }
}