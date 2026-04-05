using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using AsadaLisboaBackend.Models.DTOs.Error;
using AsadaLisboaBackend.Services.Exceptions;
using AsadaLisboaBackend.Models.IdentityModels;
using AsadaLisboaBackend.ServiceContracts.Emails;
using AsadaLisboaBackend.ServiceContracts.Accounts;

namespace AsadaLisboaBackend.Services.Accounts
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly ILogger<ResetPasswordService> _logger;
        private readonly IEmailsSenderService _emailsSenderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordService(UserManager<ApplicationUser> userManager, IEmailsSenderService emailsSenderService, ILogger<ResetPasswordService> logger)
        {
            _logger = logger;
            _userManager = userManager; 
            _emailsSenderService = emailsSenderService;
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null || !user.EmailConfirmed)
            {
                _logger.LogError("Intento de recuperación de contraseña para un correo electrónico no registrado o no confirmado: {Email}", email);
                throw new NotFoundException("No existe un usuario con este correo electrónico.");
            }

            string resetToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await _userManager.GeneratePasswordResetTokenAsync(user)));

            await _emailsSenderService.SendResetPasswordToken(user.FirstName, email, resetToken);
        }

        public async Task ResetPassword(string email, string token, string password)
        {
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var user = await _userManager.FindByEmailAsync(email);
            if (user is null || !user.EmailConfirmed)
            {
                _logger.LogError("Intento de restauración de contraseña para un correo electrónico no registrado o no confirmado: {Email}", email);
                throw new NotFoundException("No existe un usuario con este correo electrónico.");
            }

            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (!result.Succeeded)
            {
                _logger.LogError("Error al restaurar contraseña para el correo electrónico {Email}. Errores: {Errors}", email, string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}")));
                throw new IdentityErrorException(
                    "Error al restaurar contraseña.",
                    result.Errors.Select(e => new ErrorDetailResponseDTO(e.Code, e.Description)
                    ).ToList()
                );
            }
        }
    }
}
