using System;

namespace Rosita.XCutting.Exceptions
{
    public class DependencyInjectionException : Exception
    {
        private static readonly string DefaultMessage = "Error en Inyección de Dependencias";

        public DependencyInjectionException()
            : base(DefaultMessage)
        {
        }

        public DependencyInjectionException(string message)
            : base(message)
        {
        }

        public DependencyInjectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}