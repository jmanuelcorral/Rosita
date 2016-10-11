using System;
using System.Collections.Generic;

namespace Rosita.Infrastructure.Database.Entities
{
    public class Customer:BaseDao<Guid>
    {
        
        public string Subject { get; set; }

        public string LegalDocument { get; set; }

        public bool? CanAvoidTax { get; set; }

        public string email { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}