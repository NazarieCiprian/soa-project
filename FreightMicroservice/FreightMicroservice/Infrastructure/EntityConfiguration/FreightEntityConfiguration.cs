using FreightMicroservice.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreightMicroservice.Infrastructure.EntityConfiguration
{
    public class FreightEntityConfiguration : IEntityTypeConfiguration<FreightModel>
    {
        public void Configure(EntityTypeBuilder<FreightModel> builder)
        {
            builder.ToTable("FREIGHTS");

            builder.HasKey(el => el.Id);

            builder.Property(el => el.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(el => el.Location)
                .HasColumnName("Location");

            builder.Property(el => el.Destination)
                .HasColumnName("Destination");

            builder.Property(el => el.Cargo)
                .HasColumnName("Cargo");

            builder.Property(el => el.Status)
                .HasColumnName("Status");

            builder.Property(el => el.Payment)
                .HasColumnName("Payment");
        }
    }
}
