using AsadaLisboaBackend.Models.DTOs.Error;

namespace AsadaLisboaBackend.Services.Exceptions
{
    public class IdentityErrorException : Exception
    {   
        public IReadOnlyCollection<ErrorDetailResponseDTO> Errors { get; }

        public IdentityErrorException(List<ErrorDetailResponseDTO> errors) : base()
        {
            Errors = errors ?? new List<ErrorDetailResponseDTO>();
        }

        public IdentityErrorException(string message, List<ErrorDetailResponseDTO> errors) : base(message)
        {
            Errors = errors ?? new List<ErrorDetailResponseDTO>();
        }

        public IdentityErrorException(string message, Exception inner, List<ErrorDetailResponseDTO> errors) : base(message, inner)
        {
            Errors = errors ?? new List<ErrorDetailResponseDTO>();
        }
    }
}
