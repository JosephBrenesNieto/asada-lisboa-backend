using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace AsadaLisboaBackend.Models
{
    [Index(nameof(Slug), IsUnique = true)]
    public class News
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El slug de la noticia es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El slug de la noticia debe ser entre {1} y {0} caracteres.")]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ubicación de la imagen de la noticia es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "La ubicación de la imagen de la noticia debe ser entre {1} y {0} caracteres.")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título de la noticia es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El título de la noticia debe ser entre {1} y {0} caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción de la noticia es requerido.")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "La descripción de la noticia debe ser entre {1} y {0} caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación de la noticia es requerido.")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "La fecha de última edición de la noticia es requerido.")]
        public DateTime LastEditionDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [ForeignKey("Status")]
        public Guid StatusId { get; set; }
        public Statuses? Status { get; set; } = null;

        public ICollection<Categories> Categories { get; set; } = new List<Categories>();
    }
}
