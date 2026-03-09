using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre de la categoría debe ser entre {1} y {0} caracteres.")]
        public string Name { get; set; } = string.Empty;

        // Foreign Key
        public ICollection<New> News { get; set; } = new List<New>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
