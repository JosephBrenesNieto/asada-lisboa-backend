using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models
{
    public class Categories
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre de la categoría debe ser entre {1} y {0} caracteres.")]
        public string Name { get; set; } = string.Empty;

        // Foreign Key
        public ICollection<News> News { get; set; } = new List<News>();
        public ICollection<Images> Images { get; set; } = new List<Images>();
        public ICollection<Documents> Documents { get; set; } = new List<Documents>();
    }
}
