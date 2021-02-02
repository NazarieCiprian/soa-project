using System;
using System.Collections.Generic;
using System.Text;

namespace FreightApp.Core.Model
{
    public class FreightRegisterModel
    {
        public int Id { get; set; }
        public int FreightId { get; set; }
        public int TruckerId { get; set; }
        public int Payment { get; set; }
        public int Status { get; set; }
    }
}
