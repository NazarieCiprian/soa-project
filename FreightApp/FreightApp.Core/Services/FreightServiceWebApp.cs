using FreightApp.Core.Model;
using FreightMicroservice;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightApp.Core.Services
{
    public class FreightServiceWebApp
    {
        public async Task<List<FreightModel>> GetFreightsAsync()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("https://localhost:5000");
            try
            {
                
                var client = new FreightMicroservice.Freight.FreightClient(channel);
                var request = new FreightMicroservice.GetFreightsRequest();

                var response = await client.GetFreightsAsync(request);

                var freights = response.Freights.Select(s => new FreightModel()
                {
                    Id = s.Id,
                    Location = s.Location,
                    Destination = s.Destination,
                    Cargo = s.Cargo,
                    Status = s.Status,
                    Payment = s.Payment
                }).ToList();


                return freights;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<FreightModel> AddFreight(FreightModel freightModel)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            try
            {

                var client = new FreightMicroservice.Freight.FreightClient(channel);
                var request = new FreightMicroservice.AddFreightRequest();
                request.Freight = new FreightMessage();
                request.Freight.Location = freightModel.Location;
                request.Freight.Destination = freightModel.Destination;
                request.Freight.Cargo = freightModel.Cargo;
                request.Freight.Status = freightModel.Status;
                request.Freight.Payment = freightModel.Payment;

                var response = await client.AddFreightAsync(request);

                var freightResult = new FreightModel()
                {
                    Id = response.Freight.Id,
                    Location = response.Freight.Location,
                    Destination = response.Freight.Destination,
                    Cargo = response.Freight.Cargo,
                    Status = response.Freight.Status,
                    Payment = response.Freight.Payment
                };
                return freightResult;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<FreightModel> UpdateFreightStatus(int id, int status)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            try
            {

                var client = new FreightMicroservice.Freight.FreightClient(channel);
                var request = new FreightMicroservice.UpdateFreightStatusRequest();
                request.FreightId = id;
                request.Status = status;

                var response = await client.UpdateFreightStatusAsync(request);
                var freightResult = new FreightModel()
                {
                    Id = response.Freight.Id,
                    Location = response.Freight.Location,
                    Destination = response.Freight.Destination,
                    Cargo = response.Freight.Cargo,
                    Status = response.Freight.Status,
                    Payment = response.Freight.Payment
                };
                return freightResult;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
        public async Task<List<FreightModel>> GetAvailableFreightsAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            try
            {

                var client = new FreightMicroservice.Freight.FreightClient(channel);
                var request = new FreightMicroservice.GetAvailableFreightsRequest();

                var response = await client.GetAvailableFreightsAsync(request);

                var freights = response.Freights.Select(s => new FreightModel()
                {
                    Id = s.Id,
                    Location = s.Location,
                    Destination = s.Destination,
                    Cargo = s.Cargo,
                    Status = s.Status,
                    Payment = s.Payment
                }).ToList();


                return freights;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}
