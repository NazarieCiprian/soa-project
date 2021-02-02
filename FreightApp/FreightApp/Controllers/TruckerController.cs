using FireSharp.Config;
using FireSharp.Interfaces;
using FreightApp.Core.Dto;
using FreightApp.Core.Model;
using FreightApp.Core.Services;
using FreightApp.Hub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("rest/[controller]")]
    public class TruckerController: ControllerBase
    {

        private readonly TruckerServiceWebApp _truckerServiceWebApp;
        private readonly FreightServiceWebApp _freightServiceWebApp;
        private readonly IHubContext<FreightHub> _hubContext;
        private readonly IFirebaseConfig _firebaseConfig;
        public TruckerController(IHubContext<FreightHub> hubContext)
        {
            _truckerServiceWebApp = new TruckerServiceWebApp();
            _freightServiceWebApp = new FreightServiceWebApp();
            _hubContext = hubContext;
            _firebaseConfig = new FirebaseConfig()
            {
                AuthSecret = "Ch4ZQYFFC0pvjvVWG2aTULVqnEdQ4hU590WU5S3u",
                BasePath = "https://soa-freight-default-rtdb.firebaseio.com/"
            };
        }

        [HttpGet]
        [Route("getalltruckers")]
        public async Task<IActionResult> GetAllTruckers()
        {
            var result = await _truckerServiceWebApp.GetTruckersAsync();
            return Ok(result);

        }

        [HttpGet]
        [Route("gettruckerfreights")]
        public async Task<IActionResult> GetTruckerFreights(int truckerId)
        {
            var result = await _truckerServiceWebApp.GetFreightsRegisterByTruckerId(truckerId);
            return Ok(result);
        }

        [HttpPost]
        [Route("takefreight")]
        public async Task<IActionResult> TakeFreight([FromBody]TakeFreightDto freightDto)
        {
            var result = await _truckerServiceWebApp.TakeFreight(freightDto.TruckerId, freightDto.FreightId, freightDto.Payment);
            var result1 = await _freightServiceWebApp.UpdateFreightStatus(freightDto.FreightId, freightDto.Status);
            var result2 = await _freightServiceWebApp.GetAvailableFreightsAsync();
            await _hubContext.Clients.All.SendAsync("addedfreight", result2);
            return Ok(result);
        }

        [HttpPost]
        [Route("addtrucker")]
        public async Task<IActionResult> AddTrucker([FromBody] TruckerModel truckerModel)
        {
            var result = await _truckerServiceWebApp.AddTrucker(truckerModel);
            var client = new FireSharp.FirebaseClient(_firebaseConfig);
            var response = client.PushAsync("truckers/", result);
            return Ok(result);
        }

        [HttpPost]
        [Route("completetransport")]
        public async Task<IActionResult> CompleteTransport(int truckerId, int freightId, int status)
        {
            var result = await _truckerServiceWebApp.CompleteFreight(truckerId, freightId, status);
            return Ok(result);
        }
    }
}
