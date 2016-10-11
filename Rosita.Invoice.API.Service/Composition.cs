using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;

namespace Rosita.Invoice.API.Service
{
    public static class Composition
    {
        public static void SetupComposition(this IApplicationBuilder app, Container container)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services. For instance:
            var lifetime = new AspNetRequestLifestyle();
            Core.Composition.Setup(container, lifetime);
            Infrastructure.Database.Composition.Setup(container, lifetime);
            XCutting.DI.ServiceLocator.SetupContainer(container);
            

            // Cross-wire ASP.NET services (if any). For instance:
            //container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
            // NOTE: Prevent cross-wired instances as much as possible.
            // See: https://simpleinjector.org/blog/2016/07/
        }
    }
}