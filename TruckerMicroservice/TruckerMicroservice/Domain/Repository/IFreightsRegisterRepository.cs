using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Domain.Repository
{
    public interface IFreightsRegisterRepository
    {
        void AddFreightRegister(FreightsRegister freightsRegister);

        Task<FreightsRegister> GetFreightsByFreightAndTrucker(int truckerId, int FreightId);

        void SaveChanges();
    }
}
