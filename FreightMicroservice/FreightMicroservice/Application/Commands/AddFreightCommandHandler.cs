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
    public class AddFreightCommandHandler : IRequestHandler<AddFreightCommand, FreightModel>
    {
        private readonly IFreightRepository _freightRepository;

        public AddFreightCommandHandler(IFreightRepository freightRepository)
        {
            _freightRepository = freightRepository;
        }
        public Task<FreightModel> Handle(AddFreightCommand request, CancellationToken cancellationToken)
        {
            _freightRepository.AddFreight(request.FreightModel); ;
            return Task.FromResult(request.FreightModel);
        }
    }
}
