using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Domain.Enums
{
    public enum FreightDeliveryStatus
    {
        Pending = 1,
        Completed = 2,
        WithIssues = 3,
        Destroyed = 4,
    }
}
