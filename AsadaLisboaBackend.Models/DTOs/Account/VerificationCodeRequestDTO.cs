using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsadaLisboaBackend.Models.DTOs.Account
{
    public class VerificationCodeRequestDTO
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool IsUsed { get; set; }
        public int ResendCount { get; set; } = 0;   // contador de reenvíos
        public DateTime? LastSent { get; set; }      // última vez que se envió
    }
}
