using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scadue.Data.Models;

namespace Scadue.Data.ModelsConfigurations
{
    public class AdministrativeUnitEntityConfiguration : IEntityTypeConfiguration<AdministrativeUnitEntity>
    {
        public void Configure(EntityTypeBuilder<AdministrativeUnitEntity> builder)
        {
            builder.HasKey(key => key.Id);

            builder.Property(key => key.Id)
                .IsRequired();
            builder.Property(p => p.AdminLevel)
                .IsRequired();
            builder.Property(p => p.CenterLatitude)
                .IsRequired();
            builder.Property(p => p.CenterLongitude)
                .IsRequired();
            builder.Property(p => p.Name).IsRequired(false);
            builder.Property(p => p.ISO3166).IsRequired(false);

            builder.HasOne(p => p.ParentAdministrativeUnit)
                .WithMany(p => p.ChildUnits)
                .HasForeignKey(p => p.ParentAdminUnitId);
            builder.HasMany(p => p.ChildUnits)
                .WithOne(p => p.ParentAdministrativeUnit)
                .HasForeignKey(p => p.ParentAdminUnitId);
        }
    }
}
