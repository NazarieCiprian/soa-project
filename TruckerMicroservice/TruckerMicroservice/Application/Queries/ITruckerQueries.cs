using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice.Application.Queries
{
    public interface ITruckerQueries
    {
        Task<List<TruckerModel>> GetAllTruckers();
        Task<TruckerModel> GetTruckerByUsernameAndPassword(string username, string password);
    }
}
