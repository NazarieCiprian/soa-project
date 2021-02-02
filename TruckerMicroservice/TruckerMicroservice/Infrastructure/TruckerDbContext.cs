using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;
using TruckerMicroservice.Infrastructure.EntityConfigurations;

namespace TruckerMicroservice.Infrastructure
{
    public class TruckerDbContext: DbContext
    {
        public virtual DbSet<TruckerModel> Truckers { get; set; }
        public virtual DbSet<FreightsRegister> FreightRegisters { get; set; }
        public TruckerDbContext(DbContextOptions<TruckerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FreightRegisterEntityConfiguration());
        }
    }
}
