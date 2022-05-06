using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scadue.Data.Models;

namespace Scadue.Data.ModelsConfigurations
{
    public class UnitCoordinatesEntityConfiguration : IEntityTypeConfiguration<UnitCoordinatesEntity>
    {
        public void Configure(EntityTypeBuilder<UnitCoordinatesEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Lat)
                .IsRequired();
            builder.Property(p => p.Lon)
                .IsRequired();
            builder.Property(p => p.Number)
                .IsRequired();
        }
    }
}
