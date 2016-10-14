using Rosita.XCutting.Mapping;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rosita.XCutting
{
    public class Composition
    {
        public static void Setup(Container container, Lifestyle lf)
        {
            container.Register<IObjectFactory, ObjectFactory>(Lifestyle.Singleton);
        }
    }
}
