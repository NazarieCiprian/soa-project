using FreightMicroservice.Domain;
using FreightMicroservice.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Infrastructure
{
    public class FreightContext : DbContext
    {
        public virtual DbSet<FreightModel> Freights {get;set;}
        public FreightContext(DbContextOptions<FreightContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FreightEntityConfiguration());
        }
    }
}
