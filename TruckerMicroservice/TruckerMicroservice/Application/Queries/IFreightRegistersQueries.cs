using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice.Application.Queries
{
    public interface IFreightRegistersQueries
    {
        Task<List<FreightsRegister>> GetAllRegisters();
        Task<List<FreightsRegister>> GetCompletedRegistersForTrucker(int truckerId);
    }
}
