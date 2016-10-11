using System;
using System.Threading.Tasks;
using Rosita.Infrastructure.Database.Contexts;
using Rosita.Infrastructure.Database.Entities;
using Rosita.Infrastructure.Database.Repositories;

namespace Rosita.Infrastructure.Database.UnitOfWork
{
    public class BussinessUnitOfWork: IBussinessUnitOfWork
    {
        private readonly DataContext _dbContext;
        public BussinessUnitOfWork(DataContext dbContext)
        {
            _dbContext =  dbContext;
        }
        public void Dispose()
        {
            //_dbContext.Dispose();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int Commit()
        {
            return Commit();
        }

        public IGenericRepository<Address, Guid> AddressRepository => new EFGenericRepository<Address, Guid>(_dbContext);

        public IGenericRepository<Address, Guid> CustomerRepository => new EFGenericRepository<Address, Guid>(_dbContext);

        public IGenericRepository<Invoice, Guid> InvoiceRepository => new EFGenericRepository<Invoice, Guid>(_dbContext);
    }
}