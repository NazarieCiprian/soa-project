using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightApp.Core.Model;
using Microsoft.AspNetCore.SignalR;

namespace FreightApp.Hub
{
    public class FreightHub: Hub<FreightModel>
    {
    }
}
