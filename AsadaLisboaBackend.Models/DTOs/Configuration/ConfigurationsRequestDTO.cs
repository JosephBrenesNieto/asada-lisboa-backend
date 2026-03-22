using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models.DTOs.Configuration
{
    public class ConfigurationsRequestDTO
    {
        [Required(ErrorMessage = "El nombre de la sección es requerido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre de la sección debe ser entre {1} y {0} caracteres.")]
        public string SettingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "El valor de la sección es requerido.")]
        [StringLength(100, ErrorMessage = "El valor de la sección debe ser entre {1} y {0} caracteres.")]
        public string Value { get; set; } = string.Empty;

        [Required(ErrorMessage = "El orden de la sección es requerido.")]
        [Range(0, 255, ErrorMessage = "El orden de la sección debe ser entre {0} y {1} caracteres.")]
        public byte Order { get; set; } = 0;
    }
}
