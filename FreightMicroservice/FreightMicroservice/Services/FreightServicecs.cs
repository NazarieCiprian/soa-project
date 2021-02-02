using FreightMicroservice.Application.Commands;
using FreightMicroservice.Application.Queries;
using FreightMicroservice.Domain;
using Grpc.Core;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreightMicroservice.Services
{
    public class FreightServicecs: Freight.FreightBase
    {
        private readonly IMediator _mediator;
        private readonly IFreightQueries _freightQueries;

        public FreightServicecs(IMediator mediator, IFreightQueries freightQueries)
        {
            _mediator = mediator;
            _freightQueries = freightQueries;
        }
        public override async Task<GetFreightsResponse> GetFreights(GetFreightsRequest getFreightsRequest, ServerCallContext context)
        {
            var results = await _freightQueries.GetAllFreights();
            var freightsMessages = new List<FreightMessage>();
            foreach (var result in results)
            {
                var freightMessage = new FreightMessage();
                freightMessage.Id = result.Id;
                freightMessage.Location = result.Location;
                freightMessage.Destination = result.Destination;
                freightMessage.Cargo = result.Cargo;
                freightMessage.Status = result.Status;
                freightMessage.Payment = result.Payment;
                freightsMessages.Add(freightMessage);
            }

            var response = new GetFreightsResponse();
            response.Freights.AddRange(freightsMessages);
            return response;
        }

        public override async Task<AddFreightResponse> AddFreight(AddFreightRequest request, ServerCallContext context)
        {
            var freightModel = new FreightModel(request.Freight.Location, request.Freight.Destination, request.Freight.Cargo, request.Freight.Status, request.Freight.Payment);
            var addFreightComamnd = new AddFreightCommand(freightModel);
            var result = await _mediator.Send(addFreightComamnd);
            if (result == null)
            {
                return null;
            }
            var response = new AddFreightResponse();
            response.Freight = new FreightMessage();
            response.Freight.Id = result.Id;
            response.Freight.Location = result.Location;
            response.Freight.Destination = result.Destination;
            response.Freight.Cargo = result.Cargo;
            response.Freight.Status = result.Status;
            response.Freight.Payment = result.Payment;
            return response;
        }

        public override async Task<UpdateFreightStatusResponse> UpdateFreightStatus(UpdateFreightStatusRequest request, ServerCallContext context)
        {
            var id = request.FreightId;
            var status = request.Status;
            var command = new UpdateFreightStatusCommand(id, status);
            var result = await _mediator.Send(command);

            if(result == null)
            {
                return null;
            }

            var response = new UpdateFreightStatusResponse();
            response.Freight = new FreightMessage();
            response.Freight.Id = result.Id;
            response.Freight.Location = result.Location;
            response.Freight.Destination = result.Destination;
            response.Freight.Cargo = result.Cargo;
            response.Freight.Status = result.Status;
            response.Freight.Payment = result.Payment;
            return response;
        }

        public override async Task<GetAvailableFreightsResponse> GetAvailableFreights(GetAvailableFreightsRequest request, ServerCallContext context)
        {
            var results = await _freightQueries.GetAvailableFreights();
            var freightsMessages = new List<FreightMessage>();
            foreach(var result in results)
            {
                var freightMessage = new FreightMessage();
                freightMessage.Id = result.Id;
                freightMessage.Location = result.Location;
                freightMessage.Destination = result.Destination;
                freightMessage.Cargo = result.Cargo;
                freightMessage.Status = result.Status;
                freightMessage.Payment = result.Payment;
                freightsMessages.Add(freightMessage);
            }

            var response = new GetAvailableFreightsResponse();
            response.Freights.AddRange(freightsMessages);
            return response;
        }
    }
}
