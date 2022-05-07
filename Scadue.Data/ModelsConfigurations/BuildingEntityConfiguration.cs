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
            builder.Property(p => p.Class)
                .IsRequired();
            builder.Property(p => p.Type)
                .IsRequired();
            builder.Property(p => p.UnitId)
                .IsRequired();
            builder.Property(p => p.CenterLatitude)
                .IsRequired();
            builder.Property(p => p.CenterLongitude)
                .IsRequired();
            builder.Property(p => p.Name).IsRequired(false);
            builder.Property(p => p.Adress).IsRequired(false);

            builder.HasOne(p => p.Unit)
                .WithMany(p => p.Buildings)
                .HasForeignKey(p => p.UnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
