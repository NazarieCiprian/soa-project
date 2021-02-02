using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Domain.Enums;
using TruckerMicroservice.Domain.Repository;

namespace TruckerMicroservice.Application.Commands
{
    public class TakeFreightCommandHandler : IRequestHandler<TakeFreightCommand, bool>
    {
        private readonly IFreightsRegisterRepository _freightRegisterRepository;
        public TakeFreightCommandHandler(IFreightsRegisterRepository freightsRegisterRepository)
        {
            _freightRegisterRepository = freightsRegisterRepository;
        }
        public Task<bool> Handle(TakeFreightCommand request, CancellationToken cancellationToken)
        {
            var freightRegister = new FreightsRegister(request.FreightId, request.TruckerId, request.Payment, (int)FreightDeliveryStatus.Pending);
            _freightRegisterRepository.AddFreightRegister(freightRegister);
            _freightRegisterRepository.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
