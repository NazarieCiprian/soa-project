using FreightMicroservice.Domain;
using FreightMicroservice.Domain.Enums;
using FreightMicroservice.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Application.Queries
{
    public class FreightQueries: IFreightQueries
    {
        private readonly FreightContext _freightContext;

        public FreightQueries(FreightContext freightContext)
        {
            _freightContext = freightContext;
        }

        public Task<List<FreightModel>> GetAllFreights()
        {
            return _freightContext.Freights.ToListAsync();
        }

        public Task<List<FreightModel>> GetAvailableFreights()
        {
            return _freightContext.Freights.Where(el => el.Status == (int)FreightStatus.Available).ToListAsync();
        }
    }
}
