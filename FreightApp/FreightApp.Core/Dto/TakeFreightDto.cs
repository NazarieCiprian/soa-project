using System;
using System.Collections.Generic;
using System.Text;

namespace FreightApp.Core.Dto
{
    public class TakeFreightDto
    {
        public int TruckerId { get; set; }
        public int FreightId { get; set; }
        public int Payment { get; set; }
        public int Status { get; set; }
    }
}
