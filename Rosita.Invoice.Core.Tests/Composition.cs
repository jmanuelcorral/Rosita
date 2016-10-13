using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Rosita.XCutting.Configuration;
using Rosita.XCutting.DI;
using SimpleInjector;

namespace Rosita.Invoice.Core.Tests
{
    public static class Composition
    {
        public static void Setup(Container container, Lifestyle lf)
        {
            var configuration = new AppConfiguration()
            {
                Databases = new Databases() {}
            };
            Core.Composition.Setup(container, lf);
            Infrastructure.Database.Composition.Setup(container, configuration, lf);
            ServiceLocator.SetupContainer(container);
            container.Verify();
        }
    }
}
