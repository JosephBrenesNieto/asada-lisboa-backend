using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models.DTOs.Account
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato incorrecto para un email")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "La contraseña debe incluir mayúsculas, minúsculas y números.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contraseña es requerida")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmar Contraseña es requerida")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "La contraseña debe incluir mayúsculas, minúsculas y números.")]
        [Compare("Password", ErrorMessage = "Debe considir con la contraseña")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
