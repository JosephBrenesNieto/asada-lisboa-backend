using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsadaLisboaBackend.Models.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Extension)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.MimeType)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Extension)
                .IsUnique();
        }
    }
}
