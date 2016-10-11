using System.Collections.Generic;
using System.Linq;
using Rosita.XCutting.DI;

namespace Rosita.XCutting.Mapping
{
    public static class ExtensionMethods
    {
            public static TDestination MapTo<TDestination, TSource>(this TSource source) where TDestination : class, new()
            {
                if (source == null)
                {
                    return null;
                }

                var factory = ServiceLocator.Resolve<IObjectFactory>();
                var destination = new TDestination();
                var commonProperties = factory.GetCommonProperties(source, destination);

                if (commonProperties != null)
                    foreach (var match in commonProperties)
                    {
                        match.DestinationProperty.SetValue(destination, match.SourceProperty.GetValue(source, null), null);
                    }

                return destination;
            }

            /// <summary>
            /// Maps the common properties from a source collection to another
            /// </summary>
            /// <typeparam name="TDestination"></typeparam>
            /// <typeparam name="TSource"></typeparam>
            /// <param name="source"></param>
            /// <returns></returns>
            public static IEnumerable<TDestination> MapCollectionTo<TDestination, TSource>(this IEnumerable<TSource> source) where TDestination : class, new()
            {
                if (!source.Any())
                {
                    return Enumerable.Empty<TDestination>();
                }

                return source.Select(element => element.MapTo<TDestination, TSource>()).ToList();
            }
        }
}