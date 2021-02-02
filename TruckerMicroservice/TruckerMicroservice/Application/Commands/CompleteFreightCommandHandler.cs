using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TruckerMicroservice.Domain.Enums;
using TruckerMicroservice.Domain.Repository;

namespace TruckerMicroservice.Application.Commands
{
    public class CompleteFreightCommandHandler : IRequestHandler<CompleteFreightCommand, bool>
    {
        private readonly IFreightsRegisterRepository _freightsRegisterRepository;
        public CompleteFreightCommandHandler(IFreightsRegisterRepository freightsRegisterRepository)
        {
            _freightsRegisterRepository = freightsRegisterRepository;
        }
        public async Task<bool> Handle(CompleteFreightCommand request, CancellationToken cancellationToken)
        {
            var freightRegister = await _freightsRegisterRepository.GetFreightsByFreightAndTrucker(request.TruckerId, request.FreightId);

            if(freightRegister == null)
            {
                return false;
            }

            freightRegister.ChangeStatus(request.Status);
            if(request.Status == (int)FreightDeliveryStatus.WithIssues)
            {
                var random = new Random();
                freightRegister.AddPayment(freightRegister.Payment-random.Next(100, freightRegister.Payment-100));
            } else if(request.Status == (int)FreightDeliveryStatus.Destroyed)
            {
                freightRegister.AddPayment(0);
            }

            _freightsRegisterRepository.SaveChanges();
            return true;
        }
    }
}
