using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsadaLisboaBackend.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
                new Category { Id = Guid.NewGuid(), Name = "Proyectos Ejecutados" },
                new Category { Id = Guid.NewGuid(), Name = "Estados Financieros" }, 
                new Category { Id = Guid.NewGuid(), Name = "Tanque Principal" },
                new Category { Id = Guid.NewGuid(), Name = "Pozo Principal" },
                new Category { Id = Guid.NewGuid(), Name = "Lineamientos" },
                new Category { Id = Guid.NewGuid(), Name = "Sugerencias" },
                new Category { Id = Guid.NewGuid(), Name = "Solicitudes" },
                new Category { Id = Guid.NewGuid(), Name = "Reglamentos" },
                new Category { Id = Guid.NewGuid(), Name = "Colindancia" },
                new Category { Id = Guid.NewGuid(), Name = "Hidrantes" },
                new Category { Id = Guid.NewGuid(), Name = "Convenios" },
                new Category { Id = Guid.NewGuid(), Name = "Informes" },
                new Category { Id = Guid.NewGuid(), Name = "Exámenes" },
                new Category { Id = Guid.NewGuid(), Name = "Estudios" },
                new Category { Id = Guid.NewGuid(), Name = "Dudas" });
        }
    }
}
