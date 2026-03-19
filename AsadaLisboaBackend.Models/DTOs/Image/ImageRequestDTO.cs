using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsadaLisboaBackend.Models.DTOs.Image
{
    public class ImageRequestDTO
    {
        [Required(ErrorMessage = "El titulo es requerido")]  
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerido")]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public long FileSize { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Debe selecionar un estado válido")]
        public int StatusId { get; set; }

        public List<Guid> CategoryIds { get; set; } = new();
      


    }
}
