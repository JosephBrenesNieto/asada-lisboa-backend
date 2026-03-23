using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadaLisboaBackend.Models.DTOs.Document
{
    public class DocumentResponseDTO
    {
       public Guid Id { get; set; }

       public string Slug { get; set; } = string.Empty;
       public string Title { get; set; } = string.Empty;

       public string Description { get; set; } = string.Empty;

        public DateTime PublicationDate;

        public long FileSize;

      public string StatusName { get; set; } = string.Empty;

        public string DocumentTypeName { get; set; } = string.Empty;

        public List<string> Categories { get; set; } = new();
    }
}
