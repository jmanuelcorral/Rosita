using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Rosita.XCutting.Configuration;
using Rosita.XCutting.DI;
using SimpleInjector;
using Rosita.Infrastructure.Database.Contexts;
using SimpleInjector.Diagnostics;
using Rosita.Infrastructure.Database.UnitOfWork;

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
            //Deactivate container warnings in tests for non threadsafe in entity framework
            Registration DataContextRegistration = container.GetRegistration(typeof(DataContext)).Registration;
            DataContextRegistration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "This is Testing, and we don't have an asp approach");

            Registration UnitOfWorkRegistration = container.GetRegistration(typeof(IBussinessUnitOfWork)).Registration;
            UnitOfWorkRegistration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "This is Testing, and we don't have an asp approach");
            container.Verify();
        }
    }
}
