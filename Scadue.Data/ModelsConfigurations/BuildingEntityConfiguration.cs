using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scadue.Data.Models;

namespace Scadue.Data.ModelsConfigurations
{
    public class BuildingEntityConfiguration : IEntityTypeConfiguration<BuildingEntity>
    {
        public void Configure(EntityTypeBuilder<BuildingEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.Data)
                .IsRequired();
            builder.Property(p => p.UnitId)
                .IsRequired();

            builder.HasOne(p => p.Unit)
                .WithMany(p => p.Buildings)
                .HasForeignKey(p => p.UnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
