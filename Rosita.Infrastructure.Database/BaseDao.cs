using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rosita.Infrastructure.Database
{
    public abstract class BaseDao<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
