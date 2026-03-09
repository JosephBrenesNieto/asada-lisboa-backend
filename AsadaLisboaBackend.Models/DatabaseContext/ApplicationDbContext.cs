using Microsoft.EntityFrameworkCore;

namespace AsadaLisboaBackend.Models.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AboutUsSection> AboutUsSections { get; set; }
        public DbSet<VisualSetting> VisualSettings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<New> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
