using FreightMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Application.Queries
{
    public interface IFreightQueries
    {
        Task<List<FreightModel>> GetAllFreights();
        Task<List<FreightModel>> GetAvailableFreights();
    }
}
