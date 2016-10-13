using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Rosita.Core.Framework;
using Rosita.Invoice.Core.Boundaries.GetInvoice;
using Rosita.Invoice.Core.UseCases;
using SimpleInjector;

namespace Rosita.Invoice.Core
{
    public static class Composition
    {
        public static void Setup(Container container, Lifestyle lf)
        {
            container.Register<UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse>, GetInvoiceByInvoiceCodeUseCase>();
        }
    }
}
