using System.Collections.Generic;

namespace Rosita.XCutting.Mapping
{
    public interface IObjectFactory
    {
            IEnumerable<CommonProperties> GetCommonProperties<TDestination, TSource>(TSource source, TDestination destination);
    }
}