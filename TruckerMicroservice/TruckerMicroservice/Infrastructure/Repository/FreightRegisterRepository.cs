using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Domain.Repository;

namespace TruckerMicroservice.Infrastructure.Repository
{
    public class FreightRegisterRepository : IFreightsRegisterRepository
    {

        private readonly TruckerDbContext _truckerDbContext;
        public FreightRegisterRepository(TruckerDbContext truckerDbContext)
        {
            _truckerDbContext = truckerDbContext;
        }
        public void AddFreightRegister(FreightsRegister freightsRegister)
        {
            _truckerDbContext.Add(freightsRegister);
        }

        public async Task<FreightsRegister> GetFreightsByFreightAndTrucker(int truckerId, int FreightId)
        {
            return await _truckerDbContext.FreightRegisters.FirstOrDefaultAsync(el => el.TruckerId == truckerId && el.FreightId == FreightId);
        }

        public void SaveChanges()
        {
            _truckerDbContext.SaveChanges();
        }
    }
}
