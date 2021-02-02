using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Application.Commands
{
    public class CompleteFreightCommand: IRequest<bool>
    {
        public int TruckerId { get; private set; }
        public int FreightId { get; private set; }
        public int Status { get; private set; }

        public CompleteFreightCommand(int truckerId, int freightId, int status)
        {
            TruckerId = truckerId;
            FreightId = freightId;
            Status = status;
        }
    }
}
