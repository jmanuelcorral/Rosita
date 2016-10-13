using Microsoft.EntityFrameworkCore;
using Rosita.Infrastructure.Database.Contexts;
using Rosita.Infrastructure.Database.UnitOfWork;
using Rosita.XCutting.Configuration;
using SimpleInjector;

namespace Rosita.Infrastructure.Database
{
    public static class Composition
    {
        public static void Setup(Container container, AppConfiguration configuration, Lifestyle lf)
        {
            DbContextOptionsBuilder<DataContext> builder = new DbContextOptionsBuilder<DataContext>(); 
            if (!string.IsNullOrEmpty(configuration.Databases.MainConnectionString))
            {
                container.Register<DataContext>(() => new DataContext(builder.UseSqlServer(configuration.Databases.MainConnectionString).Options), lf);
            }
            else
            {
                container.Register<DataContext>(() => new DataContext(builder.UseInMemoryDatabase().Options), lf);
            }
            container.Register<IBussinessUnitOfWork, BussinessUnitOfWork>(lf);

        }
    }
}