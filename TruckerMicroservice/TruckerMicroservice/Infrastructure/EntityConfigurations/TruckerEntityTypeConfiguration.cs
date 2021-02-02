using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckerMicroservice.Domain;

namespace TruckerMicroservice.Infrastructure.EntityConfigurations
{
    public class TruckerEntityTypeConfiguration : IEntityTypeConfiguration<TruckerModel>
    {
        public void Configure(EntityTypeBuilder<TruckerModel> entity)
        {
            entity.ToTable("TRUCKER");

            entity.HasKey(el => el.Id);

            entity.Property(el => el.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity.Property(el => el.Username)
                .HasColumnName("Username");

            entity.Property(el => el.Password)
                .HasColumnName("Password");

            entity.Property(el => el.TruckingCompany)
                .HasColumnName("TruckingCompany");
        }
    }
}
