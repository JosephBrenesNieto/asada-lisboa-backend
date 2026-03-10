using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsadaLisboaBackend.Models.Configurations
{
    public class VisualSettingConfiguration : IEntityTypeConfiguration<VisualSetting>
    {
        public void Configure(EntityTypeBuilder<VisualSetting> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SettingType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasIndex(x => x.Order);
        }
    }
}
