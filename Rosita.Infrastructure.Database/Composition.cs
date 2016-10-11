using Rosita.Infrastructure.Database.Contexts;
using Rosita.Infrastructure.Database.UnitOfWork;
using SimpleInjector;

namespace Rosita.Infrastructure.Database
{
    public static class Composition
    {
        public static void Setup(Container container, Lifestyle lf)
        {
            container.Register<DataContext>(lf);
            container.Register<IBussinessUnitOfWork, BussinessUnitOfWork>(lf);

        }
    }
}