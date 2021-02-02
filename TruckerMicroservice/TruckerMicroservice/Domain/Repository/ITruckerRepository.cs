using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Domain.Repository
{
    public interface ITruckerRepository
    {
        void AddTrucker(TruckerModel truckerModel);

        Task<TruckerModel> GetTruckerByUsername(string username);

        void SaveChanges();
    }
}
