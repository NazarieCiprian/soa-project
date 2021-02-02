using FreightMicroservice.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Application.Commands
{
    public class UpdateFreightStatusCommand: IRequest<FreightModel>
    {
        public int Id { get; private set; }
        public int Status { get; private set; }

        public UpdateFreightStatusCommand(int id, int status)
        {
            Id = id;
            Status = status;
        }
    }
}
