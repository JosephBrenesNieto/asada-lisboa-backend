using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models
{
    public class DocumentType
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de documento es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre del tipo de documento debe ser entre {1} y {0} caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La extensión del tipo de documento es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "La extensión del tipo de documento debe ser entre {1} y {0} caracteres.")]
        public string Extension { get; set; } = string.Empty;

        [Required(ErrorMessage = "El MIME Type del tipo de documento es requerido.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El MIME Type del tipo de documento debe ser entre {1} y {0} caracteres.")]
        public string MimeType { get; set; } = string.Empty;
    }
}
