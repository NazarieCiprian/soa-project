using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Domain.Repository;

namespace TruckerMicroservice.Application.Commands
{
    public class AddTruckerCommandHandler : IRequestHandler<AddTruckerCommand, TruckerModel>
    {
        private readonly ITruckerRepository _truckerRepository;
        public AddTruckerCommandHandler(ITruckerRepository truckerRepository)
        {
            _truckerRepository = truckerRepository;
        }
        public async Task<TruckerModel> Handle(AddTruckerCommand request, CancellationToken cancellationToken)
        {
            var result = await _truckerRepository.GetTruckerByUsername(request.Trucker.Username);
            if(result != null)
            {
                return null;
            }
            _truckerRepository.AddTrucker(request.Trucker);
            _truckerRepository.SaveChanges();
            return request.Trucker;
        }
    }
}
