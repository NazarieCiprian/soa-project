using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Domain.Repository;

namespace TruckerMicroservice.Infrastructure.Repository
{
    public class TruckerRepository : ITruckerRepository
    {
        private readonly TruckerDbContext _truckerDbContext;

        public TruckerRepository(TruckerDbContext truckerDbContext)
        {
            _truckerDbContext = truckerDbContext;
        }
        public void AddTrucker(TruckerModel truckerModel)
        {
            _truckerDbContext.Add(truckerModel);
        }

        public async Task<TruckerModel> GetTruckerByUsername(string username)
        {
            return await _truckerDbContext.Truckers.FirstOrDefaultAsync(el => el.Username == username);
        }

        public void SaveChanges()
        {
            _truckerDbContext.SaveChanges();
        }
    }
}
