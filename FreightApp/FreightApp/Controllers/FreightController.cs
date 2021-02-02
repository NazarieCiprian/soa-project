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
    public class FreightController: ControllerBase
    {
        private readonly FreightServiceWebApp _freightServiceWebApp;
        private readonly IHubContext<FreightHub> _hubContext;
        public FreightController(IHubContext<FreightHub> hubContext)
        {
            _freightServiceWebApp = new FreightServiceWebApp();
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("getallfreights")]
        public async Task<IActionResult> GetAllFreights()
        {
            var result = await _freightServiceWebApp.GetFreightsAsync();
            await _hubContext.Clients.All.SendAsync("addedfreight", result);
            return Ok(result);
        }

        [HttpGet]
        [Route("getavailablefreights")]
        public async Task<IActionResult> GetAvailableFreights()
        {
            var result = await _freightServiceWebApp.GetAvailableFreightsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("addfreight")]
        public async Task<IActionResult> AddFreight([FromBody]FreightModel freightModel)
        {
            var result = await _freightServiceWebApp.AddFreight(freightModel);
            var result1 = await _freightServiceWebApp.GetAvailableFreightsAsync();
            await _hubContext.Clients.All.SendAsync("addedfreight", result1);
            return Ok(result);
        }

        [HttpPost]
        [Route("updatefreightstatus")]
        public async Task<IActionResult> AddFreight(int id, int status)
        {
            var result = await _freightServiceWebApp.UpdateFreightStatus(id, status);
            var result1 = await _freightServiceWebApp.GetAvailableFreightsAsync();
            await _hubContext.Clients.All.SendAsync("addedfreight", result1);
            return Ok(result);
        }
    }
}
