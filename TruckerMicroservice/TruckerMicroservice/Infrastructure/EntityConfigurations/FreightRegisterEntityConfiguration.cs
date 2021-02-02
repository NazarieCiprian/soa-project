using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice.Infrastructure.EntityConfigurations
{
    public class FreightRegisterEntityConfiguration : IEntityTypeConfiguration<FreightsRegister>
    {
        public void Configure(EntityTypeBuilder<FreightsRegister> entity)
        {
            entity.ToTable("FREIGHT_REGISTER");

            entity.HasKey(el => el.Id);

            entity.Property(el => el.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(el => el.TruckerId)
                .HasColumnName("TruckerId");

            entity.Property(el => el.Status)
                .HasColumnName("Status");

            entity.Property(el => el.Payment)
                .HasColumnName("Payment");

            entity.Property(el => el.FreightId)
                .HasColumnName("FreightId");

        }
    }
}
