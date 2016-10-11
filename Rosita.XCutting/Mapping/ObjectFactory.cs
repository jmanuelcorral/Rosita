using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rosita.XCutting.Mapping
{
    public class ObjectFactory:IObjectFactory
    {
            private readonly ConcurrentDictionary<string, IEnumerable<CommonProperties>> _cachedProperties;

            public ObjectFactory()
            {
                _cachedProperties = new ConcurrentDictionary<string, IEnumerable<CommonProperties>>();
            }

            public IEnumerable<CommonProperties> GetCommonProperties<TDestination, TSource>(TSource source, TDestination destination)
            {
                var sourcetype = source.GetType();
                var destinationtype = destination.GetType();
                var composedKey = $"{sourcetype.FullName}_{destinationtype.FullName}";

                return _cachedProperties.GetOrAdd(
                    composedKey,
                    s =>
                    {
                        var sourceProperties = sourcetype.GetProperties();
                        var destinationProperties = destinationtype.GetProperties();

                        return sourceProperties.Join(
                            destinationProperties,
                            sp => new { sp.Name, sp.PropertyType },
                            dp => new { dp.Name, dp.PropertyType },
                            (sp, dp) => new CommonProperties(sp, dp));
                    });
            }
        }
}