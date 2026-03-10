using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsadaLisboaBackend.Models.Configurations
{
    public class AboutUsSectionConfiguration : IEntityTypeConfiguration<AboutUsSection>
    {
        public void Configure(EntityTypeBuilder<AboutUsSection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SectionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasIndex(x => x.Order);
        }
    }
}
