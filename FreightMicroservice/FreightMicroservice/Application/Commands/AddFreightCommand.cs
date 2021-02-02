using FreightMicroservice.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Application.Commands
{
    public class AddFreightCommand: IRequest<FreightModel>
    {
        public FreightModel FreightModel { get; private set; }

        public AddFreightCommand(FreightModel freightModel)
        {
            FreightModel = freightModel;
        }
    }
}
