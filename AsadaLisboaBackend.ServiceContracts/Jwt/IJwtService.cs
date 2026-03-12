using System.Security.Claims;
using AsadaLisboaBackend.Models.DTOs.Jwt;
using AsadaLisboaBackend.Models.IdentityModels;

namespace AsadaLisboaBackend.ServiceContracts.Jwt
{
    public interface IJwtService
    {
        public AuthenticationResponseDTO GenerateToken(ApplicationUser user);
        public ClaimsPrincipal? GetClaimsPrincipal(string token);
        public Task<AuthenticationResponseDTO> ValidateRefreshToken(RefreshTokenRequestDTO refreshTokenRequestDTO);
    }
}
