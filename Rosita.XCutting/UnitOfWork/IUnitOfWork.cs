using System;
using System.Threading.Tasks;

namespace Rosita.XCutting.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        int Commit();
    }
}