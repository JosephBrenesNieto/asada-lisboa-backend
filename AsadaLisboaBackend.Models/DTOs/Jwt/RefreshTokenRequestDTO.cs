namespace AsadaLisboaBackend.Models.DTOs.Jwt
{
    public class RefreshTokenRequestDTO
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
