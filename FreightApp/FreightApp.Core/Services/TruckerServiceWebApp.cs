using FreightApp.Core.Model;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckerMicroservice;

namespace FreightApp.Core.Services
{
    public class TruckerServiceWebApp
    {
        public async Task<List<TruckerModel>> GetTruckersAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new GetTruckersRequest();

                var response = await client.GetTruckersAsync(request);

                var freights = response.Truckers.Select(s => new TruckerModel()
                {
                    Id = s.Id,
                    Username = s.Username,
                    Password = s.Password,
                    TruckingCompany = s.TruckingCompany
                }).ToList();


                return freights;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
        public async Task<TruckerModel> GetTruckerByUsernameAndPassword(string username, string password)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new GetTruckerByUsernameAndPasswordRequest();
                request.Username = username;
                request.Password = password;

                var response = await client.GetTruckersByUsernameAndPasswordAsync(request);

                if (response.Trucker == null)
                {
                    return null;
                }

                var trucker = new TruckerModel()
                {
                    Id = response.Trucker.Id,
                    Username = response.Trucker.Username,
                    TruckingCompany = response.Trucker.TruckingCompany
                };


                return trucker;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<TruckerModel> AddTrucker(TruckerModel truckerModel)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new AddTruckerRequest();
                request.Trucker = new TruckerMessage();
                request.Trucker.Username = truckerModel.Username;
                request.Trucker.Password = truckerModel.Password;
                request.Trucker.TruckingCompany = truckerModel.TruckingCompany;

                var response = await client.AddTruckerAsync(request);

                if (response.Trucker == null)
                {
                    return null;
                }

                var trucker = new TruckerModel()
                {
                    Id = response.Trucker.Id,
                    Username = response.Trucker.Username,
                    TruckingCompany = response.Trucker.TruckingCompany
                };


                return trucker;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<List<FreightRegisterModel>> GetFreights()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new GetFreightsRegisterRequest();

                var response = await client.GetFreightsAsync(request);

                var freights = response.FreightRegisters.Select(s => new FreightRegisterModel()
                {
                    Id = s.Id,
                    TruckerId = s.TruckerId,
                    FreightId = s.FreightId,
                    Payment = s.Payment,
                    Status = s.Status
                }).ToList();


                return freights;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<List<FreightRegisterModel>> GetFreightsRegisterByTruckerId(int truckerId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new GetFreightsRegisterByTruckerIdRequest();
                request.TruckerId = truckerId;
                var response = await client.GetFreightsRegisterByTruckerIdAsync(request);

                var freights = response.FreightRegisters.Select(s => new FreightRegisterModel()
                {
                    Id = s.Id,
                    TruckerId = s.TruckerId,
                    FreightId = s.FreightId,
                    Payment = s.Payment,
                    Status = s.Status
                }).ToList();


                return freights;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<bool> TakeFreight(int truckerId, int freightId, int payment)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new TakeFreightCommandRequest();
                request.TruckerId = truckerId;
                request.FreightId = freightId;
                request.Payment = payment;
                var response = await client.TakeFreightAsync(request);

                return response.Success;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        public async Task<bool> CompleteFreight(int truckerId, int freightId, int status)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5003");
            try
            {

                var client = new Greeter.GreeterClient(channel);
                var request = new CompleteFreightRequest();
                request.TruckerId = truckerId;
                request.FreightId = freightId;
                request.Status = status;
                var response = await client.CompleteFreightAsync(request);

                return response.Success;
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }


    }
}
