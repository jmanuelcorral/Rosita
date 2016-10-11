using System.Collections.Generic;
using Rosita.XCutting.Exceptions;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Rosita.XCutting.DI
{
    public static class ServiceLocator
    {
        private static Container _activeContainer;

        public static bool Locked { get; } = false;

        /// <summary>
        ///     given and existing and filled container, it set-ups the factory Methods for resolve future dependencies.
        /// </summary>
        /// <param name="container">A Container with these settings</param>
        /// <exception cref="DependencyInjectionException">
        ///     Occurs when the container is null, or when you try to override an
        ///     assigned container before.
        /// </exception>
        public static void SetupContainer(Container container)
        {
            if (container == null)
            {
                throw new DependencyInjectionException(
                    "DependencyInjection Container Can not to be null, you can obtain one calling DI.Configuration.Setup(AppEnvironment, LifeTimeManager)");
            }

            if (_activeContainer == null)
            {
                _activeContainer = container;
            }
            else
            {
                if (Locked)
                {
                    throw new DependencyInjectionException("Dependency factory it's already initialized, you can not initialize for a second time");
                }

                _activeContainer = container;
            }
        }

        /// <summary>
        ///     returns a resolved instance of a T Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T resolved Instance</returns>
        public static T Resolve<T>() where T : class
        {
            using (_activeContainer.BeginExecutionContextScope())
            {
                return _activeContainer.GetInstance<T>();
            }
        }

        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _activeContainer.GetAllInstances<T>();
        }
    }
}