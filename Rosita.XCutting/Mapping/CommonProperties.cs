using System.Reflection;

namespace Rosita.XCutting.Mapping
{
    public class CommonProperties
    {
        public CommonProperties(PropertyInfo source, PropertyInfo destination)
        {
            SourceProperty = source;
            DestinationProperty = destination;
        }

        public PropertyInfo SourceProperty { get; set; }

        public PropertyInfo DestinationProperty { get; set; }
    }
}