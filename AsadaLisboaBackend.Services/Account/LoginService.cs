using Microsoft.AspNetCore.Identity;
using AsadaLisboaBackend.Models.DTOs.Account;
using AsadaLisboaBackend.ServiceContracts.Jwt;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Account;
using AsadaLisboaBackend.Models.DTOs.Jwt;

namespace AsadaLisboaBackend.Services.Account
{
    public class LoginService : ILoginService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.Email);

            if (user is null)
                throw new ArgumentNullException("No existe un usuario con este correo electrónico.");

            var result = await _signInManager.PasswordSignInAsync(user, loginRequestDTO.Password, isPersistent: true, lockoutOnFailure: false);

            // TODO: Add errors.
            if (!result.Succeeded)
                throw new ArgumentException("Correo electrónico y/o contraseña incorrectos.");

            var autenticationResponse = _jwtService.GenerateToken(user);

            user.RefreshToken = autenticationResponse.RefreshToken;
            user.RefreshTokenExpiration = autenticationResponse.ExpirationRefreshToken;

            await _userManager.UpdateAsync(user);

            return autenticationResponse;
        }
    }
}
