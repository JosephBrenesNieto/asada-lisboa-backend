using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadaLisboaBackend.Models.DTOs.Image
{
    public class ImageUpdateRequestDTO
    {
        public Guid Id { get; set; }              // Identificador de la imagen
        public string Title { get; set; } = "";   // Nuevo título
        public string Description { get; set; } = "";
        public Guid StatusId { get; set; }
        public List<Guid> CategoryIds { get; set; } = new();
        //public IFormFile? File { get; set; }      // Opcional: nueva imagen

    }
}
