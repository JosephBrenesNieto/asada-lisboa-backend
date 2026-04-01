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

            builder.HasData(
                new DocumentType { Id = Guid.NewGuid(), Name = "PDF", Extension = ".pdf", MimeType = "application/pdf" },
                new DocumentType { Id = Guid.NewGuid(), Name = "Word", Extension = ".docx", MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                new DocumentType { Id = Guid.NewGuid(), Name = "Excel", Extension = ".xlsx", MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                new DocumentType { Id = Guid.NewGuid(), Name = "CSV", Extension = ".csv", MimeType = "text/csv" },
                new DocumentType { Id = Guid.NewGuid(), Name = "Texto", Extension = ".txt", MimeType = "text/plain" },
                new DocumentType { Id = Guid.NewGuid(), Name = "ZIP", Extension = ".zip", MimeType = "application/octet-stream" });
        }
    }
}
