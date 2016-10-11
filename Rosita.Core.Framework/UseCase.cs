using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rosita.Core.Framework
{
    public abstract class UseCase<TRequestMessage, TResponseMessage> where TRequestMessage : UseCaseRequestMessage
                                                                     where TResponseMessage : UseCaseResponseMessage
    {
        public abstract Task<TResponseMessage> Handle(TRequestMessage requestMessage);
    }
}
