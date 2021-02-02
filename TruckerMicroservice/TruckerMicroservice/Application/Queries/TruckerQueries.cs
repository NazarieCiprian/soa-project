using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Infrastructure;

namespace TruckerMicroservice.Application.Queries
{
    public class TruckerQueries: ITruckerQueries
    {
        private readonly TruckerDbContext _truckerDbContext;

        public TruckerQueries(TruckerDbContext truckerDbContext)
        {
            _truckerDbContext = truckerDbContext;
        }

        public async Task<List<TruckerModel>> GetAllTruckers()
        {
            return await _truckerDbContext.Truckers.ToListAsync();
        }

        public async Task<TruckerModel> GetTruckerByUsernameAndPassword(string username, string password)
        {
            var result = await _truckerDbContext.Truckers.Where(el => el.Username == username && el.Password == password).FirstOrDefaultAsync();
            if(result == null)
            {
                return result;
            }

            result.Password = "";
            return result;
        }
    }
}
