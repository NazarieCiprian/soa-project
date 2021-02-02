using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Domain
{
    public class FreightsRegister
    {
        public int Id { get; private set; }
        public int FreightId { get; private set; }
        public int TruckerId { get; private set; }
        public int Payment { get; private set; }
        public int Status { get; private set; }


        public FreightsRegister(int freightId, int truckerId, int payment, int status)
        {
            FreightId = freightId;
            TruckerId = truckerId;
            Payment = payment;
            Status = status;
        }

        public void ChangeStatus(int status)
        {
            Status = status;
        }

        public void AddPayment(int payment)
        {
            Payment = payment;
        }
    }
}
