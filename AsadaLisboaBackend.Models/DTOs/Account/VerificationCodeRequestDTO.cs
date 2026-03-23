namespace AsadaLisboaBackend.Models.DTOs.Account
{
    public class VerificationCodeRequestDTO
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
