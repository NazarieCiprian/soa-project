using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice.Application.Commands
{
    public class AddTruckerCommand: IRequest<TruckerModel>
    {
        public TruckerModel Trucker { get; private set; }

        public AddTruckerCommand(TruckerModel trucker)
        {
            Trucker = trucker;
        }
    }
}
