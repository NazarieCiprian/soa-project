using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Domain.Repository
{
    public interface IFreightRepository
    {

        void AddFreight(FreightModel freightModel);

        Task<FreightModel> GetFreightById(int id);

        void SaveChanges();
    }
}
