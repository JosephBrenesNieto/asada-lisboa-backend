using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsadaLisboaBackend.Models
{
    [Index(nameof(Slug), IsUnique = true)]
    public class Images
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El slug de la imagen es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El slug de la imagen debe ser entre {1} y {0} caracteres.")]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la imagen es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El título de la imagen debe ser entre {1} y {0} caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción de la imagen es requerido.")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "La descripción de la imagen debe ser entre {1} y {0} caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación de la imagen es requerido.")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "El tamaño de la imagen es requerido.")]
        [Range(1, 52_428_800, ErrorMessage = "El tamaño de la imagen debe ser entre {0} y {1} bytes.")]
        public long FileSize { get; set; } = 0;

        // Foreign Key
        [ForeignKey("Status")]
        public Guid StatusId { get; set; }
        public Statuses? Status { get; set; } = null;

        public ICollection<Categories> Categories { get; set; } = new List<Categories>();
    }
}
