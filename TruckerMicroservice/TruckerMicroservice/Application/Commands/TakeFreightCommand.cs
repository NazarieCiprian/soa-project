using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Application.Commands
{
    public class TakeFreightCommand: IRequest<bool>
    {
        public int TruckerId { get; private set; }
        public int Payment { get; private set; }
        
        public int FreightId { get; private set; }

        public TakeFreightCommand(int truckerId, int payment, int freightId)
        {
            TruckerId = truckerId;
            Payment = payment;
            FreightId = freightId;
        }
    }
}
