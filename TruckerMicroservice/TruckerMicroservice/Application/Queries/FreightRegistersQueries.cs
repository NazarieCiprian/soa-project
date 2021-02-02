using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Infrastructure;

namespace TruckerMicroservice.Application.Queries
{
    public class FreightRegistersQueries : IFreightRegistersQueries
    {
        private readonly TruckerDbContext _truckerDbContext;
        public FreightRegistersQueries(TruckerDbContext truckerDbContext)
        {
            _truckerDbContext = truckerDbContext;
        }

        public async Task<List<FreightsRegister>> GetAllRegisters()
        {
            return await _truckerDbContext.FreightRegisters.ToListAsync();
        }

        public async Task<List<FreightsRegister>> GetCompletedRegistersForTrucker(int truckerId)
        {
            return await _truckerDbContext.FreightRegisters.Where(el => el.TruckerId == truckerId).ToListAsync();
        }
    }
}
