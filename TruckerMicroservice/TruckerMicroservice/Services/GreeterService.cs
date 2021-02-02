using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using TruckerMicroservice.Application.Commands;
using TruckerMicroservice.Application.Queries;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ITruckerQueries _truckerQueries;
        private readonly IFreightRegistersQueries _freightRegisterQueries;
        private readonly IMediator _mediator;
        public GreeterService(ITruckerQueries truckerQueries, IFreightRegistersQueries freightRegisterQueries, IMediator mediator)
        {
            _truckerQueries = truckerQueries;
            _freightRegisterQueries = freightRegisterQueries;
            _mediator = mediator;
        }

        public override async Task<GetTruckersResponse> GetTruckers(GetTruckersRequest request, ServerCallContext context)
        {
            var results = await _truckerQueries.GetAllTruckers();
            var messages = new List<TruckerMessage>();
            foreach(var result in results)
            {
                var truckerMessage = new TruckerMessage()
                {
                    Id = result.Id,
                    Username = result.Username,
                    Password = result.Password,
                    TruckingCompany = result.TruckingCompany
                };
                messages.Add(truckerMessage);
            }

            var truckerResponse = new GetTruckersResponse();
            truckerResponse.Truckers.AddRange(messages);
            return truckerResponse;
        }

        public override async Task<GetTruckerByUsernameAndPasswordResponse> GetTruckersByUsernameAndPassword(GetTruckerByUsernameAndPasswordRequest request, ServerCallContext context)
        {
            var result = await _truckerQueries.GetTruckerByUsernameAndPassword(request.Username, request.Password);

            var truckerMessage = new TruckerMessage();
            if (result == null)
            {
                truckerMessage = null;
            }
            else
            {
                truckerMessage.Id = result.Id;
                truckerMessage.Username = result.Username;
                truckerMessage.Password = result.Password;
                truckerMessage.TruckingCompany = result.TruckingCompany;
            }
            var response = new GetTruckerByUsernameAndPasswordResponse();
            response.Trucker = truckerMessage;
            return response;
        }

        public override async Task<AddTruckerResponse> AddTrucker(AddTruckerRequest request, ServerCallContext context)
        {
            var truckerModel = new TruckerModel(request.Trucker.Username, request.Trucker.Password, request.Trucker.TruckingCompany);
            var addTruckerCommand = new AddTruckerCommand(truckerModel);
            var result = await _mediator.Send(addTruckerCommand);
            var truckerMessage = new TruckerMessage();
            if (result == null)
            {
                truckerMessage = null;
            }
            else
            {
                truckerMessage.Id = result.Id;
                truckerMessage.Username = result.Username;
                truckerMessage.Password = result.Password;
                truckerMessage.TruckingCompany = result.TruckingCompany;
            }
            var response = new AddTruckerResponse();
            response.Trucker = truckerMessage;
            return response;
        }

        public override async Task<GetFreightRegisterResponse> GetFreights(GetFreightsRegisterRequest request, ServerCallContext context)
        {
            var results = await _freightRegisterQueries.GetAllRegisters();
            var messages = new List<FreightRegisterMessage>();
            foreach (var result in results)
            {
                var freightMessage = new FreightRegisterMessage()
                {
                    Id = result.Id,
                    FreightId = result.FreightId,
                    TruckerId = result.TruckerId,
                    Status = result.Status,
                    Payment = result.Payment
                };
                messages.Add(freightMessage);
            }

            var freightResponse = new GetFreightRegisterResponse();
            freightResponse.FreightRegisters.AddRange(messages);
            return freightResponse;
        }

        public override async Task<GetFreightsRegisterByTruckerIdResponse> GetFreightsRegisterByTruckerId(GetFreightsRegisterByTruckerIdRequest request, ServerCallContext context)
        {
            var results = await _freightRegisterQueries.GetCompletedRegistersForTrucker(request.TruckerId);
            var messages = new List<FreightRegisterMessage>();
            foreach (var result in results)
            {
                var freightMessage = new FreightRegisterMessage()
                {
                    Id = result.Id,
                    FreightId = result.FreightId,
                    TruckerId = result.TruckerId,
                    Status = result.Status,
                    Payment = result.Payment
                };
                messages.Add(freightMessage);
            }

            var freightResponse = new GetFreightsRegisterByTruckerIdResponse();
            freightResponse.FreightRegisters.AddRange(messages);
            return freightResponse;
        }

        public override async Task<TakeFreightCommandResponse> TakeFreight(TakeFreightCommandRequest request, ServerCallContext context)
        {
            var addTruckerCommand = new TakeFreightCommand(request.TruckerId, request.Payment, request.FreightId);
            var result = await _mediator.Send(addTruckerCommand);
            var truckerMessage = new TakeFreightCommandResponse();
            truckerMessage.Success = result;
            return truckerMessage;
        }

        public override async Task<CompleteFreightResponse> CompleteFreight(CompleteFreightRequest request, ServerCallContext context)
        {
            var addTruckerCommand = new CompleteFreightCommand(request.TruckerId, request.FreightId, request.Status);
            var result = await _mediator.Send(addTruckerCommand);
            var truckerMessage = new CompleteFreightResponse();
            truckerMessage.Success = result;
            return truckerMessage;
        }

    }
}
