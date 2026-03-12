using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AsadaLisboaBackend.Models.DTOs.Jwt;
using AsadaLisboaBackend.ServiceContracts.Jwt;
using AsadaLisboaBackend.Utils.OptionsPattern;
using AsadaLisboaBackend.Models.IdentityModels;

namespace AsadaLisboaBackend.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly RefreshJwtOptions _refreshJwtOptions;

        public JwtService(IOptions<JwtOptions> jwtOptions, IOptions<RefreshJwtOptions> jwtRefreshOptions)
        {
            _jwtOptions = jwtOptions.Value;
            _refreshJwtOptions = jwtRefreshOptions.Value;
        }

        public AuthenticationResponseDTO GenerateToken(ApplicationUser user)
        {
            // Expiration dates to JWT and refresh token.
            DateTime expirationToken = DateTime.UtcNow.AddMinutes(_jwtOptions.EXPIRATION_MINUTES);
            DateTime expirationRefreshToken = DateTime.UtcNow.AddMinutes(_refreshJwtOptions.EXPIRATION_MINUTES);

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Subject => Who's the user, user's ID. 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID => Token unique identifier.
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()), // Issued At => Exact moment of issuing.
                new Claim(ClaimTypes.Email, user.Email?.ToString() ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.Email?.ToString() ?? ""),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.FirstLastName} {user.SecondLastName}"),
            };

            // Converts Key (string) to Bytes.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.KEY));
            // Generate credentials using Key and Algorithm.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Creates token structure (Headers, Payload and Signature).
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                _jwtOptions.ISSUER,
                _jwtOptions.AUDIENCE,
                claims,
                expires: expirationToken,
                signingCredentials: signingCredentials
            );

            // Token generation serialized.
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AuthenticationResponseDTO()
            {
                RefreshToken = token, // TODO: Generate refresh token.
                Token = token,
                Email = user.Email ?? "",
                ExpirationToken = expirationToken,
                ExpirationRefreshToken = expirationRefreshToken,
                FullName = $"{user.FirstName} {user.FirstLastName} {user.SecondLastName}",
            };
        }
    }
}
