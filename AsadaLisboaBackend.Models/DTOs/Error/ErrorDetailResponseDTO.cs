namespace AsadaLisboaBackend.Models.DTOs.Error
{
    public class ErrorDetailResponseDTO
    {
        public string Code { get; init; }
        public string Message { get; init; }

        public ErrorDetailResponseDTO(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
