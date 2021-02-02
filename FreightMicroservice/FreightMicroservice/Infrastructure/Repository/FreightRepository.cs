using FreightMicroservice.Domain;
using FreightMicroservice.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Infrastructure.Repository
{
    public class FreightRepository : IFreightRepository
    {
        private readonly FreightContext _freightContext;
        public FreightRepository(FreightContext freightContext)
        {
            _freightContext = freightContext;
        }
        public void AddFreight(FreightModel freightModel)
        {
            _freightContext.Add(freightModel);
            _freightContext.SaveChanges();
        }

        public async Task<FreightModel> GetFreightById(int id)
        {
            var result = await _freightContext.Freights.FirstOrDefaultAsync(el => el.Id == id);
            return result;
        }

        public void SaveChanges()
        {
            _freightContext.SaveChanges();
        }
    }
}
