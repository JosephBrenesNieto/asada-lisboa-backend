namespace AsadaLisboaBackend.Models.DTOs.Jwt
{
    public class AuthenticationResponseDTO
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpirationToken { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpirationRefreshToken { get; set; }
    }
}
