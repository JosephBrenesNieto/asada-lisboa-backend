using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsadaLisboaBackend.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required(ErrorMessage = "El nombre del usuario es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre del usuario debe ser entre {1} y {0} caracteres.")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El primer apellido del usuario es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El primer apellido del usuario debe ser entre {1} y {0} caracteres.")]
        public string FirstLastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El segundo apellido del usuario es requerido.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El segundo apellido del usuario debe ser entre {1} y {0} caracteres.")]
        public string SecondLastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ubicación de la imagen del usuario es requerido.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "La ubicación de la imagen del usuario debe ser entre {1} y {0} caracteres.")]
        public string ImageUrl { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

        [ForeignKey("Charge")]
        public Guid ChargeId { get; set; }
        public Charge? Charge { get; set; } = null;
    }
}