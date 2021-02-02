using FreightMicroservice.Domain;
using FreightMicroservice.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreightMicroservice.Application.Commands
{
    public class UpdateFreightStatusCommandHandler : IRequestHandler<UpdateFreightStatusCommand, FreightModel>
    {
        private readonly IFreightRepository _freightRepository;
        public UpdateFreightStatusCommandHandler(IFreightRepository freightRepository)
        {
            _freightRepository = freightRepository;
        }
        public async Task<FreightModel> Handle(UpdateFreightStatusCommand request, CancellationToken cancellationToken)
        {
            var freight = await _freightRepository.GetFreightById(request.Id);
            if(freight == null)
            {
                return null;
            }

            freight.ChangeStatus(request.Status);
            _freightRepository.SaveChanges();
            return freight;

        }
    }
}
