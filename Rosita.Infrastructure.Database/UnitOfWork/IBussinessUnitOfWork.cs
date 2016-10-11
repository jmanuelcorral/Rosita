using System;
using Rosita.Infrastructure.Database.Entities;
using Rosita.Infrastructure.Database.Repositories;
using Rosita.XCutting.UnitOfWork;

namespace Rosita.Infrastructure.Database.UnitOfWork
{
        public interface IBussinessUnitOfWork : IUnitOfWork
        {
            IGenericRepository<Address, Guid> AddressRepository { get; }

            IGenericRepository<Address, Guid> CustomerRepository { get; }

            IGenericRepository<Invoice, Guid> InvoiceRepository { get; }

    }
}