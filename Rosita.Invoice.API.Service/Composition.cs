using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Rosita.XCutting.Configuration;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;

namespace Rosita.Invoice.API.Service
{
    public static class Composition
    {
        public static void SetupComposition(this IApplicationBuilder app, AppConfiguration config,Container container)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services. For instance:
            var lifestyle = new AspNetRequestLifestyle();
            Core.Composition.Setup(container, lifestyle);
            Infrastructure.Database.Composition.Setup(container, config, lifestyle);
            XCutting.Composition.Setup(container, lifestyle);
            XCutting.DI.ServiceLocator.SetupContainer(container);
            

            // Cross-wire ASP.NET services (if any). For instance:
            //container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
            // NOTE: Prevent cross-wired instances as much as possible.
            // See: https://simpleinjector.org/blog/2016/07/
        }
    }
}