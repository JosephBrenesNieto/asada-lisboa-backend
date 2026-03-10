using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models
{
    public class Charge
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre del cargo es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre del cargo debe ser entre {1} y {0} caracteres.")]
        public string Name { get; set; } = string.Empty;
    }
}
